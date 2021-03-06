﻿using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private PlayerPaddle paddle;//public method into a variable.
	private Vector3 paddleToBallVector;
	private bool startState = false;

	// Use this for initialization
	void Start () {
		//set the paddle script to the PlayerPaddle object for prefab purposes.
		paddle = GameObject.FindObjectOfType<PlayerPaddle>();
		//calculate paddle to ball offset
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (startState == false){//has the game started? if not, attach the ball to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0)){ //on mouse click, change the game has started
				startState = true;
				Debug.Log ("Left Mouse Clicked, Launch Ball");
				this.rigidbody2D.velocity = new Vector2 (Random.Range(-3,3),10f);//give the ball some velocity
			} 
		}

	}

	void OnCollisionEnter2D (Collision2D ballCollision){
		//Play audio if game has started
		Vector2 randomTweak = new Vector2 (Random.Range (-0.2f, 0.2f), Random.Range (0f, 0.2f));
		if (startState) {
			audio.Play ();
			this.rigidbody2D.velocity += randomTweak;
			print(randomTweak);
		}
	}
}
