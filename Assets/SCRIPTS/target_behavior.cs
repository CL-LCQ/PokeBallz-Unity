using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class target_behavior : MonoBehaviour {
	
	Vector3 startScale;
	GameObject child;
	//public GameObject FX;
	float scaleFactor = 2;
	float currentScale;
	bool streak = false;
	int multiplier;
	target_Generator playfx = new target_Generator();




	// Use this for initialization
	void Start () {
		
		child = transform.GetChild (0).gameObject;

			

		startScale = child.transform.localScale;
		transform.LookAt( new Vector3 (0, 2.17f, -54.9f));
	}
	
	// Update is called once per frame
	void Update () {

	
		//this is the scaler
		//over time it should get faster
		int speedFactor = ApplicationModel.difficulty/20;
		if (speedFactor < 1) {
			speedFactor = 1;
		}
		//child.transform.localScale = Vector3.Lerp (child.transform.localScale,new Vector3 (0,0,0), scaleFactor/10 * Time.deltaTime);
		child.transform.localScale = Vector3.Lerp (child.transform.localScale,new Vector3 (0,0,0), (scaleFactor/10 * Time.deltaTime)*speedFactor);

		currentScale = child.transform.localScale.x;

		//print (currentScale);

		float ratio = startScale.x / 3;
		if (currentScale < ratio) {
			target_Generator.breakMultiplier();

			Destroy (this.gameObject);

			target_Generator.makeItReady ();

		}
	
	




	}



	void OnTriggerEnter(Collider other) {
		
		//also if collision happens at a lower scale then the points shsould be higher!

		int bonus = 50;
		float currScale = transform.localScale.x;
		if(currScale>8.0){

			bonus = 100;
		}
		else if(currScale>6.0 && currScale<8.0){

			bonus = 200;
		}
		else if(currScale<6.0 ){

		
			bonus = 500;
			//display the bonus and the multiplier
		}
//
		int i = 1;

		target_Generator.addScore (i,bonus);
		target_Generator.increaseMultiplier();
		//call the score updater
	
		playfx.playFX (other.transform.position);


		Destroy (other.gameObject);
		destroyAll();
	}

	void destroyAll(){
		GameObject parent = transform.parent.gameObject;
		Destroy (this.gameObject);
		Destroy (parent);
	
	}


}
