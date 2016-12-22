using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public int maxHits = 1;
	private int brickHits = 0;
	

	void OnCollisionEnter2D (Collision2D brickCollision){
		brickHits++;
		//Debug.Log ("Brick: " + GetInstanceID() + " /Hits:" + brickHits);
		SpriteRenderer brickColor = gameObject.GetComponent( typeof(SpriteRenderer) ) as SpriteRenderer;//Get the renderer via GetComponent or have it cached previously
		brickColor.color = new Color(0f, 0f, 0f, 1f); // Set to opaque black
		if (brickHits == maxHits){
			Destroy(gameObject);
			Debug.Log ("Brick Destroyed");
		}

	}

}
