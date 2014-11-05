using UnityEngine;
using System.Collections;

public class GameOverBehavior : MonoBehaviour {

	public GUIStyle guiStyle;
	
	public int counter;
	
	public persistenceOwn persist;

	// Use this for initialization
	void Start () {
		counter = 0;
		//guiStyle = new GUIStyle ();
		guiStyle.normal.textColor = Color.white;
		guiStyle.fontSize = 15;
		persist.SendMessage ("loadPlayer");
	}
	
	void OnGUI() {

		if (persist.score == persist.highscore) {
			string recordLabel = "You set a new high score!";
			string scoreReached = "You reached a total score of: " + persist.score.ToString (); 
			GUI.Label (new Rect (0, 400, 800, 50), recordLabel, guiStyle);
			GUI.Label (new Rect (0, 430, 800, 50), scoreReached, guiStyle);
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
			Application.LoadLevel ("TestLevel");
			Debug.Log ("Start Game - Level 1");
		}

		if (Input.GetButtonDown ("Escape") || Input.GetButtonDown ("Q")) {
			Application.Quit();
		}
		
		
		
	}
}
