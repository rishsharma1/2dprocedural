using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	private Rigidbody2D rigidBody;
	private Animator animator;
	public float speed;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask ground;

	private bool isGrounded;
	private bool isJump;
	[SerializeField]
	private float jumpForce;


	void Start () {

		rigidBody = this.GetComponent<Rigidbody2D> ();
		animator = this.GetComponent<Animator> ();
	}
	
	void FixedUpdate () {

		float horizontal = Input.GetAxis ("Horizontal");
		isJump = Input.GetKeyDown ("space");
		isGrounded = isOnGround ();

		playerMove (horizontal);
		
	}

	private void playerMove(float horizontal) {


		if (isGrounded && isJump) {
			isGrounded = false;
			rigidBody.AddForce (new Vector2 (0, jumpForce));
		
		}

		if (isGrounded) {
			rigidBody.velocity = new Vector2 (horizontal * speed, rigidBody.velocity.y);
			animator.SetFloat ("speed", Mathf.Abs(horizontal));

		}


	}

 	private bool  isOnGround() {

		if (rigidBody.velocity.y <= 0) {

			foreach (Transform point in groundPoints) {

				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, ground);

				foreach (Collider2D collider in colliders) {

					if (collider.gameObject != gameObject) {
						return true;
					}
				}
			}
		}

		return false;
	}

	public void setPlayerPosition(float height) {

		this.transform.position = new Vector2 (0, height);
	}


}
