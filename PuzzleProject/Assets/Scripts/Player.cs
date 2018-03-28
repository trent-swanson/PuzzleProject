using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterController {

	void Update() {
		if (Input.GetKeyDown(KeyCode.W) && GameManager.playerTurn) {
			MoveForward();
			GameManager.playerTurn = false;
		}
		if (Input.GetKeyDown(KeyCode.S) && GameManager.playerTurn) {
			MoveBack();
			GameManager.playerTurn = false;
		}
		if (Input.GetKeyDown(KeyCode.A) && GameManager.playerTurn) {
			MoveLeft();
			GameManager.playerTurn = false;
		}
		if (Input.GetKeyDown(KeyCode.D) && GameManager.playerTurn) {
			MoveRight();
			GameManager.playerTurn = false;
		}
	}
}
