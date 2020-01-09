using UnityEngine;
using System;
using System.Collections;

public class UM_IOS_InAppClient : UM_BaseInAppClient, UM_InAppClient {

	//--------------------------------------
	// Initialization
	//--------------------------------------

	public void Connect() {
		IOSInAppPurchaseManager.instance.LoadStore();

		IOSInAppPurchaseManager.OnStoreKitInitComplete += IOS_OnStoreKitInitComplete;
		IOSInAppPurchaseManager.OnTransactionComplete  += IOS_OnTransactionComplete;
		IOSInAppPurchaseManager.OnRestoreComplete += IOS_OnRestoreComplete;
	}


	//--------------------------------------
	// Public Methods
	//--------------------------------------


	public override void Purchase(UM_InAppProduct product) {
		IOSInAppPurchaseManager.Instance.BuyProduct(product.IOSId);
	}

	public override void Subscribe(UM_InAppProduct product) {
		IOSInAppPurchaseManager.Instance.BuyProduct(product.IOSId);
	}
		


	public void RestorePurchases() {
		IOSInAppPurchaseManager.Instance.RestorePurchases();
	}





	//--------------------------------------
	// Event Handlers
	//--------------------------------------


	private void IOS_OnTransactionComplete (IOSStoreKitResult responce) {

		UM_InAppProduct p = UltimateMobileSettings.Instance.GetProductByIOSId(responce.ProductIdentifier);
		if(p != null) {
			UM_PurchaseResult r =  new UM_PurchaseResult();
			r.product = p;
			r.IOS_PurchaseInfo = responce;


			switch(r.IOS_PurchaseInfo.State) {
				case InAppPurchaseState.Purchased:
				case InAppPurchaseState.Restored:
					r.isSuccess = true;
					break;
				case InAppPurchaseState.Deferred:
				case InAppPurchaseState.Failed:
					r.isSuccess = false;
					break;
			}

			SendPurchaseFinishedEvent(r);
		} else {
			SendNoTemplateEvent();
		}


	}

	private void IOS_OnStoreKitInitComplete (ISN_Result res) {

		UM_BillingConnectionResult r =  new UM_BillingConnectionResult();
		_IsConnected = res.IsSucceeded;
		r.isSuccess = res.IsSucceeded;
		if(res.IsSucceeded) {
			r.message = "Inited";

			foreach(UM_InAppProduct product in UltimateMobileSettings.Instance.InAppProducts) {

				IOSProductTemplate tpl = IOSInAppPurchaseManager.instance.GetProductById(product.IOSId); 
				if(tpl != null) {
					product.SetTemplate(tpl);
				}

			}

			SendServiceConnectedEvent(r);
		} else {

			if(res.Error != null) {
				r.message = res.Error.Description;
			}

			SendServiceConnectedEvent(r);
		}

	}

	void IOS_OnRestoreComplete (IOSStoreKitRestoreResult res) {
		Debug.Log("IOS_OnRestoreComplete");

		UM_BaseResult result =  new UM_BaseResult();
		result.IsSucceeded = res.IsSucceeded;

		SendRestoreFinishedEvent(result);
	}	


}
