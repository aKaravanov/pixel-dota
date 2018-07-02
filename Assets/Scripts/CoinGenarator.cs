using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenarator : MonoBehaviour {

	public ObjectPuller coinPool;

	public float distanceBetweenCoins;

	public void GenerateCoins(Vector3 startPosition){
		if (Random.Range (0, 100) < 50) {
			GameObject coin1 = coinPool.GetPooledObj ();
			coin1.transform.position = startPosition;
			coin1.SetActive (true);
		}
		if (Random.Range (0, 100) < 50) {
			GameObject coin2 = coinPool.GetPooledObj ();
			coin2.transform.position = new Vector3 (startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
			coin2.SetActive (true);
		}
		if (Random.Range (0, 100) < 50) {
			GameObject coin3 = coinPool.GetPooledObj ();
			coin3.transform.position = new Vector3 (startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
			coin3.SetActive (true);
		}
	}
}
