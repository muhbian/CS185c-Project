using UnityEngine;
using System.Collections;

public class crate : MonoBehaviour {
	public enum ContentTypes{Ammunition, PogoCharges, Score};

	public ContentTypes content;
	public int value;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			switch(this.content) {
			case ContentTypes.Ammunition:
				c.SendMessage("addAmmunition",value);
				break;
			case ContentTypes.PogoCharges:
				c.SendMessage("addPogoCharges",value);
				break;
			case ContentTypes.Score:
				c.SendMessage("addScore",value);
				break;
			default:
				break;
			} 
			GameObject.Destroy(this.gameObject);
		}
	}

}
