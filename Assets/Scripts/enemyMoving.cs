using UnityEngine;
using System.Collections;

public class enemyMoving : MonoBehaviour {

	public float speed;
		
	public float range;

	public Vector3 origin;

	private enum direction {RIGHT, LEFT};
	private float posX;
	private direction walkingDir = direction.RIGHT;


	public bool isAlive;
	public Animator anim;
	public AudioClip dieSound;

	// Use this for initialization
	void Start () {
		this.origin = new Vector3 (this.transform.position.x,
		                           this.transform.position.y,
		                           this.transform.position.z);	
		this.isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.isAlive) {
			Vector3 actPos = this.gameObject.transform.position;
			
			// movement of the Enemy on its platform
			if (this.walkingDir == direction.RIGHT) {
				if (actPos.x < this.origin.x + this.range) {
					float posX = actPos.x + speed;
					this.gameObject.transform.position = new Vector3 (posX, actPos.y, -2);
				} else {
					this.gameObject.transform.rotation = new Quaternion(0,180,0,0);
					this.walkingDir = direction.LEFT;
				}
			} else {
				if (actPos.x > this.origin.x) {
					float posX = actPos.x - speed;
					this.gameObject.transform.position = new Vector3 (posX, actPos.y, -2);
				} else {
					this.gameObject.transform.rotation = new Quaternion(0,0,0,0);
					this.walkingDir = direction.RIGHT;
				}
				
			}
		}
	}

	void damaged() {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.SendMessage ("addScore", 20);
		AudioSource.PlayClipAtPoint(this.dieSound, this.transform.position);
		GameObject.Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			c.SendMessage ("respawn", 0);
		}
	}
}
