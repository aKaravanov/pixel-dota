using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChoser : MonoBehaviour {

	public void choseLevel(string level){
		Application.LoadLevel (level);
	}
}
