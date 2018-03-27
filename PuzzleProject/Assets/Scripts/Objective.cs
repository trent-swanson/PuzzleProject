using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Debug.Log("hit player");
			GameManager.GoToNextLevel();
		}
	}
}
