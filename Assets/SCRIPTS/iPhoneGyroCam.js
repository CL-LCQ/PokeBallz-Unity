

private var gyroBool : boolean;
private var gyro : Gyroscope;
private var rotFix : Quaternion;
private var initialOrientation :  Quaternion; 

function Start() {
	
	var originalParent = transform.parent; // check if this transform has a parent
	var camParent = new GameObject ("camParent"); // make a new parent
	camParent.transform.position = transform.position; // move the new parent to this transform position
	transform.parent = camParent.transform; // make this transform a child of the new parent
	camParent.transform.parent = originalParent; // make the new parent a child of the original parent


	
	gyroBool = Input.isGyroAvailable;
	
	if (gyroBool) {
		
		gyro = Input.gyro;
		gyro.enabled = true;

		//
		initialOrientation = Quaternion.Inverse(gyro.attitude);
		print("start" + initialOrientation);

		//
		if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
			camParent.transform.eulerAngles = Vector3(90,90,0);
		} else if (Screen.orientation == ScreenOrientation.Portrait) {
			camParent.transform.eulerAngles = Vector3(90,180,0);
		}
		//
		if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
			rotFix = Quaternion(0,0,0.7071,0.7071);
		} else if (Screen.orientation == ScreenOrientation.Portrait) {
			rotFix = Quaternion(0,0,1,0);
		}
		//Screen.sleepTimeout = 0;
	} else {
		print("NO GYRO");
	}
}

function Update () {

//substract the initial angle to 
	if (gyroBool) {
		var camRot : Quaternion = gyro.attitude * rotFix;
				transform.localRotation = camRot;

	//var deltaQ = Input.gyro.attitude * initialOrientation;
	//transform.localRotation = Quaternion.Euler(-deltaQ.eulerAngles.y, -deltaQ.eulerAngles.z, deltaQ.eulerAngles.x);

	}
}
