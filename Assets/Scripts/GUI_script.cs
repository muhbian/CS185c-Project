using UnityEngine;
using System.Collections;

public class GUI_script : MonoBehaviour {

	public player player;
	public Texture livesTxtr;
	public Texture ammoTxtr;
	
	public GUIStyle guiStyle;

	public bool gameStarted;

	// Use this for initialization
	void Start () {

		guiStyle.normal.textColor = Color.white;
		guiStyle.fontSize = 12;
	}

	void OnGUI() {

		// Scores
		// GUI.Label (new Rect (10, 20, 16, 16), scoreTxtr, guiStyle);
		string scoreLabel = "Score:";
		GUI.Label (new Rect (10, 32, 20, 20), scoreLabel, guiStyle);
		string score = this.player.score.ToString ();;
		GUI.Label (new Rect (85, 32, 20, 20), score, guiStyle);
		// Lives 16x16
		GUI.Label (new Rect (10, 8, 16, 16), livesTxtr, guiStyle);
		string livesLabel = this.player.lives.ToString ();
		GUI.Label (new Rect (30, 10, 20, 20), livesLabel, guiStyle);
		// Ammo
		if(this.player.hasGun) {
			GUI.Label (new Rect (47, 13, 32, 20), ammoTxtr, guiStyle);
			string ammoLabel = this.player.ammunition.ToString ();
			GUI.Label (new Rect (69, 10, 20, 20), ammoLabel, guiStyle);
		}
	}

	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (this.player.transform.position.x,
		                                       this.player.transform.position.y,
		                                      this.transform.position.z);
	}
}
