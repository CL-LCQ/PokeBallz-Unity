using UnityEngine;
using UnityEditor;
using System.Collections;

public class PluginsInstalationUtil : MonoBehaviour {
	
	
	public const string ANDROID_SOURCE_PATH       = "Plugins/StansAssets/Android/";
	public const string ANDROID_DESTANATION_PATH  = "Plugins/Android/";
	
	
	public const string IOS_SOURCE_PATH       = "Plugins/StansAssets/IOS/";
	public const string IOS_DESTANATION_PATH  = "Plugins/IOS/";
	
	
	
	
	
	public static void IOS_UpdatePlugin() {
		IOS_InstallPlugin(false);
	}
	
	public static void IOS_InstallPlugin(bool IsFirstInstall = true) {
		
		IOS_CleanUp();
		
		
		
		
		
		//IOS Native
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_Camera.mm.txt", 				PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_Camera.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_GameCenter.mm.txt", 			PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_GameCenter.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_iAd.mm.txt", 					PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_iAd.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_InApp.mm.txt", 					PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_InApp.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_Media.mm.txt", 					PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_Media.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_ReplayKit.mm.txt", 				PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_ReplayKit.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_GestureRecognizer.mm.txt", 		PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_GestureRecognizer.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_CloudKit.mm.txt", 				PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_CloudKit.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_NSData+Base64.h.txt", 			PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_NSData+Base64.h");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_NSData+Base64.m.txt", 			PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_NSData+Base64.m");
		
		
		IOS_Install_SocialPart();
		InstallGMAPart();
		
		
		
	}
	
	public static void InstallGMAPart() {
		//GMA
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "GMA_SA_Lib_Proxy.mm.txt", 	PluginsInstalationUtil.IOS_DESTANATION_PATH + "GMA_SA_Lib_Proxy.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "GMA_SA_Lib.h.txt", 	PluginsInstalationUtil.IOS_DESTANATION_PATH + "GMA_SA_Lib.h");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "GMA_SA_Lib.m.txt", 	PluginsInstalationUtil.IOS_DESTANATION_PATH + "GMA_SA_Lib.m");
		
	}
	
	
	public static void IOS_Install_SocialPart() {
		//IOS Native +  MSP
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_SocialGate.mm.txt", 	PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_SocialGate.mm");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_NativeCore.h.txt", 	PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_NativeCore.h");
		SA.Util.Files.CopyFile(PluginsInstalationUtil.IOS_SOURCE_PATH + "ISN_NativeCore.mm.txt", 	PluginsInstalationUtil.IOS_DESTANATION_PATH + "ISN_NativeCore.mm");
	}
	
	
	
	
	public static void Remove_FB_SDK_WithDialog() {
		bool result = EditorUtility.DisplayDialog(
			"Removing Facebook SDK",
			"Are you sure you want to remove Facebook OAuth API?",
			"Remove",
			"Cansel");
		
		if(result) {
			Remove_FB_SDK();
		}
	}
	public static void Remove_FB_SDK() {
		
		SA.Util.Files.DeleteFolder(PluginsInstalationUtil.ANDROID_DESTANATION_PATH + "facebook");
		SA.Util.Files.DeleteFolder("Plugins/facebook", false);
		SA.Util.Files.DeleteFolder("Facebook", false);
		SA.Util.Files.DeleteFolder("FacebookSDK", false);
		
		//MSP
		SA.Util.Files.DeleteFile("Extensions/MobileSocialPlugin/Example/Scripts/MSPFacebookUseExample.cs", false);
		SA.Util.Files.DeleteFile("Extensions/MobileSocialPlugin/Example/Scripts/MSP_FacebookAnalyticsExample.cs", false);
		SA.Util.Files.DeleteFile("Extensions/MobileSocialPlugin/Example/Scripts/MSP_FacebookAndroidTurnBasedAndGiftsExample.cs", false);
		
		//FB v7
		SA.Util.Files.DeleteFolder("Examples", false);
		SA.Util.Files.DeleteFolder(PluginsInstalationUtil.IOS_DESTANATION_PATH + "Facebook", false);
		
		
		SA.Util.Files.DeleteFolder(PluginsInstalationUtil.ANDROID_DESTANATION_PATH + "libs/bolts-android-1.2.0.jar");
		SA.Util.Files.DeleteFolder(PluginsInstalationUtil.ANDROID_DESTANATION_PATH + "libs/facebook-android-sdk-4.7.0.jar");
		SA.Util.Files.DeleteFolder(PluginsInstalationUtil.ANDROID_DESTANATION_PATH + "libs/facebook-android-wrapper-release.jar");
		
		AssetDatabase.Refresh();
	}
	
	
	private static string AN_SoomlaGrowContent = "Extensions/AndroidNative/Other/Soomla/AN_SoomlaGrow.cs";
	public static void DisableSoomlaFB() {
		ChnageDefineState(AN_SoomlaGrowContent, "FACEBOOK_ENABLED", false);
	}
	
	
	
	
	
	private static void ChnageDefineState(string file, string tag, bool IsEnabled) {
		
		if(!SA.Util.Files.IsFileExists(file)) {
			Debug.Log("ChnageDefineState for tag: " + tag + " File not found at path: " + file);
			return;
		}
		
		string content = SA.Util.Files.Read(file);
		
		int endlineIndex;
		endlineIndex = content.IndexOf(System.Environment.NewLine);
		if(endlineIndex == -1) {
			endlineIndex = content.IndexOf("\n");
		}
		
		string TagLine = content.Substring(0, endlineIndex);
		
		if(IsEnabled) {
			content 	= content.Replace(TagLine, "#define " + tag);
		} else {
			content 	= content.Replace(TagLine, "//#define " + tag);
		}
		
		SA.Util.Files.Write(file, content);
		
	}
	
	
	public static void IOS_CleanUp() {
		
		
		//Old APi
		RemoveIOSFile("AppEventListener");
		RemoveIOSFile("CloudManager");
		RemoveIOSFile("CustomBannerView");
		RemoveIOSFile("GameCenterManager");
		RemoveIOSFile("GCHelper");
		RemoveIOSFile("iAdBannerController");
		RemoveIOSFile("iAdBannerObject");
		RemoveIOSFile("InAppPurchaseManager");
		RemoveIOSFile("IOSGameCenterManager");
		RemoveIOSFile("IOSNativeNotificationCenter");
		RemoveIOSFile("IOSNativePopUpsManager");
		RemoveIOSFile("IOSNativeUtility");
		RemoveIOSFile("ISN_NSData+Base64");
		RemoveIOSFile("ISN_Reachability");
		RemoveIOSFile("ISNCamera");
		RemoveIOSFile("ISNDataConvertor");
		RemoveIOSFile("ISNSharedApplication");
		RemoveIOSFile("ISNVideo");
		RemoveIOSFile("PopUPDelegate");
		RemoveIOSFile("RatePopUPDelegate");
		RemoveIOSFile("SKProduct+LocalizedPrice");
		RemoveIOSFile("SocialGate");
		RemoveIOSFile("StoreProductView");
		RemoveIOSFile("TransactionServer");
		
		RemoveIOSFile("OneSignalUnityRuntime");
		RemoveIOSFile("OneSignal");
		RemoveIOSFile("libOneSignal");
		RemoveIOSFile("ISN_Security");
		RemoveIOSFile("ISN_NativeUtility");
		RemoveIOSFile("ISN_NativePopUpsManager");
		RemoveIOSFile("ISN_Media");
		RemoveIOSFile("ISN_GameCenterTBM");
		RemoveIOSFile("ISN_GameCenterRTM");
		RemoveIOSFile("ISN_GameCenterManager");
		RemoveIOSFile("ISN_GameCenterListner");
		RemoveIOSFile("IOSNativeNotificationCenter");
		
		
		
		//New API
		RemoveIOSFile("ISN_Camera");
		RemoveIOSFile("ISN_GameCenter");
		RemoveIOSFile("ISN_InApp");
		RemoveIOSFile("ISN_iAd");
		RemoveIOSFile("ISN_NativeCore");
		RemoveIOSFile("ISN_SocialGate");
		RemoveIOSFile("ISN_ReplayKit");
		RemoveIOSFile("ISN_CloudKit");
		RemoveIOSFile("ISN_Soomla");
		RemoveIOSFile("ISN_GestureRecognizer");
		
		
		
		//Google Ad old v1
		RemoveIOSFile("GADAdMobExtras");
		RemoveIOSFile("GADAdNetworkExtras");
		RemoveIOSFile("GADAdSize");
		RemoveIOSFile("GADBannerViewDelegate");
		RemoveIOSFile("GADInAppPurchase");
		RemoveIOSFile("GADInAppPurchaseDelegate");
		RemoveIOSFile("GADInterstitialDelegate");
		RemoveIOSFile("GADModules");
		RemoveIOSFile("GADRequest");
		RemoveIOSFile("GADRequestError");
		RemoveIOSFile("libGoogleAdMobAds");
		
		//Google Ad old v2
		RemoveIOSFile("GoogleMobileAdBanner");
		RemoveIOSFile("GoogleMobileAdController");
		
		
		//Google Ad new
		RemoveIOSFile("GMA_SA_Lib");
		
		
		//MSP old
		RemoveIOSFile("IOSInstaPlugin");
		RemoveIOSFile("IOSTwitterPlugin");
		RemoveIOSFile("MGInstagram");
		
		
		
		
		
	}
	
	
	public static void RemoveIOSFile(string filename) {
		SA.Util.Files.DeleteFile(IOS_DESTANATION_PATH + filename + ".h");
		SA.Util.Files.DeleteFile(IOS_DESTANATION_PATH + filename + ".m");
		SA.Util.Files.DeleteFile(IOS_DESTANATION_PATH + filename + ".mm");
		SA.Util.Files.DeleteFile(IOS_DESTANATION_PATH + filename + ".a");
	}
	
	
	public static void Android_UpdatePlugin() {
		Android_InstallPlugin(false);
	}
	
	
	
	public static void EnableGooglePlayAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/an_googleplay.jar.txt", 					ANDROID_DESTANATION_PATH + "libs/an_googleplay.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-base.jar.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-base.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-basement.jar.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-basement.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-ads.jar.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-ads.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-ads-lite.jar.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-ads-lite.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-games.jar.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-games.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-iid.jar.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-iid.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-gcm.jar.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-gcm.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-plus.jar.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-plus.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-appinvite.jar.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-appinvite.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-analytics.jar.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-analytics.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-analytics-impl.jar.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-analytics-impl.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-auth.jar.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-auth.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-auth-base.jar.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-auth-base.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-drive.jar.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-drive.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/an_googleplay.txt", 					ANDROID_DESTANATION_PATH + "libs/an_googleplay.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-base.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-base.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-basement.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-basement.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-ads.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-ads.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-ads-lite.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-ads-lite.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-games.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-games.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-iid.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-iid.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-gcm.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-gcm.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-plus.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-plus.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-appinvite.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-appinvite.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-analytics.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-analytics.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-analytics-impl.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-analytics-impl.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-auth.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-auth.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-auth-base.txt", 			ANDROID_DESTANATION_PATH + "libs/play-services-auth-base.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-drive.txt", 				ANDROID_DESTANATION_PATH + "libs/play-services-drive.aar");
		#endif
	}
	
	public static void DisableGooglePlayAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/an_googleplay.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-base.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-basement.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-ads.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-ads-lite.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-games.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-iid.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-gcm.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-plus.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-appinvite.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-analytics.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-analytics-impl.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-auth.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-auth-base.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-drive.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/an_googleplay.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-base.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-basement.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-ads.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-ads-lite.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-games.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-iid.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-gcm.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-plus.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-appinvite.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-analytics.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-analytics-impl.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-auth.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-auth-base.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-drive.aar");
		#endif
	}

	public static void EnableDriveAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-drive.jar.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-drive.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-drive.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-drive.aar");
		#endif
	}

	public static void DisableDriveAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-drive.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-drive.aar");
		#endif
	}

	public static void EnableOAuthAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-auth.jar.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-auth.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-auth-base.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-auth-base.aar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-auth.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-auth.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-auth-base.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-auth-base.aar");
		#endif
	}

	public static void DisableOAuthAPI(){
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-auth.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-auth-base.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-auth.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-auth-base.aar");
		#endif
	}

	public static void EnableAnalyticsAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-analytics.jar.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-analytics.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-analytics-impl.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-analytics-impl.aar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-analytics.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-analytics.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-analytics-impl.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-analytics-impl.aar");
		#endif
	}

	public static void DisableAnalyticsAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-analytics.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-analytics-impl.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-analytics.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-analytics-impl.aar");
		#endif
	}

	public static void EnableAppInvitesAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-appinvite.jar.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-appinvite.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-appinvite.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-appinvite.aar");
		#endif
	}

	public static void DisableAppInvitesAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-appinvite.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-appinvite.aar");
		#endif
	}

	public static void EnableGooglePlusAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-plus.jar.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-plus.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-plus.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-plus.aar");
		#endif
	}

	public static void DisableGooglePlusAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-plus.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-plus.aar");
		#endif
	}

	public static void EnablePushNotificationsAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-iid.jar.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-iid.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-gcm.jar.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-gcm.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-iid.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-iid.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-gcm.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-gcm.aar");
		#endif
	}

	public static void DisablePushNotificationsAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-iid.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-gcm.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-iid.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-gcm.aar");
		#endif
	}

	public static void EnableGoogleAdMobAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-ads.jar.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-ads.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-ads-lite.jar.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-ads-lite.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-ads.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-ads.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-ads-lite.txt", 	ANDROID_DESTANATION_PATH + "libs/play-services-ads-lite.aar");
		#endif
	}

	public static void DisableGoogleAdMobAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-ads.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-ads-lite.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-ads.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-ads-lite.aar");
		#endif
	}

	public static void EnableGooglePlayServicesAPI () {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-games.jar.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-games.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "google_play/play-services-games.txt", 		ANDROID_DESTANATION_PATH + "libs/play-services-games.aar");
		#endif
	}

	public static void DisableGooglePlayServicesAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-games.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/play-services-games.aar");
		#endif
	}
	
	public static void EnableAndroidCampainAPI() {
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "libs/sa_analytics.txt", 	ANDROID_DESTANATION_PATH + "libs/sa_analytics.jar");
	}
	
	
	public static void DisableAndroidCampainAPI() {
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/sa_analytics.jar");
	}
	
	
	public static void EnableAppLicensingAPI() {
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "app_licensing/an_licensing_library.txt", 	ANDROID_DESTANATION_PATH + "libs/an_licensing_library.jar");
	}
	
	
	public static void DisableAppLicensingAPI() {
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/an_licensing_library.jar");
	}
	
	
	public static void EnableSoomlaAPI() {
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "libs/an_sa_soomla.txt", 	ANDROID_DESTANATION_PATH + "libs/an_sa_soomla.jar");
	}
	
	
	public static void DisableSoomlaAPI() {
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/an_sa_soomla.jar");
	}
	
	
	
	public static void EnableBillingAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "billing/an_billing.jar.txt", 	ANDROID_DESTANATION_PATH + "libs/an_billing.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "billing/an_billing.txt", 	ANDROID_DESTANATION_PATH + "libs/an_billing.aar");
		#endif
	}
	
	public static void DisableBillingAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/an_billing.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/an_billing.aar");
		#endif
	}
	
	
	
	
	public static void EnableSocialAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "social/an_social.jar.txt", 	ANDROID_DESTANATION_PATH + "libs/an_social.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "social/twitter4j-core-4.0.4.txt", 	ANDROID_DESTANATION_PATH + "libs/twitter4j-core-4.0.4.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "social/an_social.txt", 	ANDROID_DESTANATION_PATH + "libs/an_social.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "social/twitter4j-core-4.0.4.txt", 	ANDROID_DESTANATION_PATH + "libs/twitter4j-core-4.0.4.jar");
		#endif
	}
	
	public static void DisableSocialAPI() {
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/an_social.jar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/twitter4j-core-4.0.4.jar");
		#else
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/an_social.aar");
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/twitter4j-core-4.0.4.jar");
		#endif
	}
	
	
	
	
	
	
	public static void EnableCameraAPI() {
		//Unity 5 upgdare:
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "libs/image-chooser-library-1.6.0.txt", 	ANDROID_DESTANATION_PATH + "libs/image-chooser-library-1.6.0.jar");
	}
	
	public static void DisableCameraAPI() {
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/image-chooser-library-1.6.0.jar");
	}
	
	
	
	
	
	public static void Android_InstallPlugin(bool IsFirstInstall = true) {
		
		
		//Unity 5 upgdare:
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "libs/httpclient-4.3.1.jar");
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "libs/signpost-commonshttp4-1.2.1.2.jar");
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "libs/signpost-core-1.2.1.2.jar");
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "libs/libGoogleAnalyticsServices.jar");

		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "libs/android-support-v4.jar");

		//Remove previous Image Chooser Library version
		SA.Util.Files.DeleteFile(ANDROID_DESTANATION_PATH + "libs/image-chooser-library-1.3.0.jar");
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "libs/image-chooser-library-1.6.0.jar");

		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "libs/twitter4j-core-3.0.5.jar");
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "libs/google-play-services.jar");
		
		
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "social/an_social.jar");
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "social/twitter4j-core-3.0.5.jar");
		
		
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "google_play/an_googleplay.jar");
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "google_play/google-play-services.jar");
		
		SA.Util.Files.DeleteFile(ANDROID_SOURCE_PATH + "billing/an_billing.jar");
		
		#if UNITY_4_6 || UNITY_4_7
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "libs/android-support-v4.txt", 	ANDROID_DESTANATION_PATH + "libs/android-support-v4.jar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "androidnative.jar.txt", 	        	ANDROID_DESTANATION_PATH + "androidnative.jar");
		#else
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "libs/support-v4-23.4.0.txt", 	ANDROID_DESTANATION_PATH + "libs/support-v4-23.4.0.aar");
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "androidnative.txt", 	        	ANDROID_DESTANATION_PATH + "androidnative.aar");
		#endif

		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "sa_analytics.txt", 	        	ANDROID_DESTANATION_PATH + "sa_analytics.jar");

#if UNITY_4_6 || UNITY_4_7
        SA.Util.Files.CopyFile (ANDROID_SOURCE_PATH + "mobile-native-popups.jar.txt",             ANDROID_DESTANATION_PATH + "mobile-native-popups.jar");
#else
        SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + "mobile-native-popups.txt", ANDROID_DESTANATION_PATH + "mobile-native-popups.aar");
#endif
        SA.Util.Files.DeleteFile (ANDROID_SOURCE_PATH + "mobilenativepopups.txt");
		SA.Util.Files.DeleteFile (ANDROID_DESTANATION_PATH + "mobilenativepopups.jar");
		
		SA.Util.Files.CopyFolder(ANDROID_SOURCE_PATH + "facebook", 			ANDROID_DESTANATION_PATH + "facebook");
		
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_5 || UNITY_4_6
		
#else
		SA.Util.Files.DeleteFolder(ANDROID_SOURCE_PATH + "facebook");
#endif
		
		if(IsFirstInstall) {
			EnableBillingAPI();
			EnableGooglePlayAPI();
			EnableSocialAPI();
			EnableCameraAPI();
			EnableAppLicensingAPI();
		}
		
		
		
		
		string file;
		file = "AN_Res/res/values/analytics.xml";
		if(!SA.Util.Files.IsFileExists(ANDROID_DESTANATION_PATH + file)) {
			SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + file, 	ANDROID_DESTANATION_PATH + file);
		}
		
		
		file = "AN_Res/res/values/ids.xml";
		if(!SA.Util.Files.IsFileExists(ANDROID_DESTANATION_PATH + file)) {
			SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + file, 	ANDROID_DESTANATION_PATH + file);
		}
		
		file = "AN_Res/res/xml/file_paths.xml";
		if(!SA.Util.Files.IsFileExists(ANDROID_DESTANATION_PATH + file)) {
			SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + file, 	ANDROID_DESTANATION_PATH + file);
		}
		
		
		file = "AN_Res/res/values/version.xml";
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + file, 	ANDROID_DESTANATION_PATH + file);
		
		file = "AN_Res/project.properties";
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + file, 	ANDROID_DESTANATION_PATH + file);
		
		file = "AN_Res/AndroidManifest";
		SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + file + ".txt", 	ANDROID_DESTANATION_PATH + file + ".xml");
		
		//First install dependense		
		
		file = "AndroidManifest";
		if(!SA.Util.Files.IsFileExists(ANDROID_DESTANATION_PATH + file)) {
			SA.Util.Files.CopyFile(ANDROID_SOURCE_PATH + file + ".txt", 	ANDROID_DESTANATION_PATH + file + ".xml");
		} 
		
		AssetDatabase.Refresh();
		
	}
	
	
	
	public static bool IsFacebookInstalled {
		get {
			return SA.Util.Files.IsFileExists("Facebook/Scripts/FB.cs")
				|| SA.Util.Files.IsFileExists("FacebookSDK/SDK/Scripts/FB.cs")
				|| SA.Util.Files.IsFileExists("FacebookSDK/Plugins/Facebook.Unity.dll");
		}
	}
	
	
}
