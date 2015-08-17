
	using UnityEngine;
	using System.Collections;
	
	public class BridgePlatformScript : MonoBehaviour {
		
	Animator anim;
	public static bool bridge1 = false;
	public static bool bridge2 = false;
	public static bool bridge3 = false;
	public static bool bridge4 = false;
	public static bool bridge5 = false;
	public static bool bridge6 = false;
	public static bool bridge7 = false;
	
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool ("Bridge1", false);
		anim.SetBool ("Bridge2", false);
		anim.SetBool ("Bridge3", false);
		anim.SetBool ("Bridge4", false);
		anim.SetBool ("Bridge5", false);
		anim.SetBool ("Bridge6", false);
		anim.SetBool ("Bridge7", false);
	}
	
	void Update () {

		if (bridge1 == true) {
			anim.SetBool ("Bridge1", true);
//			GetComponent<Animation>()["Bridge1"].speed = 0.5;
			//anim.SetBool ("Bridge1", false);
		}		
		if (bridge2 == true) {
			anim.SetBool ("Bridge2", true);
		}		
		if (bridge3 == true) {
			anim.SetBool ("Bridge3", true);
		}		
		if (bridge4 == true) {
			anim.SetBool ("Bridge4", true);
		}		
		if (bridge5 == true) {
			anim.SetBool ("Bridge5", true);
		}		
		if (bridge6 == true) {
			anim.SetBool ("Bridge6", true);
		}		
		if (bridge7 == true) {
			anim.SetBool ("Bridge7", true);
		}

	}

}
