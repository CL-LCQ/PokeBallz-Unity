using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class levelLoader : MonoBehaviour {

	public string Level;
	public bool isPaused;
	public GameObject pausePanel;
	//webCam webCamera = new webCam();

	// Use this for initialization
	void Start () {
		isPaused = false;
		AudioListener.pause = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load(){
	//	webCamera.stopCamera ();

		Time.timeScale = 1;
		AudioListener.pause = false;
		SceneManager.LoadScene(Level);
	}

	public void PauseGame(){
		if (isPaused == false) {


			print ("PAUSING");
			Time.timeScale = 0;
			isPaused = true;
			pausePanel.SetActive (true);
			AudioListener.pause = true;
			//freeze the cam
			//GameObject.Find("Main camera").GetComponent(iPhoneGyroCam).enabled= false;
//			GameObject cam = 
//			cam.GetComponent(iPhoneGyro).enabled = false;

		} else {
			print ("UNPAUSING");
			pausePanel.SetActive (false);
			Time.timeScale = 1;
			isPaused = false;
			AudioListener.pause = false;
			//unfreeze cam
		
		}
	}

	public void setToPause(){
		print ("PAUSING");
		Time.timeScale = 0;
		isPaused = true;
		//pausePanel.SetActive (true);
		AudioListener.pause = true;

	}

	public void setToPlay(){
		print ("UNPAUSING");
		//pausePanel.SetActive (false);
		Time.timeScale = 1;
		isPaused = false;
		AudioListener.pause = false;

	}
}
