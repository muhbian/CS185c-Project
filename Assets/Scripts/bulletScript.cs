using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public float speed;
	public AudioClip sound;
	private bool left;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (!left) {
			this.transform.position += new Vector3 (1, 0, 0) * speed * Time.deltaTime; 
		} else {
			this.transform.position -= new Vector3 (1, 0, 0) * speed * Time.deltaTime; 
		}
	}

	void OnCollisionEnter(Collision c) {
		GameObject.Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider c) {
		if (c.transform.tag == "enemy") {
			c.gameObject.SendMessage("damaged",1);
			GameObject.Destroy (this.gameObject);
		}
	}

	void goLeft() {
		this.left = true;
	}
}
