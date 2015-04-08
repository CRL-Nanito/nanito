using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {

	public Transform Player1, Player2;
	
	public Vector2 Margin, Smoothing;
	
	public BoxCollider2D Bounds;
	
	private Vector3 _min, _max;
	
	public bool isFollowing { get; set;}

	int player;

	public GameObject nanito;

	public GameObject nanita;

	public void Start() {
		player = ChangeScene.character;

		_min = Bounds.bounds.min; 
		_max = Bounds.bounds.max;
		isFollowing = true;

		if (player == 1) {
			nanito.gameObject.SetActive(true);
			nanita.gameObject.SetActive(false);
		} 
		else {
			nanito.gameObject.SetActive(false);
			nanita.gameObject.SetActive(true);
		}

	}
	
	public void Update() {

		if (player == 1) {
			var x = transform.position.x;
			var y = transform.position.y;
			
			if (isFollowing) {
				if (Mathf.Abs (x - Player1.position.x) > Margin.x)
					x = Mathf.Lerp (x, Player1.position.x, Smoothing.x * Time.deltaTime);
				
				if (Mathf.Abs (y - Player1.position.y) > Margin.y)
					y = Mathf.Lerp (y, Player1.position.y, Smoothing.y * Time.deltaTime);
				
			}
			
			var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
			
			x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
			y = Mathf.Clamp (y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);
			
			transform.position = new Vector3 (x, y, transform.position.z);
		} 
		if (player == 2) {
			var x = transform.position.x;
			var y = transform.position.y;
			
			if (isFollowing) {
				if (Mathf.Abs(x - Player2.position.x) > Margin.x)
					x = Mathf.Lerp(x, Player2.position.x, Smoothing.x * Time.deltaTime);
				
				if (Mathf.Abs(y - Player2.position.y) > Margin.y)
					y = Mathf.Lerp(y, Player2.position.y, Smoothing.y * Time.deltaTime);
				
			}
			
			var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
			
			x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
			y = Mathf.Clamp (y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);
			
			transform.position = new Vector3 (x, y, transform.position.z);
		}
		
	}
}

