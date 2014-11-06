using UnityEngine;
using System.Collections;

public class crate : MonoBehaviour {
	public enum ContentTypes{Ammunition, Score};

	public ContentTypes content;
	public int value;

	public Sprite ammoSprite;
	public Sprite tenPoints;
	public Sprite fiftyPoints;
	public Sprite hundredPoints;

	public AudioClip collectSound;



	// Use this for initialization
	void Start () {
		SpriteRenderer sr = this.GetComponent<SpriteRenderer> ();

		switch (this.content) {
		case ContentTypes.Ammunition:
			sr.sprite = this.ammoSprite;
			break;

		case ContentTypes.Score:
			switch (this.value) {
			case 10:
				sr.sprite = this.tenPoints;
				break;
			case 50:
				sr.sprite = this.fiftyPoints;
				break;

			case 100:
				sr.sprite = this.hundredPoints;
				break;
			}
			break;
		}

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
			case ContentTypes.Score:
				c.SendMessage("addScore",value);
				break;
			default:
				break;
			} 
			AudioSource.PlayClipAtPoint(this.collectSound, this.transform.position);
			GameObject.Destroy(this.gameObject);
		}
	}

}
