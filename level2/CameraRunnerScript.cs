using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour {

	public Transform player;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (0, player.position.y + 3, -10);
	}
}
