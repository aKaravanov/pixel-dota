using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPuller : MonoBehaviour {


	public GameObject pObject;

	public int pAmount;

	List<GameObject> pObjects;

	// Use this for initialization
	void Start () {
		pObjects = new List<GameObject> ();
		for (int i = 0; i < pAmount; i++) {
			GameObject obj = (GameObject) Instantiate (pObject);
			obj.SetActive (false);
			pObjects.Add (obj);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	public GameObject GetPooledObj(){
		for(int i = 0; i < pObjects.Count; i++){
			if (!pObjects [i].activeInHierarchy) {
				return pObjects [i];
			} 
		}
		GameObject obj = (GameObject) Instantiate (pObject);
		obj.SetActive (true);
		pObjects.Add (obj);
		pAmount = pAmount++;
		return obj;
	}
}
