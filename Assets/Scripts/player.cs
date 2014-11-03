using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float speed;
	public float jumpStrength;
	public float pogoStrength;
	public float gravity;
	public bool onPogo;
	public bool isJumping;
	public BoxCollider headCollider;

	public GameObject bullet;
	 
	public ArrayList floors; 

	private enum direction {RIGHT, LEFT};
	private direction walkingDir = direction.RIGHT;

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
		headCollider = (BoxCollider)this.GetComponent ("BoxCollider");


		spawn.x = -2.5f;
		spawn.y = -1.3f;
		spawn.z = -2f;


		// this.respawn ();
	}
	
	// Update is called once per frame
	void Update () {
		// Handle Movement
		if (p.isGrounded) {
			dir.y = 0;
		}
		dir.x = Input.GetAxis ("Horizontal") * speed;
		if (Input.GetAxis ("Horizontal") > 0) {
			this.walkingDir = direction.RIGHT;
			transform.rotation = new Quaternion(0,180,0,0);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			this.walkingDir = direction.LEFT;
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
		            Quaternion.identity);	}

	void addAmmunition(int amount) {
		this.ammunition += amount;
		Debug.Log (this.ammunition);
	}

	void respawn() {
		
		this.gameObject.transform.position = spawn;
		this.walkingDir = direction.RIGHT;
		transform.rotation = new Quaternion(0,180,0,0); 
	}
	
	void looseLive() {
		this.respawn ();
		this.lives--;
	}

	void addPogoCharges(int amount) {
		this.pogoCharges += amount;
		Debug.Log (this.pogoCharges);
	}

	void addScore(int amount) {
		this.score += amount;
		Debug.Log (this.score);
	}

	void onTriggerEnter(Collider c) {
		Debug.Log("hallo");

		if (c.tag == "enemy") {
			this.lives--;
			this.respawn();
			// play Death Animation?
			// TODO respawn
		}
		if (c.tag == "wall") {
			if(headCollider.bounds.Intersects(c.bounds)){
				Debug.Log("abc");
			}
		}

	}
}
