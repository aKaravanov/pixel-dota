using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
	
	public GameObject settingMenu;

	public Scrollbar musicScrollBar;

	public Text placeholder;

	void Start(){
		if (PlayerPrefs.HasKey ("Volume")) {
			musicScrollBar.value = PlayerPrefs.GetFloat ("Volume");
			placeholder.text = "" + Mathf.Round(PlayerPrefs.GetFloat ("Volume") * 100);
		}
	}

	void Update(){
		//Debug.Log ("Get " + PlayerPrefs.GetFloat ("Volume"));
		musicScrollBar.value = PlayerPrefs.GetFloat ("Volume");
		placeholder.text = "" + Mathf.Round(PlayerPrefs.GetFloat ("Volume") * 100);
		//Debug.Log ("musicScrollBar " + musicScrollBar.value);
		//musNumber.text = "" + (PlayerPrefs.GetFloat ("Volume") * 100);
	}

	public void continueGame(){
		Time.timeScale = 1f;
		settingMenu.SetActive (false);
		FindObjectOfType<PauseMenu> ().gameObject.SetActive (true);
	}

	public void changeVolume(float volume){
		FindObjectOfType<AudioSource> ().volume = volume;
		PlayerPrefs.SetFloat ("Volume", volume);
	}

	public void changeVolumeText(string volume){
		float vol = float.Parse (volume);
		vol = vol / 100;
		Debug.Log ("Set " + vol);
		if (vol > 1) {
			volume = "100";
			vol = 1f;
		}
		if (vol < 0){
			vol = 0f;
			volume = "0";
		}
		FindObjectOfType<AudioSource> ().volume = vol;
		PlayerPrefs.SetFloat ("Volume", vol);
		Debug.Log ("Set " + PlayerPrefs.GetFloat ("Volume"));
	}
}
