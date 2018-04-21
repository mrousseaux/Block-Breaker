using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites;

	private LevelManager levelManager;
	private int brickHits = 0;
	

	void OnCollisionEnter2D (Collision2D brickCollision){
		if (gameObject.tag == "Unbreakable") {
		} else {
			int maxHits = hitSprites.Length + 1;
			brickHits++;
			//Debug.Log ("Brick: " + GetInstanceID() + " /Hits:" + brickHits);

			SpriteRenderer brickColor = gameObject.GetComponent (typeof(SpriteRenderer)) as SpriteRenderer;//Get the renderer via GetComponent
			brickColor.color = new Color (brickColor.color.r, brickColor.color.g, brickColor.color.b, 0.5f); // Set to half it's alpha

			if (brickHits >= maxHits) {
				Destroy (gameObject);
				Debug.Log ("Brick Destroyed");
				//SimulateWin ();
			} else {
				LoadSprites ();
			}
		}

	}

	void LoadSprites(){
		int sprintIndex = brickHits - 1;
		if (hitSprites [sprintIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [sprintIndex];
		} else {
			Debug.Log ("Block is missing a Hit Sprit at index: " + sprintIndex);
		}
	}


	// TODO Remove this method with real win conditions
	void SimulateWin(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadNextLevel();
	}

}
