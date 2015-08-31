using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {
	public float posX;
	public float posY;
	// Use this for initialization
	void Start () {
		posX = this.transform.position.x;
		posY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
