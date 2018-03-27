using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour {

	void OnEnable()
    {
        LevelNode.SelectLevel += UpdateButton;
    }
    
    
    void OnDisable()
    {
        LevelNode.SelectLevel -= UpdateButton;
    }

	void UpdateButton() {
		if (GameManager.selectedLevel <= GameManager.currentLevel) {
			transform.GetChild(0).GetComponent<Text>().text = "Play Level " + GameManager.selectedLevel;
		} else {
			transform.GetChild(0).GetComponent<Text>().text = "Level " + GameManager.selectedLevel + " is Locked";
		}
	}

	public void PlayLevel() {
		if (GameManager.selectedLevel <= GameManager.currentLevel) {
			SceneManager.LoadScene(GameManager.selectedLevel + 1);
		}
	}
}
