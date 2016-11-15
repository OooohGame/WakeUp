using UnityEngine;

public class SceneSingleton<T> : MonoBehaviour where T :Component
{
	static T _instance;

	public static T Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<T> ();
				if (_instance == null) {
					GameObject obj = new GameObject ();
					obj.hideFlags = HideFlags.HideAndDontSave;
					_instance = obj.GetComponent<T> () as T;
				}
			}
			return _instance;
		}
	}
}