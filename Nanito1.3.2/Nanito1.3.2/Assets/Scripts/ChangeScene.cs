using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public GameObject nanito;
	public GameObject nanita;
	public GameObject manager;

	// Receives parameter to change scenes
	public static int character;
	public int sceneSelected;
	public GameObject characterSelected;

	public void CharacterSelect (int character1) {
		character = character1;
		Application.LoadLevel ("LevelSelect");
	}

	public void sceneSelect (int sceneSelected1) {
		if (sceneSelected1 == 100) {
			Application.LoadLevel ("LevelSelect");
		} else {
			sceneSelected = sceneSelected1;
			Application.LoadLevel ("PlayerSelect");
			DontDestroyOnLoad (manager);
		}
	}

	public void ChangeToScene (int gameSelected) {
		if (gameSelected == 0) {
			Application.LoadLevel ("nano");
		} else if (gameSelected == 1) {
			Application.LoadLevel ("hidrofobia");
		}
//		DontDestroyOnLoad (characterSelected);
		DontDestroyOnLoad (manager);
	}

	 
}
