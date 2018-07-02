using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float speedMult;
	private float speedStore;

	public float speedIncreaseMilestone;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;
	private float speedIncreaseMilestoneStore;

	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	public bool onGround;

	public LayerMask ground;

	public Transform groundCheck;
	public float grounCheckRadius;
	public GameManager theGameManager;

	public int muliplier;

	private bool stoppedJumping;
	public bool inGame;

	private ScoreManager scoreManager;
	// private Collider2D heroCollider;

	private Rigidbody2D hero;

	public bool isDead;

	private Vector2 position;

	// Use this for initialization
	void Start () {
		theGameManager = FindObjectOfType<GameManager> ();
		Time.timeScale = 1f;
		hero = GetComponent<Rigidbody2D>();
		// heroCollider = GetComponent<Collider2D> ();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
		speedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		muliplier = 1;
		scoreManager = FindObjectOfType<ScoreManager> ();
		stoppedJumping = true;
	}

	// Update is called once per frame
	void Update () {
			if (!theGameManager.touchSupported) {
				if (inGame) {
					escButton ();
					onGround = Physics2D.OverlapCircle (groundCheck.position, grounCheckRadius, ground);
					if (transform.position.x > speedMilestoneCount) {
						speedMilestoneCount += speedIncreaseMilestone;
						speedIncreaseMilestone = speedIncreaseMilestone * speedMult;
						moveSpeed = moveSpeed * speedMult;
						muliplier += 1;
					}
					hero.velocity = new Vector2 (moveSpeed, hero.velocity.y);
					if (Input.GetKeyDown (KeyCode.Space)) {
						if (onGround) {
							hero.velocity = new Vector2 (hero.velocity.x, jumpForce);
							stoppedJumping = false;
						}
					}
					if (Input.GetKey (KeyCode.Space) && !stoppedJumping) {
						if (jumpTimeCounter > 0) {
							hero.velocity = new Vector2 (hero.velocity.x, jumpForce);
							jumpTimeCounter -= Time.deltaTime;
						}
					}
					if (Input.GetKeyUp (KeyCode.Space)) {
						jumpTimeCounter = 0;
						stoppedJumping = true;
					}
					if (onGround) {
						jumpTimeCounter = jumpTime;
					}
					if (Input.GetKeyDown (KeyCode.R) && !FindObjectOfType<PauseMenu> ().isPaused ()) {
						theGameManager.restartGame ();
						theGameManager.Reset ();
					}
				} else {
					if (isDead && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.R))) {
						theGameManager.deathScreen.gameObject.SetActive (false);
						theGameManager.Reset ();
					} else if (Input.GetKeyDown (KeyCode.Space)) {
						theGameManager.startGame ();
					} else {
						escButton ();
					}
				}
			} else {
				if (inGame) {
					onGround = Physics2D.OverlapCircle (groundCheck.position, grounCheckRadius, ground);
					if (transform.position.x > speedMilestoneCount) {
						speedMilestoneCount += speedIncreaseMilestone;
						speedIncreaseMilestone = speedIncreaseMilestone * speedMult;
						moveSpeed = moveSpeed * speedMult;
						muliplier += 1;
					}
					hero.velocity = new Vector2 (moveSpeed, hero.velocity.y);
					if (Input.GetTouch (0).phase == TouchPhase.Began) {
						if (onGround) {
							hero.velocity = new Vector2 (hero.velocity.x, jumpForce);
							stoppedJumping = false;
						}
					}
					if (Input.GetTouch (0).phase == TouchPhase.Stationary && !stoppedJumping) {
						if (jumpTimeCounter > 0) {
							hero.velocity = new Vector2 (hero.velocity.x, jumpForce);
							jumpTimeCounter -= Time.deltaTime;
						}
					}
					if (Input.GetTouch (0).phase == TouchPhase.Ended) {
						jumpTimeCounter = 0;
						stoppedJumping = true;
					}
					if (onGround) {
						jumpTimeCounter = jumpTime;
					}
				} else if (Input.GetTouch (0).phase == TouchPhase.Began) {
					theGameManager.startGame ();
				}
			}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "KillBox") {
			inGame = false;
			isDead = true;
			theGameManager.restartGame ();
			moveSpeed = speedStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			speedMilestoneCount = speedMilestoneCountStore;
		}
	}

	private bool getDeath(){
		return isDead;
	}

	private void escButton(){
		if (Input.GetKeyDown (KeyCode.Escape) && !isDead) {
			if (!FindObjectOfType<PauseMenu> ().isPaused ()) {
				FindObjectOfType<PauseMenu> ().pauseTheGame ();
			} else {
				FindObjectOfType<PauseMenu> ().resume ();
			}
		}
	}
}
