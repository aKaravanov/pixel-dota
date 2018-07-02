using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController player;

	private Vector3 lastPosition;
	private float displacement;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		lastPosition = player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		displacement = player.transform.position.x - lastPosition.x;
		transform.position = new Vector3 (transform.position.x + displacement, transform.position.y, transform.position.z);
		lastPosition = player.transform.position;

	}
}
