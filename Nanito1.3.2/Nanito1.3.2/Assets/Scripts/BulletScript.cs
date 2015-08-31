using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision){

		if (collision.gameObject.tag == "Enemy") {
			Destroy(this.gameObject);
			Destroy(collision.gameObject);
			
		}

		if (collision.gameObject.tag == "platform") {
			Destroy(this.gameObject);
			

		}

	}

}
