using UnityEngine;
using System.Collections;

public class RunHankey : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		float step = speed * Time.time;
		transform.position = new Vector3 (0, transform.position.y + step, 0);
	}
}
