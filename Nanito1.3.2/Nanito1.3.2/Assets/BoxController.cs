using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {
	bool founded;
	// Use this for initialization
	void Start () {
		founded = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public  void Founded (bool founded){
	   founded=founded;
		
		
	}
}
