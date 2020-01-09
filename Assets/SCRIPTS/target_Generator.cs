using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class target_Generator : MonoBehaviour {


	public Text timeLabel;
	public Text scoreLabel;
	public Text finalScore;
	public Text scoreFeedback;
	public Text countDownlabel;
	public Text totalballUsedLabel;
	public Text totalTimeLabel;
	public Text totalTargetsLabel;

	public GameObject bonusPanel;
	public Text currentScore;
	public Text bonusFeedback;
	public Image feedbackImg;

	public Sprite img1;
	public Sprite img2;
	public Sprite img3;
	public Sprite img4;


	static int bonus;
	static int difficultyFactor;
	static int precisionBonus;
	static int points;
	static int score;
	static float timeLeft;
	static int multiplier;


	static float CtdntimeLeft;
	static bool isCtdnGoing;


	//Gameplay
	public GameObject thrower;
	public GameObject TargetPrefab;
	public GameObject targetCylinder;
	GameObject newTarget;
	GameObject GameOverPanel;
	 static bool gameOver;
	Vector3 timeLabelScale;
	public float totalTime;
	public static int ballused;

	public Vector3 targetPosition;
	Vector3 FXposition;
	GameObject FXprefab;
	ParticleSystem emit1;
	ParticleSystem emit2;

	addAds ads = new addAds();
//	webCam webCamera = new webCam();

	int t=0;
	int lastT;

	static bool readyForNewTarget = true;

	//audio
	public AudioSource winJingle;
	public AudioSource Collect;
	float collectPitch;

	public Material mat;
	WebCamTexture wct ;
	//ads
	public GameObject interstitalAd;

	// Use this for initialization
	void Start () {



		thrower.SetActive (false);
		GameOverPanel = GameObject.Find ("gameOver");
		GameOverPanel.SetActive( false);

		ads.checkForInterstitial ();
		startCountdown ();
		initGame ();


		collectPitch = 0.1f;




		//cam
//		WebCamDevice[] device = WebCamTexture.devices; 
//		wct = new WebCamTexture(); 
//
//		if(device.Length>0)
//		{
//			wct.deviceName = device[0].name; 
//			wct.Play();
//		}
//
//		mat.mainTexture = wct;


	}


	// Update is called once per frame
	void Update () {

		t = (int)(1 * Time.deltaTime);
		//countdown before gameStart
		if (isCtdnGoing == true) {
			
			CtdntimeLeft -= Time.deltaTime;
			updateCounter ();


		} 


		else if (isCtdnGoing == false) {
			if (gameOver == false) {
				startGameplay ();
				totalTime += 1.0f * Time.deltaTime;
			}
		}

	
		updateScoreLabels ();



	}
	//end update()
	void startAll(){
		//GoogleMobileAd.LoadInterstitialAd ();



		throwBall.pokeballUsed = 0;
		ballused = 0;
		startCountdown ();
		initGame ();
	}
	//game management
	public void initGame(){



		GameOverPanel.SetActive( false);
		totalTime = 0;
		points = 0;
		precisionBonus = 0;
		timeLeft = 20.0f;
		readyForNewTarget = true;
		gameOver = false;
	


	}




	public void continueGame(){

		//remove continue?
		//continue feature can be done later...
		//instead just show the interstitial every game
		//and make a remove ads for 1$

		gameOver = false;
		//readyForNewTarget = true;
		GameOverPanel.SetActive( false);
		timeLeft = 11;
		timeLabel.transform.localScale = timeLabelScale/2;
	}



	public void startGameplay(){
		
		thrower.SetActive (true);
		if (readyForNewTarget == true) {

			targetPosition = GetRandomPos ();
			newTarget = Instantiate (TargetPrefab, targetPosition, Quaternion.identity) as GameObject;
			readyForNewTarget = false;
		}


		timeLeft -= Time.deltaTime;
		int time = (int)timeLeft;
		timeLabel.text =  time.ToString();
		scoreLabel.text = points.ToString();
		//edit the score labels


		if (timeLeft <= 5.0f) {

			scaleTimerUp ();

		}

		if (timeLeft <= 0.0f) {
			if(gameOver == false)
				GameIsOver ();
		}


	}

	public void GameIsOver(){
		winJingle.Play ();

		timeLabel.text = "Game Over!";
		bonusPanel.SetActive (false);
		GameOverPanel.SetActive (true);
		gameOver = true;

		//calculate score
		//ballused = throwBall.pokeballUsed;
		//score = points*10000/((int)totalTime + ballused);
		if (points == 0) {
			score = 0;
		} else {
			if (ballused == 0) {
				score = points * 10000;
			} else {
				score = (points * 10000 / (ballused)) + precisionBonus;
			}
		}
		finalScore.text = "Score: " + score;
		int prevHighScore =  PlayerPrefs.GetInt("highScore");

		if (score > prevHighScore) {
			PlayerPrefs.SetInt ("highScore", score);
			scoreFeedback.text = "New Best!";
		}
		else {

			scoreFeedback.text = "Best Score:"+ prevHighScore;

		}

		totalballUsedLabel.text = "Total balls used: " + ballused;
		totalTargetsLabel.text = "Total targets: " + points;
		string time = totalTime.ToString ("F1");
		totalTimeLabel.text = "Total time: " + time + " sc";
		ballused = 0;

	}

	public static bool isGameOver(){
		return gameOver;
	}


	public static void makeItReady(){

		readyForNewTarget = true;

	}



	void playCollect(){
		GameObject tiii = GameObject.Find ("COLLECT");
		Collect = tiii.GetComponent<AudioSource> ();
		//collectPitch = Collect.pitch;
		Collect.pitch += collectPitch;
		Collect.Play();

	}


	public void playFX(Vector3 position){


		//GameObject newFX = Instantiate (FX, targetPosition, Quaternion.identity) as GameObject;
		playCollect();
		GameObject newFX = Instantiate(Resources.Load("FX_CATCHED"), position ,Quaternion.identity) as GameObject;
		//newFX.transform.position = targetPosition;
		//GameObject newFX = Instantiate(FXprefab, position ,Quaternion.identity) as GameObject;


		emit1 = newFX.transform.GetChild (0).gameObject.GetComponent<ParticleSystem>();
		emit2 = newFX.transform.GetChild (1).gameObject.GetComponent<ParticleSystem>();
		emit1.Play ();
		emit2.Play ();


	}


	//this is used before starting a game
	public void startCountdown(){

		timeLabelScale = countDownlabel.transform.localScale;
		countDownlabel.transform.localScale = timeLabelScale / 2;
		isCtdnGoing = true;
		CtdntimeLeft = 3.0f;


	}

	void scaleTimerUp(){
//		lastT =(int) Time.deltaTime;
//		if (t > lastT+1) {
//			timeLabel.transform.localScale = timeLabelScale / 2;
//		}

		countDownlabel.transform.localScale = Vector3.Lerp (countDownlabel.transform.localScale, timeLabelScale, 1.0f*Time.deltaTime);
		//call it only every second which means
		//start a timer and every one second &.0f*time.deltatime reset the scale

	}

	void updateCounter(){
		
//		timeLabel.transform.localScale = Vector3.Lerp (timeLabel.transform.localScale, timeLabelScale*2, 1.0f*Time.deltaTime);

		scaleTimerUp();


		if (CtdntimeLeft <= 0.0f) {
			GameObject label = GameObject.Find("countDown");
			label.SetActive (false);
			isCtdnGoing = false;
			countDownlabel.transform.localScale = timeLabelScale/2;

		}
		else if (CtdntimeLeft > 1.7f) {
			
			countDownlabel.text = "Ready";

			}

			
		if (CtdntimeLeft < 1.7f && CtdntimeLeft > 0.7f) {
			countDownlabel.text = "Steady";
			//timeLabel.transform.localScale = Vector3.Lerp (timeLabel.transform.localScale, timeLabelScale*2, 10.0f);
			}

		if (CtdntimeLeft < 0.7f && CtdntimeLeft >= 0.0f) {
			countDownlabel.text = "GO!";
			//timeLabel.transform.localScale = Vector3.Lerp (timeLabel.transform.localScale, timeLabelScale*2, 10.0f);
			}
			
	}





	public static void addScore(int i,int b){

		print ("multiplier is:" + multiplier);
		points += i;
		precisionBonus += b * multiplier;
		float test = i * 1.7f;
		timeLeft += test;
		bonus = b;

		readyForNewTarget = true;
	}


	public static void increaseMultiplier(){
		multiplier += 1;

	
	}
	public static void breakMultiplier(){
		multiplier = 1;

	}
	public void updateScoreLabels(){
		
		int speed =(int) totalTime;

		ApplicationModel.difficulty = speed;

		currentScore.text = precisionBonus.ToString();

		string multi = "x"+ multiplier.ToString ();
		bonusFeedback.text = multi;
		if (multiplier==2) {
			if (gameOver == false) {
				bonusPanel.SetActive (true);
			}
			feedbackImg.sprite =img1;
		} 
		else if (multiplier==4) {
			
			feedbackImg.sprite= img2;

		}
		else if (multiplier==6) {
			feedbackImg.sprite = img3;
		}
		else if (multiplier> 8 ) {
			feedbackImg.sprite = img4;

			//play audio or something
		}

	}


	private Vector3 GetRandomPos(){

		Mesh planeMesh = targetCylinder.GetComponent<MeshFilter>().mesh;
		int i = planeMesh.vertexCount;
		int b = Random.Range (0, i);
		Vector3[] vertices = planeMesh.vertices;
		Transform cylinderTransform = targetCylinder.transform;
		Vector3 newVec = cylinderTransform.TransformPoint(vertices [b]);

		return newVec;
	}


}
