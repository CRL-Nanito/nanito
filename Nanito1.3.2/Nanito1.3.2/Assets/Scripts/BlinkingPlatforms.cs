using UnityEngine;
using System.Collections;

public class BlinkingPlatforms : MonoBehaviour {
	public float velocity;
	private float time = 0;
	private SpriteRenderer spriteRenderer;
	private BoxCollider2D collider;
	
	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		collider = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		Debug.Log (time);
		if (time >= 5 / velocity) {
			spriteRenderer.enabled = true;
			collider.enabled = true;
			time = 0;
		} else if (time >= 3 / velocity) {
			spriteRenderer.enabled = false;
			collider.enabled = false;
		}
	}
}
