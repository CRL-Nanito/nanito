using UnityEngine;
using System.Collections;

public class WingsCounter : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	private BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		collider = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
