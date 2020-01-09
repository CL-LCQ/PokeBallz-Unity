using UnityEngine;
using System.Collections;

public class inApp : MonoBehaviour {

	public GameObject adButton;

	bool isProductPurchased;
	// Use this for initialization




	void Awake() {
		if(!GoogleMobileAd.IsInited) {
			GoogleMobileAd.Init();
		}

		GooglePlayConnection.instance.connect ();

		//UM_InAppPurchaseManager.instance.DeleteNonConsumablePurchaseRecord("adRemove");
		UM_InAppPurchaseManager.Client.OnPurchaseFinished += OnPurchaseFlowFinishedAction;
		UM_InAppPurchaseManager.Client.OnServiceConnected += OnConnectFinished;
		UM_InAppPurchaseManager.Client.OnServiceConnected += OnBillingConnectFinishedAction;
		UM_InAppPurchaseManager.Client.Connect();
	}


	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void purchaseAdRemoval(){

		//"Remove Ads";
		if (isProductPurchased == false) {
			UM_InAppPurchaseManager.Client.OnPurchaseFinished += OnPurchaseFlowFinishedAction;
			//UM_InAppPurchaseManager.instance.Purchase ("adRemove");
			UM_InAppPurchaseManager.Client.Purchase("adRemove");

		}

	}


	void checkPurchase(){
	
		isProductPurchased = UM_InAppPurchaseManager.Client.IsProductPurchased("adRemove");

		//this isnt stored at all
		//Global.isAdPurchased = isProductPurchased;
	//	Global.isAdPurchased = true;

		//ApplicationModel.isAdPurchased = isProductPurchased;
		//for testing purpose
		ApplicationModel.isAdPurchased = false;

		if (	ApplicationModel.isAdPurchased == true) {

			adButton.SetActive (false);
			print ("ad already purchased");


			//int setter = 1;
			//int setter = 0;
			//layerPrefs.SetInt ("ads", setter);



		} else {
			//int setter2 = 1;
			//PlayerPrefs.SetInt("ads", setter2);
			adButton.SetActive (true);


			print ("ad not purchased yet");
		}
	
	}


	private void OnConnectFinished(UM_BillingConnectionResult result) {

		if(result.isSuccess) {
			//UM_ExampleStatusBar.text = "Billing init Success";
		} else  {
			//UM_ExampleStatusBar.text = "Billing init Failed";
		}
	}


	private void OnBillingConnectFinishedAction (UM_BillingConnectionResult result) {
		UM_InAppPurchaseManager.Client.OnServiceConnected -= OnBillingConnectFinishedAction;
		if(result.isSuccess) {
			
			Debug.Log("Connected");
		} else {
			Debug.Log("Failed to connect");
		}
		checkPurchase ();
	}  

	private void OnPurchaseFlowFinishedAction (UM_PurchaseResult result) {
		UM_InAppPurchaseManager.Client.OnPurchaseFinished -= OnPurchaseFlowFinishedAction;
		if(result.isSuccess) {
			//UM_ExampleStatusBar.text = "Product " + result.product.id + " purchase Success";
		} else  {
		//	UM_ExampleStatusBar.text = "Product " + result.product.id + " purchase Failed";
		}
	}


}
