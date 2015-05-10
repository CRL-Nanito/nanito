using UnityEngine;
using System.Collections;

public class RobotArm : MonoBehaviour {
	
	// Use this for initialization
	
	Animator anim;
	public static bool move = false;
	public static bool move1 = false;

	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool ("anim", false);
		anim.SetBool ("anim1", false);
	}

	void Update () {
		if (move == true) {
			anim.SetBool ("anim", true);
		}
		if (move1 == true) {
			anim.SetBool ("anim1", true);
		}
	}
}

