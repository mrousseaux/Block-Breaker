using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	public PlayerPaddle paddle;//public method into a variable.
	private Vector3 paddleToBallVector;
	private bool startState = false;

	// Use this for initialization
	void Start () {
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
				this.rigidbody2D.velocity = new Vector2 (2f,10f);//give the ball some velocity
			} 
		}

	}
}
