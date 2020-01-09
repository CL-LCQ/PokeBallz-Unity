using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restartLevel : MonoBehaviour {

	// Use this for initialization

	addAds ads = new addAds();
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	public void restart(){



		Application.LoadLevel ("POKEBALLZ_MAIN");
		ads.DestroyBanner ();

	}

}
