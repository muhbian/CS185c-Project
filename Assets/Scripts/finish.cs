using UnityEngine;
using System.Collections;

public class finish : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c) {
		Debug.Log ("next Level");
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
