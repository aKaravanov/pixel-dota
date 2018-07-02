using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public Settings settingsMenu;
	public HeroPick heropick;

    public void QuitGame()
    {
        Application.Quit();  
    }

    public void PlayGame() {
		this.gameObject.SetActive (false);
		heropick.gameObject.SetActive (true);
    }

	public void openSettings(){
		this.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (true);
	}

	public void closeSettings(){
		settingsMenu.gameObject.SetActive (false);
		this.gameObject.SetActive (true);
	}
}
