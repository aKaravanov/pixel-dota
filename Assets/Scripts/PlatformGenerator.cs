using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public Transform generationPoint;
	public float dBetween;

	private float[] pWidth;

	public float dBetweenMin;
	public float dBetweenMax;

	private int pNumber;

	public ObjectPuller[] theObjectPool;

	private float minH;
	public Transform maxHP;
	private float maxH;
	public float maxDH;

	private float heightChange;

	private CoinGenarator theCoinGenerator;
	public float randomProbability;

	private int numberOfBlocks;
	private int pastNumber;


	// Use this for initialization
	void Start () {

		// pWidth = platform.GetComponent<BoxCollider2D> ().size.x;
		pWidth = new float[theObjectPool.Length];
		for (int i = 0; i < theObjectPool.Length; i++) {
			pWidth [i] = theObjectPool[i].pObject.GetComponent<BoxCollider2D> ().size.x;
		}
		minH = transform.position.y;
		maxH = maxHP.transform.position.y;
		theCoinGenerator = FindObjectOfType<CoinGenarator> ();
		numberOfBlocks = 1; 
		pastNumber = -1; 
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {
			dBetween = Random.Range (dBetweenMin, dBetweenMax);
			pNumber = Random.Range (0, theObjectPool.Length);
			pNumber = check (pNumber, 5);
			heightChange = transform.position.y + Random.Range (-maxDH, maxDH);
			if (heightChange > maxH) {
				heightChange = maxH - Random.Range (0, maxDH/2);
			} else if (heightChange < minH) {
				heightChange = minH + - Random.Range (-maxDH/2, 0);
			}
			transform.position = new Vector3 (transform.position.x + (pWidth[pNumber] / 2) + dBetween, heightChange, transform.position.z);
			GameObject newPlatform = theObjectPool[pNumber].GetPooledObj();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
			if (Random.Range (0, 100) < randomProbability) {
				theCoinGenerator.GenerateCoins (new Vector3 (transform.position.x, transform.position.y + 1, 0));
			}
			transform.position = new Vector3 (transform.position.x + (pWidth [pNumber] / 2), transform.position.y, transform.position.z);
		}
	}

	private int check(int num, int max){
		if (num != pastNumber) {
			pastNumber = num; 
			numberOfBlocks = 1;
			return num;
		} else {
			if (numberOfBlocks < max) {
				numberOfBlocks++;
				return num;
			} else {
				while (num == pastNumber) {
					num = Random.Range (0, theObjectPool.Length);
				}
				numberOfBlocks = 1;
				return num;
			}
		}
	}
}
