using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;

	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		scoreIncreasing = false;	
		scoreText.text = "Score: 0";
		highScoreCount = 0;
		if (PlayerPrefs.HasKey("HighScore")) {
			highScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}
		highScoreText.text = "High Score: " + Mathf.Round (highScoreCount);

	}
	
	// Update is called once per frame
	void Update () {
		if (scoreIncreasing) {
			scoreCount += thePlayer.muliplier * pointsPerSecond * Time.deltaTime;
			if (scoreCount > highScoreCount) {
					highScoreCount = scoreCount;
					PlayerPrefs.SetFloat ("HighScore", highScoreCount);
			}
			scoreText.text = "Score: " + Mathf.Round (scoreCount);
			highScoreText.text = "High Score: " + Mathf.Round (highScoreCount);
		}
	}

	public void AddScore(int pointsToAdd){
		scoreCount += thePlayer.muliplier * pointsToAdd;
	}
}
