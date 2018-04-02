using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {

	public delegate void UpdateTurnAction();
    public static event UpdateTurnAction UpdateTurn;

	public static int currentLevel = 1;
	public static int selectedLevel = 1;
	public static bool playerTurn;
	public static int enemyCount = 0;

	public static void GoToNextLevel() {
			currentLevel++;
			SceneManager.LoadScene(1);
	}

	public static void ChangeTurn() {
		if (enemyCount != 0)
			playerTurn = !playerTurn;
		
		if (!playerTurn) {
			if (UpdateTurn != null)
				UpdateTurn();
		}
	}
}
