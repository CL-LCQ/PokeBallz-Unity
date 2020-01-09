using UnityEngine;
using System.Collections;
using StansAssets.Animation;




public static class SA_TweenExtensions  {


	public static void MoveTo(this GameObject go, Vector3 position, float time, SA_EaseType easeType = SA_EaseType.linear, System.Action OnCompleteAction = null ) {
		SA_ValuesTween tw = go.AddComponent<SA_ValuesTween>();

		tw.DestoryGameObjectOnComplete = false;
		tw.VectorTo(go.transform.position, position, time, easeType);

		tw.OnComplete += OnCompleteAction;
	}


	public static void ScaleTo(this GameObject go, Vector3 scale, float time, SA_EaseType easeType = SA_EaseType.linear, System.Action OnCompleteAction = null ) {
		SA_ValuesTween tw = go.AddComponent<SA_ValuesTween>();

		tw.DestoryGameObjectOnComplete = false;
		tw.ScaleTo(go.transform.localScale, scale, time, easeType);

		tw.OnComplete += OnCompleteAction;
	}

}
