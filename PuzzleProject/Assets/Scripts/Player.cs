using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterController {

	void Update() {
		if (Input.GetKeyDown(KeyCode.W)) {
			MoveForward();
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			MoveBack();
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			MoveLeft();
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			MoveRight();
		}
	}
}
