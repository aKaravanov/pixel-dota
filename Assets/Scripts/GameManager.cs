using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGen;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	private ScoreManager scoreManager;

	public DeathMenu deathScreen;

	public bool touchSupported;


	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		thePlayer.transform.position = new Vector3 (-6.72f, -2.587902f, 0);
		thePlayer.theGameManager = this;
		thePlayer.isDead = false;
		thePlayer.inGame = false;
		touchSupported = Input.touchSupported;
		platformStartPoint = platformGen.position;
		playerStartPoint = thePlayer.transform.position;
		scoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restartGame(){
		if (!thePlayer.inGame) {
			deathScreen.gameObject.SetActive (true);
		}
		thePlayer.gameObject.SetActive (false);
		StartCoroutine ("PauseGameCo");
	}

	public void startGame(){
		StartCoroutine ("StartGameCo");
	}

	public void pauseGame(){
		StartCoroutine ("PauseGameCo");
	}

	public void resumeGame(){
		StartCoroutine ("ResumeGameCo");
	}

	public void Reset(){
		platformList = FindObjectsOfType<PlatformDestroyer>();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		platformGen.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);
		thePlayer.muliplier = 1;
		thePlayer.isDead = false;
		scoreManager.scoreText.text = "Score: 0";
		pauseGame ();
	}

	public IEnumerator StartGameCo(){
		scoreManager.scoreCount = 0;
		resumeGame ();
		yield return new WaitForSeconds (0.0f);
	}

	public IEnumerator PauseGameCo(){
		thePlayer.inGame = false;
		scoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.0f);
	}

	public IEnumerator ResumeGameCo(){
		thePlayer.inGame = true;
		scoreManager.scoreIncreasing = true;
		yield return new WaitForSeconds (0.0f);
	}

	void Awake(){
		Instantiate (FindObjectOfType<MyUnitySingleton> ().heroPick);
		//DontDestroyOnLoad (this);
	}
}
