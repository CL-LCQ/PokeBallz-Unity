using UnityEngine;
using System.Collections;

public class ImmersiveMode : SA.Pattern.Singleton<ImmersiveMode> {


	void Awake() {
		DontDestroyOnLoad(gameObject);
	}


	public void EnableImmersiveMode()  {
		AN_ImmersiveModeProxy.enableImmersiveMode();
	}
	

}
