﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	public void Play() {
		SceneManager.LoadScene(1);
	}

	public void Options() {

	}

	public void Exit() {
		Application.Quit();
	}
}
