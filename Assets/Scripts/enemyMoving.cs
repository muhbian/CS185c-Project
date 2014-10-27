using UnityEngine;
using System.Collections;

public class enemyMoving : MonoBehaviour {

	private enum direction {RIGHT, LEFT};
	private float posX;
	private direction walkingDir = direction.RIGHT;
	private CharacterController e;

	// Use this for initialization
	void Start () {
		this.e = (CharacterController) (this.GetComponent("CharacterController"));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 actPos = this.gameObject.transform.position;
		posX = actPos.x;

		// movement of the Enemy on its platform
		if(this.walkingDir == direction.RIGHT) {
			
		}

	}

	void OnTriggerEnter() {


	}
}
