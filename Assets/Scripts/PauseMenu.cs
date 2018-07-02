using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;
	public GameObject pauseMenu;
	public GameObject settingScreen;

	public GameObject waitTime;
	public Text waitTimeText;

	private bool paused = false;
	private bool inSet = false;


	public void RestartButton(){
		FindObjectOfType<PlayerController> ().inGame = true;
		FindObjectOfType<GameManager> ().restartGame ();
		FindObjectOfType<GameManager> ().Reset ();
	}

	public void pauseTheGame(){
		Time.timeScale = 0f;
		paused = true;
		if (!inSet) {
			pauseMenu.SetActive (true);
		}
	}

	public void resume(){
		if (inSet) {
			settingScreen.SetActive (false);
			pauseMenu.SetActive (true);
			inSet = false;
		} else {
			StartCoroutine (continueCo ());
			pauseMenu.SetActive (false);
		}
	}

	public void BackToMain(){
		Application.LoadLevel (mainMenu);
	}

	public void openSettings(){
		pauseMenu.SetActive (false);
		settingScreen.SetActive (true);
		inSet = true;
	}

	public bool isPaused(){
		return paused;
	}

	public bool isSet(){
		return inSet;
	}

	public void closeSettings(){
		pauseMenu.SetActive (true);
		settingScreen.SetActive (false);
		inSet = false;
	}

	IEnumerator continueCo(){
		waitTime.SetActive (true);
		waitTimeText.text = "3";
		yield return new WaitForSecondsRealtime (0.5f);
		waitTimeText.text = "2";
		yield return new WaitForSecondsRealtime (0.5f);
		waitTimeText.text = "1";
		yield return new WaitForSecondsRealtime (0.5f);
		waitTime.SetActive (false);
		Time.timeScale = 1f;
		paused = false;
	}
}
