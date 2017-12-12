using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public playerController thePlayer; //used to store the player

	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	// Use this for initialization
	void Start () {

		thePlayer = FindObjectOfType<playerController> (); //lets unity know what the playerController is
		lastPlayerPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x; //current position minus last position
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		lastPlayerPosition = thePlayer.transform.position;


	}
}
