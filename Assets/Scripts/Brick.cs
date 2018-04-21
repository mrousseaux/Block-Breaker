using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public int maxHits = 1;
	private LevelManager levelManager;
	private int brickHits = 0;
	

	void OnCollisionEnter2D (Collision2D brickCollision){
		brickHits++;
		//Debug.Log ("Brick: " + GetInstanceID() + " /Hits:" + brickHits);

		SpriteRenderer brickColor = gameObject.GetComponent( typeof(SpriteRenderer) ) as SpriteRenderer;//Get the renderer via GetComponent
		brickColor.color = new Color(brickColor.color.r,brickColor.color.g,brickColor.color.b, 0.5f); // Set to half it's alpha

		if (brickHits >= maxHits){
			Destroy(gameObject);
			Debug.Log ("Brick Destroyed");
			SimulateWin();
		}

	}

	// TODO Remove this method with real win conditions
	void SimulateWin(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadNextLevel();
	}

}
