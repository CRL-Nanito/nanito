using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour {

	public GUITexture hearts;
	public Texture2D hearts3_25; //9
	public Texture2D hearts3_50; //10
	public Texture2D hearts3_75; //11
	public Texture2D hearts3_100; // full health 12
	public Texture2D hearts2_25; //5
	public Texture2D hearts2_50; //6
	public Texture2D hearts2_75; //7
	public Texture2D hearts2_100; //8
	public Texture2D hearts1_25; //1 minimum life
	public Texture2D hearts1_50; //2
	public Texture2D hearts1_75; //3
	public Texture2D hearts1_100; //4


	// Update is called once per frame
	void Update () {

		switch (HealthScript.hp) {
			
		case 12:
			GetComponent<GUITexture>().texture = hearts3_100;
			break;
			
		case 11:
			GetComponent<GUITexture>().texture = hearts2_75;	
			break;
			
		case 10:
			GetComponent<GUITexture>().texture = hearts3_50;
			break;

		case 9:
			GetComponent<GUITexture>().texture = hearts3_25;
			break;
			
		case 8:
			GetComponent<GUITexture>().texture = hearts2_100;	
			break;
			
		case 7:
			GetComponent<GUITexture>().texture = hearts2_75;
			break;
		
		case 6:
			GetComponent<GUITexture>().texture = hearts2_50;
			break;
			
		case 5:
			GetComponent<GUITexture>().texture = hearts2_25;	
			break;
			
		case 4:
			GetComponent<GUITexture>().texture = hearts1_100;
			break;
		
		case 3:
			GetComponent<GUITexture>().texture = hearts1_75;
			break;
			
		case 2:
			GetComponent<GUITexture>().texture = hearts1_50;	
			break;
			
		case 1:
			GetComponent<GUITexture>().texture = hearts1_25;
			break;

		case 0:
			break;
		}
	}
}
