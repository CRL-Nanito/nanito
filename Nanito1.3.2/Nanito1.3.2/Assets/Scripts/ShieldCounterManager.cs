using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShieldCounterManager : MonoBehaviour {

	public static int shieldScore;
	public int numberShield;
	Text escCounter;

	void Start(){
		escCounter = GetComponent<Text>();
		shieldScore = 0;

	}


	void Update()

		{
		if (shieldScore < 0) 
			shieldScore = 0;

		
			escCounter.text = "" + shieldScore;
		}



	public static void AddShield (int numberShield){
		shieldScore += numberShield;


	}



	public static void Reset (){

		shieldScore = 0;
	}


}
