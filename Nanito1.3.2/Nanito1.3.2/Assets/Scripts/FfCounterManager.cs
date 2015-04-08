using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FfCounterManager : MonoBehaviour {

	public static int ffScore;
	public int numberff;
	Text ffCounter;
	
	void Start(){
		ffCounter = GetComponent<Text>();
		ffScore = 0;
		
	}
	
	
	void Update()
		
	{
		if (ffScore < 0) 
			ffScore = 0;
		
		
		ffCounter.text = "" + ffScore;
	}
	
	
	
	public static void AddFF (int numberFF){
		ffScore += numberFF;
		
		
	}
	
	
	
	public static void Reset (){
		
		ffScore = 0;
	}

	
	}

