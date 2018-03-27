using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {

	public static int currentLevel = 1;
	public static int selectedLevel = 1;

	public static void GoToNextLevel() {
		Debug.Log("yup");
			currentLevel++;
			SceneManager.LoadScene(1);
	}
}
