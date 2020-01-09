using UnityEngine;
using System.Collections;

public class gyroCam : MonoBehaviour {

	private double _lastCompassUpdateTime = 0;
	private Quaternion _correction = Quaternion.identity;
	private Quaternion _targetCorrection = Quaternion.identity;
	private Quaternion _compassOrientation = Quaternion.identity;

//	private float initialOrientationX;
//	private float initialOrientationY;
//	private float initialOrientationZ;

	// Use this for initialization
	void Start () {

		Input.gyro.enabled = true;
		Input.compass.enabled = true;

//		initialOrientationX = Input.gyro.rotationRateUnbiased.x;
//		initialOrientationY = Input.gyro.rotationRateUnbiased.y;
//		initialOrientationZ = -Input.gyro.rotationRateUnbiased.z;
	
		print (Input.gyro.attitude);
	}
	
	// Update is called once per frame
	void Update () {
		///test 01//
//		float x = Input.gyro.rotationRateUnbiased.x;
//		float y = Input.gyro.rotationRateUnbiased.y;
//		float z = Input.gyro.rotationRateUnbiased.z;

		//float x = Mathf.Round(kalmanFilter.update(Input.gyro.rotationRateUnbiased.x);

//		float rawX = Input.gyro.rotationRateUnbiased.x;
//		float x = Mathf.Round(kalmanFilter.update(rawX));
//
//		float rawY = Input.gyro.rotationRateUnbiased.y;
//		float y = Mathf.Round(kalmanFilter.update(rawY));
//
//
//		transform.Rotate (initialOrientationX -x, initialOrientationY -y,0);
		//print ("x:" + x + "y:" + y + "z:" + z);

		//test 02//
		// The gyro is very effective for high frequency movements, but drifts its
		// orientation over longer periods, so we want to use the compass to correct it.
		// The iPad's compass has low time resolution, however, so we let the gyro be
		// mostly in charge here.

		// First we take the gyro's orientation and make a change of basis so it better
		// represents the orientation we'd like it to have
		//Quaternion gyroOrientation = Quaternion.Euler (90, 0, 0) * Input.gyro.attitude * Quaternion.Euler(0, 0, 90);
		Quaternion gyroOrientation = Quaternion.Euler (45, 0, 0) * Input.gyro.attitude * Quaternion.Euler(0, 0, 0);

		// See if the compass has new data
		if (Input.compass.timestamp > _lastCompassUpdateTime)
		{
			_lastCompassUpdateTime = Input.compass.timestamp;

			// Work out an orientation based primarily on the compass
			Vector3 gravity = Input.gyro.gravity.normalized;
			Vector3 flatNorth = Input.compass.rawVector -
				Vector3.Dot(gravity, Input.compass.rawVector) * gravity;
			_compassOrientation = Quaternion.Euler (180, 0, 0) * Quaternion.Inverse(Quaternion.LookRotation(flatNorth, -gravity)) * Quaternion.Euler (0, 0, 90);

			// Calculate the target correction factor
			_targetCorrection = _compassOrientation * Quaternion.Inverse(gyroOrientation);
		}

		// Jump straight to the target correction if it's a long way; otherwise, slerp towards it very slowly
		if (Quaternion.Angle(_correction, _targetCorrection) > 45)
			_correction = _targetCorrection;
		else
			_correction = Quaternion.Slerp(_correction, _targetCorrection, 0.02f);

		// Easy bit :)
		transform.rotation = _correction * gyroOrientation;



	}
}
