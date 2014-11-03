using UnityEngine;
using System.Collections;

public class deathZoneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c) {
		c.SendMessage ("respawn", 0);
	}
}
