
using UnityEngine;
using System.Collections;

public class CharacterSelection: MonoBehaviour {
	public GameObject[] PossibleCharacters;
	public int SelectedCharacterIndex;
	
	[HideInInspector]
	public GameObject playerCharacter;

	void Start()
	{
//		playerCharacter = Instantiate(PossibleCharacters[SelectedCharacterIndex], Vector3.zero, Quaternion.identity);
	}
	
}