using UnityEngine;
using System.Collections;

public class finish : MonoBehaviour {

	public persistenceOwn persist;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c) {
		Debug.Log ("Save Finish");
		persist.SendMessage ("savePlayer");
		persist.SendMessage ("loadPlayer");
		Debug.Log ("Level finished: " + Application.loadedLevel);
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
