using UnityEngine;
using System.Collections;

public class GUI_script : MonoBehaviour {

	public player player;
	public Texture livesTxtr;
	public Texture ammoTxtr;


	public 
	// Use this for initialization
	void Start () {
	

	}

	void OnGUI() {

		GUIStyle guiStyle = new GUIStyle();
		guiStyle.normal.textColor = Color.white;
		guiStyle.fontSize = 12;

		// Scores
		// GUI.Label (new Rect (10, 20, 16, 16), scoreTxtr, guiStyle);
		string scoreLabel = "Score: " + this.player.score.ToString();
		GUI.Label (new Rect (10, 10, 20, 20), scoreLabel, guiStyle );
		// Lives 16x16
		GUI.Label (new Rect (10, 30, 16, 16), livesTxtr, guiStyle);
		string livesLabel = this.player.lives.ToString ();
		GUI.Label (new Rect (28, 30, 20, 20), livesLabel, guiStyle);
		// Ammo
		GUI.Label (new Rect (10, 53, 16, 10), ammoTxtr, guiStyle);
		string ammoLabel = this.player.ammunition.ToString ();
		GUI.Label (new Rect (28, 50, 20, 20), ammoLabel, guiStyle);
	
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
