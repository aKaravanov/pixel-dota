using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

	public string mainMenu;

	public void restartGame(){
		this.gameObject.SetActive (false);
		FindObjectOfType<GameManager>().Reset ();
	}

	public void quitMain(){
		Application.LoadLevel (mainMenu);
	}
}
