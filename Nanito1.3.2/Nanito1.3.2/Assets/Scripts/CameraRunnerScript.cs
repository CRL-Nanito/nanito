using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour {

	public Transform player;
	//public float speed;
	
	// Update is called once per frame
	void Update () {
		//float step = speed * Time.deltaTime;
		transform.position = new Vector3 (0, player.position.y, -10);
	}
}


//crear un empty que se mueva pa arriba automaticamente 