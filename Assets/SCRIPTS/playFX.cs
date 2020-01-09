using UnityEngine;
using System.Collections;

public class playFX : MonoBehaviour {


	public GameObject fx;
	ParticleSystem emit1;
	ParticleSystem emit2;
	target_Generator instance = new target_Generator ();
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	//	WaitForSeconds (5);
		//get the position of 
		//playFXonTarget();
	}

	public void playFXonTarget(){

		GameObject newFX = Instantiate (fx, instance.targetPosition, Quaternion.identity) as GameObject;

		emit1 = newFX.transform.GetChild (0).gameObject.GetComponent<ParticleSystem>();
		emit2 = newFX.transform.GetChild (1).gameObject.GetComponent<ParticleSystem>();

		emit1.Play ();
		emit2.Play ();

	}
}
