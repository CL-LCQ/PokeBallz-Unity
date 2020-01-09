
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;

public class AMN_PostProcess  {

	#if UNITY_ANDROID
	[PostProcessBuild(48)]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {

		string file = PluginsInstalationUtil.ANDROID_DESTANATION_PATH + "AndroidManifest.xml";
		string Manifest = SA.Util.Files.Read(file);
		Manifest = Manifest.Replace("%APP_BUNDLE_ID%", PlayerSettings.bundleIdentifier);
		SA.Util.Files.Write(file, Manifest);
		Debug.Log("AMN Post Process Done");

	}
	#endif

}
