using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	private Rigidbody2D rigidBody;
	private Animator animator;
	public float speed;

	void Start () {

		rigidBody = this.GetComponent<Rigidbody2D> ();
		animator = this.GetComponent<Animator> ();
	}
	
	void FixedUpdate () {

		float horizontal = Input.GetAxis ("Horizontal");
		Debug.Log (horizontal);
		playerMove (horizontal);
		
	}

	private void playerMove(float horizontal) {

		rigidBody.velocity = new Vector2 (horizontal*speed, rigidBody.velocity.y);
		animator.SetFloat ("speed", Mathf.Abs(horizontal));

	}

	public void setPlayerPosition(float height) {

		this.transform.position = new Vector2 (0, height);
	}


}
