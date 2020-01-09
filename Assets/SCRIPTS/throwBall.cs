using UnityEngine;
using System.Collections;

public class throwBall : MonoBehaviour {

	Vector3 mMouseDownPos;
	Vector3 mMouseUpPos;
	Vector3 direction;
	float time1;
	float time2;
	float timeLength;
	Rigidbody rb;
	GameObject newBall;
	static public int pokeballUsed;

	bool ballSent;

	public GameObject mainCam;
	public GameObject canonPos;
	public GameObject ballPrefab;
	public AudioSource audioThrowBall;
	levelLoader levelldrInst = new levelLoader();

	void Start() 
	{
		
		Debug.Log("STARTED");

		ballSent = true;
		//onClick+drag get vector of drag
		//generate the prefab
		//and 
		//
	}




	void Update() 
	{
		bool pauseChecker = levelldrInst.isPaused;
		if (target_Generator.isGameOver() == false && pauseChecker == false) {
			
			if (Input.GetMouseButtonDown (0)) {
				mMouseDownPos = Input.mousePosition;
				mMouseDownPos.z = 0;
				time1 = Time.time;


				float scaleValue = 0.08F;
				if (ballSent == false) {
			
					Destroy (newBall);
					ballSent = true;
			
				}
				if (ballSent == true) {
					ballPrefab.transform.localScale = new Vector3 (scaleValue, scaleValue, scaleValue);
					newBall = Instantiate (ballPrefab, canonPos.transform.position, Quaternion.identity) as GameObject;
					newBall.transform.Rotate (0, 180, 0);



					rb = newBall.GetComponent<Rigidbody> ();
					rb.useGravity = false;
					ballSent = false;
				}


			} else if (Input.GetMouseButtonUp (0)) {
			
				//pokeballUsed += 1;
				target_Generator.ballused +=1;
				mMouseUpPos = Input.mousePosition;
				mMouseUpPos.z = 0;

				time2 = Time.time;
				timeLength = (time2 - time1);

				float distance = (mMouseUpPos.x - mMouseDownPos.x) / 2 + (mMouseUpPos.y - mMouseDownPos.y) / 2;

				direction = mMouseUpPos - mMouseDownPos;

				//a long distance + short movement will send the ball super far
				//direction.z = ((distance / 2) * 1 / (timeLength * 5));
				direction.z = ((distance / 4) * 1 / (timeLength * 5));

				//reduce the error for side direction
				direction.x = direction.x * 0.5f;

				//Up angle of throw
				//direction.y = Remap (distance, 0, 200, 10, 60);
				direction.y = Remap (distance, 0, 300, 5, 80);



				//shoot the ball in the direction of the camera
				direction = mainCam.transform.TransformDirection (direction);


				if (mMouseUpPos.y - mMouseDownPos.y > 0) {
					if(pauseChecker == false){
						print ("played");
						rb.useGravity = true;
						rb.AddForce (direction);
						rb.AddTorque (2, 2, 3 * (direction.z));
						audioThrowBall.Play ();
						ballSent = true;
					}
				} 

			}



		}

	}

	float Remap ( float value, float low1, float high1, float low2, float high2) {
		return(low2 + (value - low1) * (high2 - low2) / (high1 - low1));
	}


}

