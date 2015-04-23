using UnityEngine;
using System.Collections;

public class CharacterChange : MonoBehaviour {

	public GameObject nanito;
	public GameObject nanita;

	private int characterSelected;

	public void selectedCharacter (int characterToSelect){
		characterSelected = characterToSelect;

		if (characterSelected == 1) {
			nanito.gameObject.SetActive(true);
			nanita.gameObject.SetActive(false);
			Application.LoadLevel ("LevelSelect");

		} 
		else {
			nanito.gameObject.SetActive(false);
			nanita.gameObject.SetActive(true);
			Application.LoadLevel ("LevelSelect");
		}
	}



}
