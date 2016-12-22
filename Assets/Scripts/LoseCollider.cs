using UnityEngine;
using System.Collections;


public class LoseCollider : MonoBehaviour {
	public LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D loseTrigger){
		Debug.Log ("Lose Trigger Detected.");
		levelManager.LoadLevel ("Lose Screen");
	}
	//void OnCollisionEnter2D (Collision2D loseCollider){
	//	Debug.Log ("Lose Collision Detected.");
	//}
}
