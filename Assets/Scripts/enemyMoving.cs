using UnityEngine;
using System.Collections;

public class enemyMoving : MonoBehaviour {

	public float speed;

	public float rightBoundary;
	public float leftBoundary;

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

		// movement of the Enemy on its platform
		if (this.walkingDir == direction.RIGHT) {
			if (actPos.x < rightBoundary) {
				float posX = actPos.x + speed;
				this.gameObject.transform.position = new Vector3 (posX, actPos.y, 0);
			} else {
				this.gameObject.transform.rotation = new Quaternion(0,180,0,0);
				this.walkingDir = direction.LEFT;
			}
		} else {
			if (actPos.x > leftBoundary) {
				float posX = actPos.x - speed;
				this.gameObject.transform.position = new Vector3 (posX, actPos.y, 0);
			} else {
				this.gameObject.transform.rotation = new Quaternion(0,0,0,0);
				this.walkingDir = direction.RIGHT;
			}
					
		}

	}

	void OnTriggerEnter(Collider c) {


	}
}
