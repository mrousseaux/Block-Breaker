using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public int maxHits = 1;
	private int brickHits = 0;
	

	void OnCollisionEnter2D (Collision2D brickCollision){
		brickHits++;
		Debug.Log ("Brick: " + GetInstanceID() + " /Hits:" + brickHits);
		if (brickHits == maxHits){
			Destroy(gameObject);
			Debug.Log ("Brick Destroyed");
		}

	}

}
