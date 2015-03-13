using UnityEngine;
using System.Collections;

public class PopUpScript : MonoBehaviour {
	public bool showPopUp = false;
	public Texture2D background;

	void OnTriggerEnter(Collider2D otherObject){
		
		if(otherObject.tag == "Player") {
			showPopUp = true;
		}
	}
	


	void OnGUI()
	{		//show window if you touched collider
		if (showPopUp == true) {
			GUI.Window (0, new Rect ((Screen.width / 2) - 150, (Screen.height / 2) - 130, 300, 250), ShowGUI, "Dato curioso");
			GUI.DrawTexture (new Rect ((Screen.width / 2) - 150, (Screen.height / 2) - 130, 300, 250), background);
			Time.timeScale=0;
		}
	}
	
	void ShowGUI(int windowID)
		{
			// You may put a label to show a message to the player
		
			if (this.gameObject.tag == "Atomo") {
				GUI.Label (new Rect (65, 40, 200, 550), "La forma peculiar de los " +
			           "ferrofluidos en presencia de un campo magnético es debido a la forma en la que están organizadas " +
			           "las líneas de campo magnético.");
			} else 
			if (this.gameObject.tag == "Atomo1") {
				GUI.Label (new Rect (65, 40, 200, 550), "Un ferrofluido es" +
			           "un líquido que se polariza en presencia de un campo magnético.");
			} else
			if (this.gameObject.tag == "Atomo2") {
				GUI.Label (new Rect (65, 40, 200, 550), "Para combatir el cáncer  utilizando ferrofluidos " +
			           "se inyectan las nanopartículas al cuerpo. Una vez " +
			           "llegan al tumor, se utiliza un campo magnético " +
			           "alterno para que las partículas roten y generen calor, y así 'cocinar' el tumor.");
			}else
			if (this.gameObject.tag == "Atomo3") {
				GUI.Label (new Rect (65, 40, 200, 550), "La fricción entre un imán y un metal se puede reducir " +
				       "si se le aplica ferrofluido a un imán de gran potencia el imán podra deslizarse sobre superficies lisas con" +
			           "un mínimo de resistencia");
			}else
			if (this.gameObject.tag == "Atomo4") {
				GUI.Label (new Rect (65, 40, 200, 500), "Los ferrofluidos se podrían utilizar para las coyunturas de los robots.");
			}
					
			// You may put a button to close the pop up too
			
			if (GUI.Button(new Rect(50, 200, 75, 30), "OK"))
			{
				showPopUp = false;
				Time.timeScale=1;
				// you may put other code to run according to your game too
			}
			
		}
	
}
