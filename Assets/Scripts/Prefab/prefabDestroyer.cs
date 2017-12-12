using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;
	//public GameObject waterSourceDestructionPoint;

	// Use this for initialization
	void Start () {
		platformDestructionPoint = GameObject.Find ("platformDestructionPoint"); // look for "" on gameobject and make it the value of the variable
		//waterSourceDestructionPoint = GameObject.Find("waterSourceDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < platformDestructionPoint.transform.position.x) {	//if position x of platform is less than destruction point then destroy it

			//Destroy (gameObject); //destroy the gameobject that the script is attached too
			//for better runtime to avoid garbage collector

			gameObject.SetActive (false);
		}

		//if (transform.position.x < waterSourceDestructionPoint.transform.position.x) {
		//	Destroy (gameObject);
		//}
			

	}
}
