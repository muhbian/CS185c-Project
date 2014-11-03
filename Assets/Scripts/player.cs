using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float speed;
	public float jumpStrength;
	public float pogoStrength;
	public float gravity;
	public bool onPogo;
	public bool isJumping;
	public GameObject bullet;
	public GameObject respawnPoint;
	 
	private Animator anim;
	private CharacterController p;
	public Vector3 dir = new Vector3();
	private int ammunition = 5;
	private int pogoCharges = 5;
	private int score = 0;
	private int lives = 3;
	private bool hitHead;

	// Use this for initialization
	void Start () {
		anim = (Animator)this.GetComponent ("Animator");
		p = (CharacterController)(this.GetComponent("CharacterController"));
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
			this.onPogo = false;
			dir.y = this.jumpStrength;
		}
		if (Input.GetButtonDown ("Pogo") && !this.onPogo && this.pogoCharges > 0 && !this.isJumping) {
			dir.y = pogoStrength;
			this.pogoCharges--;
			this.onPogo = true;
		}
		dir.y -= gravity * Time.deltaTime;
		p.Move (dir * Time.deltaTime);

		// Handle Shooting
		if (Input.GetButtonDown ("Fire1")) {
			anim.SetTrigger("shot");
			this.shoot();
		}

		// Handle Animations and grounding
		if (dir.x != 0) {
			anim.SetBool ("moving", true);
		} else {
			anim.SetBool ("moving", false);
		}

		if (this.onPogo) {
			anim.SetBool ("onPogo", true);
		}
			
		if (p.isGrounded) {
			this.isJumping = false;
			anim.SetBool ("isGrounded", true);
			anim.SetBool ("onPogo", false);
			this.onPogo = false;
			this.hitHead = false;
		} else {
			anim.SetBool ("isGrounded", false);
		}
	}

	void shoot() {
		this.ammunition--;
		Vector3 bulletPos = new Vector3 (this.transform.position.x + 1.0f,
		                                this.transform.position.y,
		                                this.transform.position.z);	
	
		GameObject.Instantiate (this.bullet, bulletPos, Quaternion.identity);
	}

	void addAmmunition(int amount) {
		this.ammunition += amount;
	}

	void respawn() {
		this.lives--;
		this.transform.position = this.respawnPoint.transform.position;
	}

	void addPogoCharges(int amount) {
		this.pogoCharges += amount;
	}

	void addScore(int amount) {
		this.score += amount;
	}

	void onTriggerEnter(Collider c) {
		if (c.tag == "enemy") {
			this.respawn();
			// play Death Animation
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		if (!this.hitHead) {
			dir = new Vector3 (0, 0, 0);
			this.hitHead = true;
		}
	}
}
