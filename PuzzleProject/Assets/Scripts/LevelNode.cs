using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNode : MonoBehaviour {

	public delegate void SelectLevelAction();
    public static event SelectLevelAction SelectLevel;

	public int levelNumber;
	public bool unlocked = false;

	[Space]
	[Space]
	public Color lockedColor;
	public Color unlockedColor;
	public Color completedColor;

	Material material;

	void Start() {
		material = GetComponent<Renderer>().material;
		UnlockNextLevel();
		if (unlocked) {
			if (levelNumber == GameManager.currentLevel) {
				material.color = unlockedColor;
			} else {
				material.color = completedColor;
			}
		} else {
			material.color = lockedColor;
		}
	}

	void UnlockNextLevel() {
		if (levelNumber == GameManager.currentLevel) {
			unlocked = true;
		} else if (levelNumber < GameManager.currentLevel) {
			unlocked = true;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GameManager.selectedLevel = levelNumber;
			if (SelectLevel != null) {
				SelectLevel();
			}
		}
	}
}
