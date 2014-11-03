using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime; 
		Debug.Log (this.transform.position);
	}
}
