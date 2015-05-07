using UnityEngine;
using System.Collections;

public class NanitoControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	private float move;

	Animator anim;

	float wingsFactor = 600f;
	int wingsCounter = 0;
	bool grounded = false;
	bool shieldFlag = false;

	public GameObject shieldGO;

	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 1500f;

	bool doubleJump = false;
	private int time;
	private Time timer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
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
		bool damagePlayer = false;
		bool hell = false;

		//collision with ff
		FerrofluidScript goo = collision.gameObject.GetComponent<FerrofluidScript> ();
		HealthScript playerHealth = this.GetComponent<HealthScript>();
		FloorScript floor = collision.gameObject.GetComponent<FloorScript> ();
		PopUpScript popUp = collision.gameObject.GetComponent<PopUpScript> ();
		BossFight boss = collision.gameObject.GetComponent<BossFight> ();
		ShieldScript shield = collision.gameObject.GetComponent<ShieldScript>();
		FfScript ffBottle = collision.gameObject.GetComponent<FfScript>();
		WingsCounter wings = collision.gameObject.GetComponent<WingsCounter>();

		if (goo != null) {
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

		if(collision.gameObject.tag == "MovingPlatform"){
			this.transform.parent = collision.transform;
		}


		if (collision.gameObject.tag == "Boss") {
			showPopUp = true;
			maxSpeed = 0;
			anim.enabled = false;

			if (i == 5) {
				maxSpeed = 30;
				anim.enabled = true;
				Destroy(boss.gameObject.GetComponent<Collider2D>());
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
			GUI.Window (0, new Rect ((Screen.width / 2) - 150, (Screen.height / 2) - 130, 300, 250), ShowGUI, "BOSS FIGHT");
		}
	}

	void ShowGUI(int windowID)
	{	
		bool damagePlayer = false;
		HealthScript playerHealth = this.GetComponent<HealthScript> ();

		GUI.backgroundColor = Color.black;
		GUI.contentColor = Color.green;
		
		if  (i == 0) {
		
			GUI.Label (new Rect (65, 40, 200, 500),  "Are you hungry?\n [A] Yes\n [B] No\n [C] I don\'t know\n");
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
		}
		
		if (i == 1) {
			showPopUp = true;
			GUI.Label (new Rect (65, 40, 200, 500), "Do you want to eat?\n [A] Yes\n [B] No\n [C] I don\'t know\n");
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
		}
		
		if (i == 2) {
			GUI.Label (new Rect (65, 40, 200, 500), "Do you want to take a nap?\n [A] Yes\n [B] No\n [C] I don\'t know\n");
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
		}
		
		if (i == 3) {
			GUI.Label (new Rect (65, 40, 200, 500), "Are you sleepy?\n [A] Yes\n [B] No\n [C] I don\'t know\n");
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
		}
		
		if (i == 4) {
			GUI.Label (new Rect (65, 40, 200, 500), "Are you alive?\n [A] Yes\n [B] No\n [C] I don\'t know\n");
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
		}
		
		if (i == 5) {
			showPopUp = false;

		}
		
		
	}



}
