using UnityEngine;
using System.Collections;

public class kalmanFilter : MonoBehaviour {


		
	private static float Q = 0.000001f;

	private static float R = 0.01f;

	private static float P = 1f, X = 0f, K;



		private static void measurementUpdate()

		{
			
			K = (P + Q) / (P + Q + R);

			P = R * (P + Q) / (R + P + Q);
		
		}



	public static float update(float measurement)

		{
			
			measurementUpdate();

		float result = X + (measurement - X) * K;

			X = result;

			return result;

		}

}
