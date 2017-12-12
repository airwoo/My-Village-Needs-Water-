using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D bossRigidbody;
	private Animator bossAnimator;
	private Collider2D bossCollider;
	private SpriteRenderer bossSpriteRenderer;



	public float secondsUntilFlip;


	void Start(){

		bossRigidbody = GetComponent<Rigidbody2D> ();
		bossAnimator = GetComponent<Animator> ();
		bossCollider = GetComponent<Collider2D> ();


	}


	void Update(){

		float velocity = 1 * moveSpeed;

		if(secondsUntilFlip > 2){
			transform.Translate (Vector2.right * velocity * Time.deltaTime);
			secondsUntilFlip -= Time.deltaTime;
			//Debug.Log (secondsUntilFlip);
		}
		if (secondsUntilFlip < 2 && secondsUntilFlip > 0) {
			Vector3 theScale = transform.localScale;
			theScale.x = -2.5f;
			transform.localScale = theScale;
			transform.Translate (Vector2.left * velocity * Time.deltaTime);
			secondsUntilFlip -= Time.deltaTime;
			//Debug.Log (secondsUntilFlip);
		}
		if (secondsUntilFlip <= 0) {
			secondsUntilFlip = 4;
			Vector3 theScale = transform.localScale;
			theScale.x = 2.5f;
			transform.localScale = theScale;
			//Debug.Log (secondsUntilFlip);
		}

	}

}