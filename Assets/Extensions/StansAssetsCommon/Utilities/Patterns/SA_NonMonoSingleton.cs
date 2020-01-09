////////////////////////////////////////////////////////////////////////////////
//  
// @module Common Android Native Lib
// @author Osipov Stanislav (Stan's Assets) 
// @support stans.assets@gmail.com 
//
////////////////////////////////////////////////////////////////////////////////

namespace SA.Pattern {

	public abstract class NonMonoSingleton<T>  where T : NonMonoSingleton<T>, new() {

		private static T _Instance = null;
		
		public static T Instance {
			get {
				if (_Instance == null) {
					_Instance = new T();
				}

				return _Instance;
			}

		}
	}
}
