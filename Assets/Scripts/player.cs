using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float speed;
	public float jumpstrenght;
	public float pogoStrength;
	public float gravity;
	public bool onPogo;
	public bool isJumping;

	public GameObject floor;
	public GameObject enemy;

	private Animator anim;
	private CharacterController p;
	private Vector3 dir = new Vector3 ();
	private int ammunition = 5;
	private int pogoCharges = 5;
	private int score = 0;


	// Use this for initialization
	void Start () {
		anim = (Animator)this.GetComponent ("Animator");
		p = (CharacterController)(this.GetComponent("CharacterController"));
	}
	
	// Update is called once per frame
	void Update () {
		// Handle Movement
		dir.x = Input.GetAxis ("Horizontal") * speed;
		if (Input.GetAxis ("Horizontal") > 0) {
			transform.rotation = new Quaternion(0,180,0,0);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			transform.rotation = new Quaternion(0,0,0,0);
		}
		if (Input.GetButtonDown ("Jump") && !this.isJumping) {
			this.isJumping = true;
			dir.y = jumpstrenght;
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

	void addAmmunition(int amount) {
		this.ammunition += amount;
		Debug.Log (this.ammunition);
	}

	void addPogoCharges(int amount) {
		this.pogoCharges += amount;
		Debug.Log (this.pogoCharges);
	}

	void addScore(int amount) {
		this.score += amount;
		Debug.Log (this.score);
	}
}
