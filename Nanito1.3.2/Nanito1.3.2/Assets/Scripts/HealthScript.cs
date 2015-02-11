using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public static int hp = 12;		//estas 2 lineas las anadi
	public static int maxhp = 12;	//las cambie a static (variables globales)
	public bool isEnemy = true;
	


	public void Damage(int damageCount){
		hp -= damageCount;

		if (hp <= 0) {
			StartCoroutine(Dead ());
		}

	}

	void OnTriggerEnter2D(Collider2D otherCollider){
		//is this nanito?
		FerrofluidScript goo = otherCollider.gameObject.GetComponent<FerrofluidScript> ();
		FloorScript floor = otherCollider.gameObject.GetComponent<FloorScript> ();
		if (goo != null || floor != null) {
			Destroy(goo.gameObject);
			Destroy(floor.gameObject);
		}
	}

	IEnumerator Dead() {
		Debug.Log ("dead");
		renderer.enabled = false;
		yield return new WaitForSeconds(1);
		transform.position = new Vector2 (-284.7662f, -8.521203f);
		Debug.Log ("respawn");
		renderer.enabled = true;
		hp = maxhp;					//cambio
		
	}



}
