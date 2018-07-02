using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroPick : MonoBehaviour {

	public GameObject level;

	public void pick(GameObject hero){
		FindObjectOfType<MyUnitySingleton> ().heroPick = hero;
		this.gameObject.SetActive (false);
		level.gameObject.SetActive (true);
	}
}
