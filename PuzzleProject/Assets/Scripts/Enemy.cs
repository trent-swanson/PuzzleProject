using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterController {

	Vector3 fwd;
	RaycastHit hit;

	[Space]
	[Space]
	public int id;

	void Start() {
		//GameManager.enemyCount += 1;
		//GameManager.UpdateTurn += Attack;
		GameManager.enemyList.Add(this);
		fwd = transform.forward * 3f;
	}

	void OnDisable() {
		//GameManager.UpdateTurn -= Attack;
	}

	public void Attack() {
		GameManager.enemyID++;
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

	public void Die() {
		GameManager.enemyList.Remove(this);
		Destroy(this.gameObject);
	}
}
