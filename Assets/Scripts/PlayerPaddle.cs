using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public bool autoPlay = false;

	private BallScript ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<BallScript>();
	}
	// Update is called once per frame
	void Update () {
		if (autoPlay) {
			AutoPlay ();
		} else {
			MoveWithMouse ();
		}
	}
	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x,0.5f,15.5f);
		this.transform.position = paddlePos;
	}

	void MoveWithMouse(){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (mousePosInBlocks, this.transform.position.y, this.transform.position.z);
		paddlePos.x = Mathf.Clamp (mousePosInBlocks,0.5f,15.5f);
		this.transform.position = paddlePos;
	}
}
