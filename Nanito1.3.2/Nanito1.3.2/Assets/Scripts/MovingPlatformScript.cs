using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {
	private float Xpos;
	private float Ypos;
	private bool max;
	bool Vert = false;
	int maxAmount = 15;
	float step = 0.1f;

	// Use this for initialization
	void Start () {
		Xpos = transform.position.x;
		Ypos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vert)
		{ 
			if(transform.position.y >= Ypos + maxAmount)
			{
				max = true;
			} 
			else if (transform.position.y <= Ypos)
			{
				max = false;
			} 
		}else{
			if(transform.position.x >= Xpos + maxAmount)
			{
				max = true;
			}
			else if(transform.position.x <= Xpos)
			{
				max = false;
			}
		}
		if(Vert)
		{ 
			if(!max)
			{
				Vector3 temp = transform.position; 
				temp.y += step; 
				transform.position = temp; 
			}else{
				Vector3 temp = transform.position; 
				temp.y -= step; 
				transform.position = temp; 
			}
		}else{ 
			if(!max)
			{
				Vector3 temp = transform.position; 
				temp.x += step*2.5f;
				temp.y += step*1.5f; 
				transform.position = temp; 

			}else{

				Vector3 temp = transform.position; 
				temp.x -= step*2.5f;
				temp.y -= step*1.5f; 
				transform.position = temp; 
			}
		}
	}


}

