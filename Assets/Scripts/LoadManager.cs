using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex) {
		// Load a Scene with SceneManager
		SceneManager.LoadScene(sceneIndex);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
