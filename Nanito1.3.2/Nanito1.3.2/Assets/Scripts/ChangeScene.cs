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
//		if (character == 1) {
//			characterSelected = nanito;
//			nanito.gameObject.SetActive(true);
//			nanita.gameObject.SetActive(false);
//		} 
//		else {
//			characterSelected = nanita;
//			nanito.gameObject.SetActive(false);
//			nanita.gameObject.SetActive(true);
//		}
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

	public void ChangeToScene () {
		Application.LoadLevel ("nano");
//		DontDestroyOnLoad (characterSelected);
		DontDestroyOnLoad (manager);
	}

	 
}
