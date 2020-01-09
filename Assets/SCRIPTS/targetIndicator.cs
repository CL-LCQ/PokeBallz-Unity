using UnityEngine;
using System.Collections;

public class targetIndicator : MonoBehaviour {
	public GameObject rightMarker;

	// Use this for initialization
	void Start () {
	
		//rightMarker.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
//		print (transform.eulerAngles.y);

		if (GameObject.Find ("target2D(Clone)") != null) {
			GameObject target = GameObject.Find ("target2D(Clone)");
			Vector3 targetPos = target.transform.position;
			transform.LookAt (targetPos);

//			if (transform.eulerAngles.y < 50.0f) {
//				rightMarker.SetActive (true);
//			} else {
//				rightMarker.SetActive (false);
//			}
//			if (transform.eulerAngles.x > -50.0f) {
//				transform.eulerAngles = new Vector3 (-50.0f, transform.localEulerAngles.y, transform.localEulerAngles.z);
//			}
		}

	
	}
}
