using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D turtleRigidbody;
	private Animator turtleAnimator;
	private Collider2D turtleCollider;
	private SpriteRenderer turtleSpriteRenderer;



	public float secondsUntilFlip;


	void Start(){

		turtleRigidbody = GetComponent<Rigidbody2D> ();
		turtleAnimator = GetComponent<Animator> ();
		turtleCollider = GetComponent<Collider2D> ();


	}


	void Update(){

		float velocity = 1 * moveSpeed;

		if(secondsUntilFlip > 3){
			transform.Translate (Vector2.right * velocity * Time.deltaTime);
			secondsUntilFlip -= Time.deltaTime;
			//Debug.Log (secondsUntilFlip);
		}
		if (secondsUntilFlip < 3 && secondsUntilFlip > 0) {
			Vector3 theScale = transform.localScale;
			theScale.x = -6;
			transform.localScale = theScale;
			transform.Translate (Vector2.left * velocity * Time.deltaTime);
			secondsUntilFlip -= Time.deltaTime;
			//Debug.Log (secondsUntilFlip);
		}
		if (secondsUntilFlip <= 0) {
			secondsUntilFlip = 6;
			Vector3 theScale = transform.localScale;
			theScale.x = 6;
			transform.localScale = theScale;
			//Debug.Log (secondsUntilFlip);
		}

	}

}
