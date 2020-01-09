using UnityEngine;
using System;
using System.Collections;

namespace SA.Util {


	public static class Screen  {

		public static void TakeScreenshot(Action<Texture2D> callback) {
			var maker = SA.Models.ScreenshotMaker.Create();
			maker.OnScreenshotReady += callback;
			maker.GetScreenshot();
		}


	}

}

