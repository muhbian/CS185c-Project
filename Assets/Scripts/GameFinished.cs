using UnityEngine;
using System.Collections;

public class GameFinished : MonoBehaviour {

	public GUIStyle guiStyle;

	public GUIStyle scoreStyle;
	
	public int counter;

	public persistenceOwn persist;

	public GameObject congrats;
	
	
	// Use this for initialization
	void Start () {
		counter = 0;
		//guiStyle = new GUIStyle ();
		guiStyle.normal.textColor = Color.white;
		guiStyle.fontSize = 15;
		scoreStyle.normal.textColor = Color.white;
		persist.SendMessage ("loadPlayer");
		congrats.renderer.enabled = false;
		
	}
	
	void OnGUI() {

		if (persist.score == persist.highscore) {

			congrats.renderer.enabled = true;
			string recordLabel = "You set a new high score!";
			string scoreReached = "You reached a total score of: " + persist.score.ToString (); 
			GUI.Label (new Rect (0, 350, 800, 50), recordLabel, guiStyle);
			GUI.Label (new Rect (0, 375, 800, 50), scoreReached, guiStyle);
		} else {
			string scoreLabel = "You reached a total score of:";
			GUI.Label (new Rect (190, 320, 800, 50), scoreLabel, scoreStyle);
			string score = this.persist.score.ToString ();
			GUI.Label (new Rect (630, 320, 800, 50), score, scoreStyle);
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
		}

		if (Input.GetButtonDown ("Escape") || Input.GetButtonDown ("Q")) {
			Application.Quit();
		}
		
		
		
	}
}
