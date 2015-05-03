using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask ToHit;

	float timeToFire = 0;
	Transform firePoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild("FirePoint");
		if (firePoint == null) {
			Debug.LogError("No firePoint? WHAT!");
		}


	}
	
	// Update is called once per frame
	void Update () {
		Shoot ();
		if (fireRate == 0) {
			if(Input.GetButtonDown("Fire1")){
				Shoot();

			}
		}
		else {
			if(Input.GetButtonDown("Fire1") && Time.time > timeToFire){
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	}
	void Shoot(){
		Debug.Log ("Test");
		Vector2 mousePosition = new Vector2 (1f,1f);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition,1, ToHit);
		Debug.DrawLine (firePointPosition,mousePosition-firePointPosition,Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine(firePointPosition,hit.point,Color.red);
			Debug.Log ("We hit "+ hit.collider.name + " and did " + Damage + " damage.");
		}
	}
}