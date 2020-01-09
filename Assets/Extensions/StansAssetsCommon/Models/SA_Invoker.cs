using UnityEngine;
using System;
using System.Collections;


namespace SA.Models {

	public class Invoker : MonoBehaviour {

		private Action _callback;

		public static Invoker Create() {
			return  new GameObject("Invoker").AddComponent<Invoker>();
		}

		public void StartInvoke(Action callback, float time) {
			_callback = callback;
			Invoke("TimeOut", time);
		}


		void TimeOut() {
			if(_callback != null) {
				_callback();
			}

			Destroy(gameObject);
		}
	}

}
