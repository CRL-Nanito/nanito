using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	

	// Receives parameter to change scenes
	public void ChangeToScene (string sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
	}
}
