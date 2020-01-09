using UnityEngine;
using System.Collections;
using System.Collections.Generic;


#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 
#else
using UnityEngine.SceneManagement;
#endif




public class addAds : MonoBehaviour {


	levelLoader lvlLoader = new levelLoader();
	int hasads;
	customInterstitialAd customAD = new customInterstitialAd();
	private GoogleMobileAdBanner banner;
	public GADBannerSize size = GADBannerSize.SMART_BANNER;

	void Awake() {
		hasads = PlayerPrefs.GetInt("ads");
		if(!GoogleMobileAd.IsInited) {
			GoogleMobileAd.Init();
		}

	}

	void Start () {
		

		if(ApplicationModel.isAdPurchased == false) {


		//if(hasads == 1) {
		

			banner = GoogleMobileAd.CreateAdBanner (TextAnchor.LowerLeft, size);
			banner.OnOpenedAction += OnOpenedAction;

//			GoogleMobileAd.LoadInterstitialAd ();
//
//			GoogleMobileAd.OnInterstitialOpened += OnInterstisialsOpen;
//			GoogleMobileAd.OnInterstitialClosed += OnInterstisialsClosed;
//
//			UM_AdManager.OnInterstitialLoaded += HandleOnInterstitialLoaded;
//			UM_AdManager.OnInterstitialLoadFail += HandleOnInterstitialLoadFail;
//			UM_AdManager.OnInterstitialClosed += HandleOnInterstitialClosed;


			GoogleMobileAd.OnInterstitialLoaded += HandleOnInterstitialLoaded;
			GoogleMobileAd.OnInterstitialClosed += OnInterstisialsClosed;
			GoogleMobileAd.OnInterstitialOpened += OnInterstisialsOpen;


			//loadin ad:
			GoogleMobileAd.LoadInterstitialAd ();

		}
		//

	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnOpenedAction (GoogleMobileAdBanner banner) {
		banner.OnOpenedAction -= OnOpenedAction;
		banner.OnClosedAction += OnClosedAction;
		Debug.Log("Banner was just clicked");
		//Pause the game
		lvlLoader.PauseGame();
	}

	void OnClosedAction (GoogleMobileAdBanner banner){
	
		//UnPause the game
		Debug.Log("Banner was dismissed");
		lvlLoader.PauseGame();
	}



	//interstitial
	public void checkForInterstitial(){
		print("CHECKING ADS..");
		//every 2 games load an ad
		int playTimes = PlayerPrefs.GetInt ("playTimes");
		if (playTimes % 3 == 0) {

			print ("2 games have passed"+ hasads);
			//int checker = 1;

			if(ApplicationModel.isAdPurchased == false){
				
				//print ("waiting for interstitial..");
				//if (GoogleMobileAd.IsInterstitialReady == true) {
					print ("showing interstitial");
				//if ios
				customAD.ShowBanner ();



				//if android
//					GoogleMobileAd.ShowInterstitialAd ();
//					GoogleMobileAd.LoadInterstitialAd ();
//


				//}

			}
		}
	}

	void HandleOnInterstitialLoaded () {
		//ad loaded, strting ad
//		GoogleMobileAd.ShowInterstitialAd ();
//		GoogleMobileAd.LoadInterstitialAd ();
	}


	private void OnInterstisialsOpen() {
		//pausing the game
	//	print ("OPEN");
			lvlLoader.setToPause ();
	}

	private void OnInterstisialsClosed() {
		//un-pausing the game
		//print ("CLOSED");
				lvlLoader.setToPlay ();
	}





//	public void ShowBanner() {
//		
//		GoogleMobileAd.StartInterstitialAd();
//		print ("ad is up");
//	}
//
//	private void OnInterstisialsOpen() {
//		//pausing the game
//		//Time.timeScale = 0;
//		print ("OPEN");
//		lvlLoader.setToPause ();
//
//	}
//
//	private void OnInterstisialsClosed() {
//		//un-pausing the game
//		//Time.timeScale = 1;
//		print ("CLOSED");
//		lvlLoader.setToPlay ();
//	}
//
//
//	void HandleOnInterstitialClosed () {
//		Debug.Log ("Interstitial Ad was closed");
//		UM_AdManager.ResetActions();
//		lvlLoader.PauseGame();
//	}
//
//	void HandleOnInterstitialLoadFail () {
//		Debug.Log ("Interstitial is failed to load");
//		UM_AdManager.ResetActions();
//	}
//
//	void HandleOnInterstitialLoaded () {
//		Debug.Log ("Interstitial ad content ready");
//
//		//Content was loaded, we can now show the Interstitial ad.
//		//UM_AdManager.ShowInterstitialAd();
//	}

	public void DestroyBanner() {
		//GoogleMobileAd.DestroyBanner(banner.id);
		banner = null;
	}

	public string sceneBannerId {
		get {
			#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
			return Application.loadedLevelName + "_" + this.gameObject.name;
			#else
			return SceneManager.GetActiveScene().name + "_" + this.gameObject.name;
			#endif
		}
	}
}
