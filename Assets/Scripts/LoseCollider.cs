using UnityEngine;
using System.Collections;


public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D loseTrigger){
		// sets LevelManager to proper script, sends player to lose screen.
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		Debug.Log ("Lose Trigger Detected.");
		levelManager.LoadLevel ("Lose Screen");
	}
	//void OnCollisionEnter2D (Collision2D loseCollider){
	//	Debug.Log ("Lose Collision Detected.");
	//}
}
