using UnityEngine;
using System;
using System.Collections;

namespace SA.Util {

	public static class General {


		public static void Invoke(float time, Action callback) {

			var i = SA.Models.Invoker.Create();
			i.StartInvoke(callback, time);
		}


		public static T ParseEnum<T>(string value) {
			try {
				T val = (T) Enum.Parse(typeof(T), value, true);
				return val;
			} catch(Exception ex) {
				Debug.LogWarning("Enum Parsing failed: " + ex.Message);
				return default(T);
			}
		}

	}

}
