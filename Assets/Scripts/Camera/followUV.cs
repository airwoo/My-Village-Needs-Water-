using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followUV : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.x = transform.position.x / transform.localScale.x;


		mat.mainTextureOffset = offset;
	}
}
