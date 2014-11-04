﻿using UnityEngine;
using System.Collections;

public class GameOverBehavior : MonoBehaviour {

	public GUIStyle guiStyle;
	
	public int counter;
	
	
	
	// Use this for initialization
	void Start () {
		counter = 0;
		//guiStyle = new GUIStyle ();
		guiStyle.normal.textColor = Color.white;
		guiStyle.fontSize = 15;
		
		
	}
	
	void OnGUI() {
		
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
