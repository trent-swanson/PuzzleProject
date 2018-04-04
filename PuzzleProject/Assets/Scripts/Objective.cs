using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

	bool isActive;

	void Start() {
		isActive = false;
		transform.localScale = new Vector3(0.3F, 0.3f, 0.3f);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && isActive) {
			GameManager.GoToNextLevel();
		}
	}

	public void Open() {
		isActive = true;
		transform.localScale = new Vector3(0.6F, 0.6f, 0.6f);
	}
}
