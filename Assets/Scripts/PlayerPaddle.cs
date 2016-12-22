using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		Vector3 paddlePos = new Vector3 (mousePosInBlocks, this.transform.position.y, this.transform.position.z);

		paddlePos.x = Mathf.Clamp (mousePosInBlocks,0.5f,15.5f);

		this.transform.position = paddlePos;

	}
	
}
