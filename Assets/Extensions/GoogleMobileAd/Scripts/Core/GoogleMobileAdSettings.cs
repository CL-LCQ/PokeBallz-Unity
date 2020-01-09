using UnityEngine;
using System.IO;
using System.Collections.Generic;


#if UNITY_EDITOR
using UnityEditor;
[InitializeOnLoad]
#endif

public class GoogleMobileAdSettings : ScriptableObject {

	public const string VERSION_NUMBER = "7.9";
	public const string PLAY_SERVICE_VERSION = "9.2.1";

	public string IOS_InterstisialsUnitId = string.Empty;
	public string IOS_BannersUnitId = string.Empty;
	public string IOS_RewardedVideoAdUnitId = string.Empty;

	public string Android_InterstisialsUnitId = string.Empty;
	public string Android_BannersUnitId = string.Empty;
	public string Android_RewardedVideoAdUnitId = string.Empty;

	public string WP8_InterstisialsUnitId = string.Empty;
	public string WP8_BannersUnitId = string.Empty;
	public string WP8_RewardedVideoAdUnitId = string.Empty;

	public bool IsIOSSettinsOpened = true;
	public bool IsAndroidSettinsOpened = true;
	public bool IsWP8SettinsOpened = true;

	public int EditorFillRate = 100;
	public int EditorFillRateIndex = 4;
	public bool IsEditorTestingEnabled = true;

	public bool IsTestSettinsOpened = false;

	public bool ShowActions = false;
	public bool KeepManifestClean = true;

	public bool TagForChildDirectedTreatment = false;


	[SerializeField]
	public List<GADTestDevice> testDevices =  new List<GADTestDevice>();

	public bool IsKeywordsOpened = false;
	public List<string> DefaultKeywords =  new List<string>();



	private const string ISNSettingsAssetName = "GoogleMobileAdSettings";
	private const string ISNSettingsAssetExtension = ".asset";

	private static GoogleMobileAdSettings instance = null;


	public static GoogleMobileAdSettings Instance {

		get {
			if (instance == null) {
				instance = Resources.Load(ISNSettingsAssetName) as GoogleMobileAdSettings;

				if (instance == null) {

					// If not found, autocreate the asset object.
					instance = CreateInstance<GoogleMobileAdSettings>();
					#if UNITY_EDITOR
					SA.Util.Files.CreateFolder(SA.Config.SettingsPath);



					string fullPath = Path.Combine(Path.Combine("Assets", SA.Config.SettingsPath),
					                               ISNSettingsAssetName + ISNSettingsAssetExtension
					                               );

					AssetDatabase.CreateAsset(instance, fullPath);
					#endif
				}
			}
			return instance;
		}
	}



	public void AddDevice(GADTestDevice p) {
		testDevices.Add(p);
	}

	public void RemoveDevice(GADTestDevice p) {
		testDevices.Remove(p);
	}


}
