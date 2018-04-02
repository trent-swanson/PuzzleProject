using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterController {

	Vector3 fwd;
	RaycastHit hit;

	void OnEnable() {
		GameManager.enemyCount += 1;
		GameManager.UpdateTurn += Attack;
		fwd = transform.forward * 3f;
	}

	void OnDisable() {
		GameManager.UpdateTurn -= Attack;
	}

	void Attack() {
		if (Physics.Raycast(transform.position, fwd, out hit, 3f)) {
			if (hit.transform.tag == "Player") {
				AttackPlayer(hit.transform.gameObject);
			} else {
				GameManager.ChangeTurn();
			}
		} else {
			GameManager.ChangeTurn();
		}
	}

	void Update() {
		Debug.DrawRay(transform.position, fwd, Color.magenta);
	}
}
