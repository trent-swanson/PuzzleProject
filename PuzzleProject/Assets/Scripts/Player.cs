using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharacterController {

	Touch touchControls;
	Objective objective;
	int collectableCount;

	void Awake() {
		touchControls = GameObject.FindGameObjectWithTag("GameController").GetComponent<Touch>();
		collectableCount = 0;
	}

	void OnEnable() {
		GameManager.enemyList.Clear();
		GameManager.playerTurn = true;
		GameManager.enemyID = 0;
	}

	void Start() {
		if (SceneManager.GetActiveScene().buildIndex > 1) {
			objective = GameObject.FindGameObjectWithTag("Objective").GetComponent<Objective>();
			collectableCount = GameObject.FindGameObjectsWithTag("Collectable").Length;
			if (collectableCount <= 0) {
				objective.Open();
			}
		}
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

	public void UpdateCollectables() {
		collectableCount--;
		if (collectableCount <= 0) {
			objective.Open();
		}
	}

	public void RestartLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
