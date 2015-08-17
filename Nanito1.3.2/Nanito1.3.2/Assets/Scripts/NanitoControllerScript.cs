using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NanitoControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	private float move;

	Animator anim;
	Animator bridgeAnim;

	float wingsFactor = 600f;
	int wingsCounter = 0;
	bool grounded = false;
	bool shieldFlag = false;
	bool damagePlayer = false;


	public GameObject shieldGO;

	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 1500f;

	bool doubleJump = false;
	private int time;
	private Time timer;

	public Texture2D background;
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flas


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		BridgePlatformScript bridge = GetComponent<BridgePlatformScript>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		//detects colliders
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded); //idle anim

		if (grounded)
			doubleJump = false;

//		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y); //how fast r we going up or down


		move = Input.GetAxis ("Horizontal");

		//mid-air movement enabler
		//if (!grounded && Mathf.Abs(move) > 0.01f) return;

		//handles the anims
		anim.SetFloat ("Speed", Mathf.Abs (move));

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight) 
			Flip ();
		else if (move < 0 && facingRight) 
			Flip ();
				

//		if (Input.GetMouseButtonDown (0)) {
//			Destroy(this.gameObject);
//		}
	}

	void OnDestroy(){
		//check that the player is dead
		HealthScript playerHealth = this.GetComponent<HealthScript> ();
		if (playerHealth != null && HealthScript.hp <= 0) {				//en vez de playerHealth.hp use HealthScript.hp ya que hp es una variable global
			//game over bitches
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		bool hell = false;

		//collision with ff
		FerrofluidScript goo = collision.gameObject.GetComponent<FerrofluidScript> ();
		HealthScript playerHealth = GetComponent<HealthScript> ();
		FloorScript floor = collision.gameObject.GetComponent<FloorScript> ();
		PopUpScript popUp = collision.gameObject.GetComponent<PopUpScript> ();
		BossFight boss = collision.gameObject.GetComponent<BossFight> ();
		ShieldScript shield = collision.gameObject.GetComponent<ShieldScript> ();
		FfScript ffBottle = collision.gameObject.GetComponent<FfScript> ();
		WingsCounter wings = collision.gameObject.GetComponent<WingsCounter> ();
		RobotArm robot = GetComponent<RobotArm> ();

		//BridgePlatformScript bridge = GetComponent<BridgePlatformScript> ();

		

		if (goo != null) {
			damagePlayer = true;
		}

		if (collision.gameObject.tag == "Enemy") {
			damagePlayer = true;
		}
	

		if (floor != null) {
			damagePlayer = true;
			hell = true;
		}


		//damage player
		if (damagePlayer) {
			if(playerHealth != null) playerHealth.Damage(1);
		}

		if (damagePlayer && hell) {
			if(playerHealth != null) playerHealth.Damage(20);
		}

		if (collision.gameObject.name == "atomo") {
			popUp.showPopUp = true;
			popUp.gameObject.GetComponent<Renderer>().enabled = false;
			Destroy(popUp.gameObject.GetComponent<Collider2D>());
		}

		if (collision.gameObject.tag == "MovingPlatform"){
			this.transform.parent = collision.transform;
		}

		if (collision.gameObject.tag == "lever"){
			RobotArm.move = true;
		}

		if (collision.gameObject.tag == "lever1") {
			RobotArm.move1 = true;
		}

		if (collision.gameObject.tag == "Boss") {
			boss.gameObject.GetComponent<Renderer>().enabled = true;
			
			showPopUp = true;
			maxSpeed = 0;
			
			if (i == 5) {
				maxSpeed = 25;
				Destroy(boss.gameObject);
				boss.gameObject.GetComponent<Renderer>().enabled = false;
			}
		}

		if (collision.gameObject.tag == "Door") {
			Application.LoadLevel("Hidrofobia");
		}

		if (wings != null) {
			wings.GetComponent<Renderer>().enabled = false;
			wings.GetComponent<PolygonCollider2D>().enabled = false;
			wingsCounter = 7;
		}

		if (collision.gameObject.tag == "shield") {
			ShieldCounterManager.AddShield(shield.shieldNumber);
			Destroy(shield.gameObject);
			shieldFlag = true;
			Debug.Log("Shield available");
		}


		if (collision.gameObject.tag == "ffbottle") {
			FfCounterManager.AddFF(ffBottle.ffNumber);
			Destroy(ffBottle.gameObject);
		}

		//platform activator
		if (collision.gameObject.tag == "ActivatePlatform") {
			collision.gameObject.GetComponent<Animator>().enabled = true;
		}

		if (collision.gameObject.tag == "Boots") {
			collision.gameObject.GetComponent<Renderer>().enabled = false;
			collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
			time = 5;
		}

		if (collision.gameObject.tag == "box") {
			bool founded = false;
			BoxController box = collision.gameObject.GetComponent<BoxController>();
			box.Founded(true);
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "Bridge1") {
			//bridgeAnim.Play("Bridge");
			//bridgeAnim.SetBool("Bridge1", true);
			BridgePlatformScript.bridge1 = true;

		}
		if (collision.gameObject.tag == "Bridge2") {
			//bridgeAnim.SetBool("Bridge2", true);
			BridgePlatformScript.bridge2 = true;

		}
		if (collision.gameObject.tag == "Bridge3") {
			//bridgeAnim.SetBool("Bridge3", true);
			BridgePlatformScript.bridge3 = true;

		}
		if (collision.gameObject.tag == "Bridge4") {
			//bridgeAnim.SetBool("Bridge4", true);
			BridgePlatformScript.bridge4 = true;

		}
		if (collision.gameObject.tag == "Bridge5") {
			//bridgeAnim.SetBool("Bridge5", true);
			BridgePlatformScript.bridge5 = true;

		}
		if (collision.gameObject.tag == "Bridge6") {
			//bridgeAnim.SetBool("Bridge6", true);
			BridgePlatformScript.bridge6 = true;

		}
		if (collision.gameObject.tag == "Bridge7") {
			//bridgeAnim.SetBool("Bridge7", true);
			BridgePlatformScript.bridge7 = true;

		}


	}

	void Update(){
		// si brinco desde el piso o desde el primer brinco
		if ((grounded || !doubleJump) && Input.GetButtonDown ("Jump")) {
			
			//BRETTY GOOD, EH?
			anim.SetBool ("Ground", false);
			this.transform.parent = null;
			float newJumpForce = jumpForce;
			
			//UPDATE WINGS COUNTER ACCORDING TO DOUBLE JUMP OR WINGS COUNTER
			if (wingsCounter > 0) {
				newJumpForce += wingsFactor;
				wingsCounter--;
			}
			if (!doubleJump && !grounded) {
				newJumpForce /= 2;
				doubleJump = true;
			}
			
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, newJumpForce));
		}
		//activate shield
		if (shieldFlag == true && Input.GetButtonDown ("Shield")) {
			shieldGO.SetActive (true);
			ShieldCounterManager.shieldScore--;
			Debug.Log ("shield me bitch");
			StartCoroutine (ShieldDelay ());
			Debug.Log ("bye shield");

			if (shieldFlag == true && ShieldCounterManager.shieldScore == 0) {
				shieldFlag = false;
			}
		}

		// If the player has just been damaged...
		if(damagePlayer)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		// Reset the damaged flag.
		damagePlayer = false;


	}
	


	//Flip world 180
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator ShieldDelay(){
		yield return new WaitForSeconds (3);
		shieldGO.SetActive(false);
	}
	

	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "MovingPlatform"){
			this.transform.parent = null;
		}

	}   

	public bool showPopUp = false;
	
	public static int correct_answer = 0;
	int i = 0;
	int clicks = 0;

	void OnGUI()
	{		
		//show window if you touched collider
		if (showPopUp == true) {
			GUI.Window (0, new Rect ((Screen.width / 2) - 350, (Screen.height / 2) - 130, 300, 250), ShowGUI, "BOSS FIGHT");
			GUI.DrawTexture (new Rect ((Screen.width / 2) - 350, (Screen.height / 2) - 130, 300, 250), background);
		}
	}


	
	void ShowGUI(int windowID)
	{	
		bool damagePlayer = false;
		HealthScript playerHealth = this.GetComponent<HealthScript> ();

		switch (i) {
		case 0:
			GUI.Label (new Rect (65, 40, 200, 500),  "¿A que se debe la forma peculiar de un ferrofluido?\n [A] Las lineas del campo magnetico\n [B] Gravedad\n [C] Temperatura\n");
			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
				correct_answer = 1;
				i++;
			} else
			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			} else
			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			}
			break;
		
		case 1:
			GUI.Label (new Rect (65, 40, 200, 500), "¿Que es un ferrofluido?\n [A] Un liquido que no se polariza en un campo magnetico\n [B] Un liquido que repele el agua\n [C] Un liquido que se polariza en un campo magnetico\n");
			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			} else
			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			} else
			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
				correct_answer = 1;
				i++;
			}
			break;

		case 2:
			GUI.Label (new Rect (65, 40, 200, 500), "¿Como los ferrofluidos ayudan a combatir el cancer?\n [A] Los ferrofluidos no son capaces de combatir el cancer\n [B] Quimeoterapia usando ferrofluidos\n [C] Utilizando una tecnica llamada cocinar el tumor\n");
			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			} else
			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			} else
			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
				correct_answer = 1;
				i++;
			}
			break;

		case 3:
			GUI.Label (new Rect (65, 40, 200, 500), "¿Que le pasa a un iman y un metal si se le aplica ferrofluido?\n [A] Aumenta la friccion\n [B] Disminuye la friccion\n [C] Se queda igual\n");
			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			} else
			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
				correct_answer = 1;
				i++;
			} else
			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			}
			break;

		case 4:
			GUI.Label (new Rect (65, 40, 200, 500), "¿En que parte de los robots se utiliza ferrofluidos?\n [A] La cabeza\n [B] Las coyunturas\n [C] El cuello\n");
			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			} else
			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
				correct_answer = 1;
				i++;
			} else
			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
				correct_answer = 0;
				clicks++;
				if(playerHealth != null) {
					playerHealth.Damage(4);
				} 
				if (clicks == 3) {
					showPopUp = false;
					maxSpeed = 30;
					anim.enabled = true;
					clicks = 0;
				}
			}
			break;

		case 5:
			showPopUp = false;
			break;
		}


		

//		if  (i == 0) {
//			GUI.Label (new Rect (65, 40, 200, 500),  "¿A que se debe la forma peculiar de un ferrofluido?\n [A] Las lineas del campo magnetico\n [B] Gravedad\n [C] Temperatura\n");
//			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
//				correct_answer = 1;
//				i++;
//			} else
//			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			} else
//			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			}
//		}
//		
//		if (i == 1) {
//			GUI.Label (new Rect (65, 40, 200, 500), "¿Que es un ferrofluido?\n [A] Un liquido que no se polariza en un campo magnetico\n [B] Un liquido que repele el agua\n [C] Un liquido que se polariza en un campo magnetico\n");
//			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			} else
//			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			} else
//			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
//				correct_answer = 1;
//				i++;
//			}
//		}
//		
//		if (i == 2) {
//			GUI.Label (new Rect (65, 40, 200, 500), "¿Como los ferrofluidos ayudan a combatir el cancer?\n [A] Los ferrofluidos no son capaces de combatir el cancer\n [B] Quimeoterapia usando ferrofluidos\n [C] Utilizando una tecnica llamada cocinar el tumor\n");
//			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			} else
//			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			} else
//			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
//				correct_answer = 1;
//				i++;
//			}
//		}
//		if (i == 3) {
//			GUI.Label (new Rect (65, 40, 200, 500), "¿Que le pasa a un iman y un metal si se le aplica ferrofluido?\n [A] Aumenta la friccion\n [B] Disminuye la friccion\n [C] Se queda igual\n");
//			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			} else
//			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
//				correct_answer = 1;
//				i++;
//			} else
//			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			}
//		}
//		
//		if (i == 4) {
//			GUI.Label (new Rect (65, 40, 200, 500), "¿En que parte de los robots se utiliza ferrofluidos?\n [A] La cabeza\n [B] Las coyunturas\n [C] El cuello\n");
//			if (GUI.Button (new Rect (50, 150, 40, 30), "A")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			} else
//			if (GUI.Button (new Rect (100, 150, 40, 30), "B")) {
//				correct_answer = 1;
//				i++;
//			} else
//			if (GUI.Button (new Rect (150, 150, 40, 30), "C")) {
//				correct_answer = 0;
//				clicks++;
//				if(playerHealth != null) {
//					playerHealth.Damage(4);
//				} 
//				if (clicks == 3) {
//					showPopUp = false;
//					maxSpeed = 30;
//					anim.enabled = true;
//					clicks = 0;
//				}
//			}
//		}
//		
//		if (i == 5) {
//			showPopUp = false;
//			
//		}
		
		
	}



}
