using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterController {

	void Update() {
		if (!GameManager.playerTurn) {
			MoveLeft ();
			GameManager.playerTurn = true;
		}
	}
}
