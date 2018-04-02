using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : CharacterController {

	[Space]
	[Space]
	public bool ball;
	bool isMovingFoward = false;
	bool isMovingBack = false;
	bool isMovingLeft= false;
	bool isMovingRight = false;

	public bool BlockMoveForward() {
		if (ball) {
			isMovingFoward = true;
		}
		return MoveForward();
	}

	public bool BlockMoveBack() {
		if (ball) {
			isMovingBack = true;
		}
		return MoveBack();
	}

	public bool BlockMoveLeft() {
		if (ball) {
			isMovingLeft = true;
		}
		return MoveLeft();
	}

	public bool BlockMoveRight() {
		if (ball) {
			isMovingRight = true;
		}
		return MoveRight();
	}

	void Update() {
		if (isMovingFoward) {
			if (MoveForward() == false) {
				isMovingFoward = false;
			}
		}
		if (isMovingBack) {
			if (MoveBack() == false) {
				isMovingBack = false;
			}
		}
		if (isMovingLeft) {
			if (MoveLeft() == false) {
				isMovingLeft = false;
			}
		}
		if (isMovingRight) {
			if (MoveRight() == false) {
				isMovingRight = false;
			}
		}
	}
}
