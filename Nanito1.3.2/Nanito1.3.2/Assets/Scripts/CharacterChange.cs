using UnityEngine;
using System.Collections;

public class CharacterChange : MonoBehaviour {

	public GameObject nanito;
	public GameObject nanita;

	static GameObject characterSelected;

	public void selectedCharacter (GameObject characterToSelect){
		characterSelected = characterToSelect;

		Application.LoadLevel ("nano");

//		if (characterSelected.tag == "Nanita") {
//
// 		} else {
//			nanito.gameObject.SetActive(false);
//			nanita.gameObject.SetActive(false);
//		}
	}



}
