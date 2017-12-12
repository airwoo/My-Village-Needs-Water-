using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonController : MonoBehaviour {

	private Collider2D dragonCollider;
	public float moveSpeed;

	void Start(){

		dragonCollider = GetComponent<Collider2D> ();

	}

	void Update(){
		float velocity = 1 * moveSpeed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime); 
	}
}
