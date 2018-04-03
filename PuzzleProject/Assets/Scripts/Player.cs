using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharacterController {

	Touch touchControls;

	void OnEnable() {
		GameManager.enemyList.Clear();
		GameManager.playerTurn = true;
		GameManager.enemyID = 0;
	}

	void Start() {
		touchControls = GameObject.FindGameObjectWithTag("GameController").GetComponent<Touch>();
	}

	void Update() {
		if (GameManager.playerTurn) {
			if (Input.GetKeyDown(KeyCode.W) || touchControls.SwipeUp) {
				Move(occupiedTile.frontTile);
			}
			if (Input.GetKeyDown(KeyCode.S) || touchControls.SwipeDown) {
				Move(occupiedTile.backTile);
			}
			if (Input.GetKeyDown(KeyCode.A) || touchControls.SwipeLeft) {
				Move(occupiedTile.leftTile);
			}
			if (Input.GetKeyDown(KeyCode.D) || touchControls.SwipeRight) {
				Move(occupiedTile.rightTile);
			}
		}
	}

	public void Die() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
