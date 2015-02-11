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
			guiTexture.texture = hearts3_100;
			break;
			
		case 11:
			guiTexture.texture = hearts2_75;	
			break;
			
		case 10:
			guiTexture.texture = hearts3_50;
			break;

		case 9:
			guiTexture.texture = hearts3_25;
			break;
			
		case 8:
			guiTexture.texture = hearts2_100;	
			break;
			
		case 7:
			guiTexture.texture = hearts2_75;
			break;
		
		case 6:
			guiTexture.texture = hearts2_50;
			break;
			
		case 5:
			guiTexture.texture = hearts2_25;	
			break;
			
		case 4:
			guiTexture.texture = hearts1_100;
			break;
		
		case 3:
			guiTexture.texture = hearts1_75;
			break;
			
		case 2:
			guiTexture.texture = hearts1_50;	
			break;
			
		case 1:
			guiTexture.texture = hearts1_25;
			break;

		case 0:
			break;
		}
	}
}
