using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;

	private LevelManager levelManager;
	private int brickHits = 0;
	private bool isBreakable;


	void Start (){
		isBreakable = (gameObject.tag == "Breakable");
		//track amount of breakable bricks in a level
		if (isBreakable){
			breakableCount++;
		}
		Debug.Log ("Number of breakable blocks: " + breakableCount);
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}

	void OnCollisionEnter2D (Collision2D brickCollision){
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.1f);
		if (isBreakable){
			hitHandler();
		}
	}

	void hitHandler(){
		int maxHits = hitSprites.Length + 1;
		brickHits++;
		//Debug.Log ("Brick: " + GetInstanceID() + " /Hits:" + brickHits);
		
		SpriteRenderer brickColor = gameObject.GetComponent (typeof(SpriteRenderer)) as SpriteRenderer;//Get the renderer via GetComponent
		brickColor.color = new Color (brickColor.color.r, brickColor.color.g, brickColor.color.b, 0.5f); // Set to half it's alpha
		
		if (brickHits >= maxHits) {
			breakableCount--;
			Destroy (gameObject);
			levelManager.BrickDestroyed();
			Debug.Log ("Brick Destroyed. Number of breakable blocks remaing: " + breakableCount);
		} else {
			LoadSprites ();
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


}
