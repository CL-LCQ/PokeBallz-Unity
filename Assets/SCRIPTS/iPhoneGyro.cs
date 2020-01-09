using UnityEngine;
using System.Collections;

public class iPhoneGyro : MonoBehaviour {


	bool gyroBool;
	Gyroscope gyro;
	Quaternion rotFix;
	Quaternion initOrientation;
	Vector3 eulerRotFix;

	// Use this for initialization
	void Start () {

		//GameObject originalParent = transform.parent.gameObject;
		GameObject camParent = new GameObject ("camParent");
		camParent.transform.position = transform.position;
		transform.parent = camParent.transform;
		//camParent.transform.parent = originalParent.transform.parent;



		gyroBool = Input.isGyroAvailable;


		if (gyroBool) {

			gyro = Input.gyro;
			gyro.enabled = true;

			//
			initOrientation = gyro.attitude;
			print("start" + initOrientation);
//
//			//
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				camParent.transform.eulerAngles = new Vector3(90,90,0);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				camParent.transform.eulerAngles = new Vector3(90,180,0);
			}
			//
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				rotFix = new Quaternion(0,0,0.7071f,0.7071f);
				eulerRotFix = new Vector3 (0, 0.7071f, 0.7071f);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				rotFix = new Quaternion(0,0,1,0);
				eulerRotFix = new Vector3 (0,1,0);
			}
	
		}
		else {
			print("NO GYRO");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (gyroBool) {
			//Quaternion camRot = gyro.attitude * rotFix;
			//transform.localRotation = camRot;
			Vector3 camRot = gyro.attitude.eulerAngles ;
			transform.eulerAngles = new Vector3(0,camRot.x,0);

		//	print( camRot );
		}


	
	}
}
