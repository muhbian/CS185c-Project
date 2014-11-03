using UnityEngine;
using System.Collections;

public class platformMover : MonoBehaviour {
	public float speed;
	public float range;
	public bool movesHorizontal;
	public bool oppositeDir;

	private bool isMovingBack;
	private Vector3 origin;
	public Vector3 dir;

	// Use this for initialization
	void Start () {
		this.origin = new Vector3 (this.transform.position.x,
		                           this.transform.position.y,
		                           this.transform.position.z);		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.movesHorizontal) {
			this.dir = new Vector3 (this.speed, 0, 0);

			if(this.transform.position.x >= this.origin.x + this.range) {
				this.isMovingBack = true;
			} else if (this.transform.position.x <= this.origin.x) {
				this.isMovingBack = false;
			}

		} else {
			this.dir = new Vector3 (0, this.speed, 0);

			if(this.transform.position.y >= this.origin.y + this.range) {
				this.isMovingBack = true;
			} else if (this.transform.position.y <= this.origin.y) {
				this.isMovingBack = false;
			}
		}

		if (this.oppositeDir) {
			this.dir *= -1;
		}

		if (this.isMovingBack) {
			this.dir *= -1;
		}

		this.transform.position += this.dir * Time.deltaTime;

	}

	void OnTriggerEnter (Collider c) {
		if(c.transform.tag == "Player")
		{
			c.transform.parent = this.transform;
		}
	}

	void OnTriggerExit (Collider c) {
		if(c.transform.tag == "Player")
		{
			this.transform.DetachChildren();
		}
	}
}
