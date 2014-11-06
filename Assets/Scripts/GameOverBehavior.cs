using UnityEngine;
using System.Collections;

public class GameOverBehavior : MonoBehaviour {

	public GUIStyle guiStyle;
	
	public int counter;

	public GameObject congrats;
	
	public persistenceOwn persist;

	// Use this for initialization
	void Start () {
		counter = 0;
		//guiStyle = new GUIStyle ();
		guiStyle.normal.textColor = Color.white;
		guiStyle.fontSize = 15;
		Debug.Log ("Load Const GO");
		persist.SendMessage ("loadPlayer");
		congrats.renderer.enabled = false;
	}
	
	void OnGUI() {

		if (persist.score == persist.highscore) {
			if (counter < 80) {
				congrats.renderer.enabled = true;
			} else if (counter < 120) {
				congrats.renderer.enabled = false;
			}
			string recordLabel = "You set a new high score!";
			string scoreReached = "You reached a total score of: " + persist.score.ToString (); 
			GUI.Label (new Rect (0, 350, 800, 50), recordLabel, guiStyle);
			GUI.Label (new Rect (0, 375, 800, 50), scoreReached, guiStyle);
		}

		if (counter < 130) {
			counter++;
			string startGame = "--- Press space to start another game ---";
			GUI.Label (new Rect (0, 500, 800, 50), startGame, guiStyle);
			string quitGame = "--- Press Escape button to quit ---";
			GUI.Label (new Rect (0, 530, 800, 50), quitGame, guiStyle);
			
			
			
		} else if (counter < 160) {
			counter ++;
		} else {
			counter = 0;
		}
		
		if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Space")) {
			Application.LoadLevel (1);
			Debug.Log ("Start Game - Level 1");
		}

		if (Input.GetButtonDown ("Escape") || Input.GetButtonDown ("Q")) {
			Application.Quit();
		}
		
		
		
	}
}
