using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class startGame : MonoBehaviour {

	public GameObject ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void startTheGame(){


//		Rigidbody rb = ball.GetComponent<Rigidbody>();
//		rb.isKinematic = false;
//		//WaitForSeconds(5.0);
//		StartCoroutine("movement");
		SceneManager.LoadScene("POKEBALLZ_MAIN");
	}
//	IEnumerator movement()
//	{
//		while (true) {        
//			yield return new WaitForSeconds(50.0f);        
//			//some blocks of code
//		}
//	}

}
