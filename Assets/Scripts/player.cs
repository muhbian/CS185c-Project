using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float speed;
	public float jumpStrength;
	public float pogoStrength;
	public float gravity;
	public bool onPogo;
	public bool hasPogo;
	public bool hasGun;
	public bool isJumping;
	public GameObject bullet;
	public GameObject respawnPoint;
	public AudioClip hitHeadSound;
	 
	private Animator anim;
	private CharacterController p;
	public Vector3 dir = new Vector3();
	public int ammunition = 5;
	public int score = 0;
	public int lives = 3;
	public bool hitHead;

	// Use this for initialization
	void Start () {
		anim = (Animator)this.GetComponent ("Animator");
		p = (CharacterController)(this.GetComponent("CharacterController"));
		this.hasPogo = true;
		this.hasGun = true;
		//this.respawn ();
	}
	
	// Update is called once per frame
	void Update () {
		// Handle Movement
		if (p.isGrounded) {
			dir.y = 0;
		}
		dir.x = Input.GetAxis ("Horizontal") * speed;
		if (Input.GetAxis ("Horizontal") > 0) {
			transform.rotation = new Quaternion(0,180,0,0);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			transform.rotation = new Quaternion(0,0,0,0);
		}
		if (Input.GetButtonDown ("Jump") && !this.isJumping) {
			this.isJumping = true;
			dir.y = this.jumpStrength;
		}
		if (Input.GetButtonDown ("Pogo") ) {
//			dir.y = pogoStrength;
//
//			this.onPogo = true;

			this.onPogo = !this.onPogo;

			if(!this.onPogo) {
				dir.y = 0;
			}
			anim.SetBool ("onPogo", this.onPogo);
		}
	
		// Handle Shooting
		if (Input.GetButtonDown ("Fire1")) {
			if(this.ammunition > 0 ) {
				anim.SetTrigger("shot");
				this.shoot();
			}
		}

		// Handle Animations
		if (dir.x != 0) {
			anim.SetBool ("moving", true);
		} else {
			anim.SetBool ("moving", false);
		}

		if (p.isGrounded) {
			this.isJumping = false;
			this.hitHead = false;
			if(onPogo) {
				dir.y = pogoStrength;

			} else {
				anim.SetBool ("isGrounded", true);
				
			}

		} else {
			anim.SetBool ("isGrounded", false);
		}
		dir.y -= gravity * Time.deltaTime;
		p.Move (dir * Time.deltaTime);

	}

	void shoot() {
		this.ammunition--;
		Instantiate(this.bullet,
		            new Vector3(this.transform.position.x+1.5f,this.transform.position.y,this.transform.position.z),
		            Quaternion.identity);
	}

	void addAmmunition(int amount) {
		this.ammunition += amount;
	}

	void respawn() {
		this.lives--;
		this.transform.position = this.respawnPoint.transform.position;
		this.transform.rotation = new Quaternion(0,0,0,0);
	}

	void addScore(int amount) {
		this.score += amount;
		// play sound
	}

	void onTriggerEnter(Collider c) {
		if (c.tag == "enemy") {
			this.respawn();
			// play Death Animation
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		if (!this.hitHead && !p.isGrounded) {
			dir = new Vector3 (0, 0, 0);
			this.hitHead = true;
			AudioSource.PlayClipAtPoint (this.hitHeadSound, new Vector3(0,0,0));
		}

	}
}
