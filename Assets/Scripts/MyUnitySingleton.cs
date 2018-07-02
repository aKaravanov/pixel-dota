using UnityEngine; 
using System.Collections; 

public class MyUnitySingleton : MonoBehaviour { 
private static MyUnitySingleton instance = null; 
public static MyUnitySingleton Instance { 
	get { return instance; } 
}
	public GameObject heroPick;
	void Awake() { 
		if (instance != null && instance != this) { 
			Destroy(this.gameObject); return; 
		} else { instance = this; }
		FindObjectOfType<AudioSource> ().volume = PlayerPrefs.GetFloat ("Volume");
			DontDestroyOnLoad(this.gameObject); 
	} // any other methods you need 
} 
