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
	 
	public Animator anim;
	public CharacterController p;
	public Vector3 dir = new Vector3();
	public int ammunition = 5;
	public int pogoCharges = 5;
	public int score = 0;
	public int lives = 3;

	public Vector3 spawn = new Vector3();


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
			dir.y = this.jumpStrength;
		}
		if (Input.GetButtonDown ("Pogo") && !this.onPogo && this.pogoCharges > 0) {
			dir.y = pogoStrength;
			this.pogoCharges--;
			this.onPogo = true;
			anim.SetBool ("onPogo", true);
		}
		dir.y -= gravity * Time.deltaTime;
		p.Move (dir * Time.deltaTime);

		// Handle Shooting
		if (Input.GetButtonDown ("Fire1")) {
			anim.SetTrigger("shot");
			this.shoot();
		}

		// Handle Animations
		if (dir.x != 0) {
			anim.SetBool ("moving", true);
		} else {
			anim.SetBool ("moving", false);
		}

		if (p.isGrounded) {
			this.isJumping = false;
			anim.SetBool ("isGrounded", true);
			anim.SetBool ("onPogo", false);
			this.onPogo = false;
		} else {
			anim.SetBool ("isGrounded", false);
		}
	}

	void shoot() {
		Instantiate(this.bullet,
		            new Vector3(this.transform.position.x,this.transform.position.y+1.5f,this.transform.position.z),
		            Quaternion.identity);	

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
			// play Death Animation?
			// TODO respawn
		}
	}
}
