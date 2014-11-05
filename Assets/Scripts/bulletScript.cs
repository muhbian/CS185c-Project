using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		Debug.Log (this.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime; 
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
}
