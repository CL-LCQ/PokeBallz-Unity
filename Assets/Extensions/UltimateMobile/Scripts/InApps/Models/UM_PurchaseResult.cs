using UnityEngine;
using System.Collections;

public class UM_PurchaseResult  {
	
	public bool isSuccess =  false;
	public UM_InAppProduct product =  new UM_InAppProduct();

	private int _ResponceCode = -1;

	public GooglePurchaseTemplate Google_PurchaseInfo = null;
	public IOSStoreKitResult IOS_PurchaseInfo = null;
	public WP8PurchseResponce WP8_PurchaseInfo = null;
	public AMN_PurchaseResponse Amazon_PurchaseInfo = null;




	
	public void SetResponceCode(int code) {
		_ResponceCode = code;
	}
	
	public string TransactionId {
		get {
			switch(Application.platform) {
			case RuntimePlatform.Android:
				if (UltimateMobileSettings.Instance.PlatformEngine == UM_PlatformDependencies.Amazon) {
					return Amazon_PurchaseInfo.ReceiptId;
				} else {
					return Google_PurchaseInfo.OrderId;
				}
			case RuntimePlatform.IPhonePlayer:
				return IOS_PurchaseInfo.TransactionIdentifier;
			case RuntimePlatform.WP8Player:
				return WP8_PurchaseInfo.TransactionId;
			default:
				return string.Empty;
			}
				
		}
	}
	
	public int ResponceCode {
		get {
			return _ResponceCode;
		}
	}
}
