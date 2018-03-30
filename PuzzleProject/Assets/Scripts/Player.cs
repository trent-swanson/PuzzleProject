using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharacterController {

	Touch touchControls;

	void Start() {
		GameManager.playerTurn = true;
		touchControls = GameObject.FindGameObjectWithTag("GameController").GetComponent<Touch>();
	}

	void Update() {
		if (GameManager.playerTurn) {
			if (Input.GetKeyDown(KeyCode.W) || touchControls.SwipeUp) {
				MoveForward();
			}
			if (Input.GetKeyDown(KeyCode.S) || touchControls.SwipeDown) {
				MoveBack();
			}
			if (Input.GetKeyDown(KeyCode.A) || touchControls.SwipeLeft) {
				MoveLeft();
			}
			if (Input.GetKeyDown(KeyCode.D) || touchControls.SwipeRight) {
				MoveRight();
			}
		}
	}

	public void Die() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
