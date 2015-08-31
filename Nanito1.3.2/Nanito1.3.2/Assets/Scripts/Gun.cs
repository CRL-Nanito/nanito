using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	
	public float fireRate = 0;
	public float Damage = 10;
	
	public GameObject projectile;
	public float speed;
	public float delay;
	
	float timeToFire = 0;
	Transform firePoint;
	
	GameObject clone;
	public GameObject nanitoGO;
	
	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild("FirePoint");
		if (firePoint == null) {
			Debug.LogError("No firePoint? WHAT!");
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		//Shoot ();
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
		//Debug.Log ("Test");
		//		Vector2 mousePosition = new Vector2 (transform.parent.position.x, transform.parent.position.y);	
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		//		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
		//		Debug.DrawLine (firePointPosition, (mousePosition - firePointPosition)*100, Color.cyan);
		//		if (hit.collider != null) {
		//			Debug.DrawLine(firePointPosition, hit.point, Color.red);
		//			Debug.Log ("We hit "+ hit.collider.name + " and did " + Damage + " damage.");
		//		}
		
		NanitoControllerScript nanito = nanitoGO.GetComponent<NanitoControllerScript>();
		
		Debug.Log ("Test");
		
		clone = (GameObject) Instantiate(projectile, firePointPosition, Quaternion.identity);
		if (nanito.facingRight) 
			clone.gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed;
		else {
			clone.gameObject.GetComponent<Rigidbody2D> ().velocity = -transform.right * speed;
		}
		
		
	}
	
	IEnumerator Destroy(){
		
		yield return new WaitForSeconds(delay);
		Destroy (clone);
		
	}
}