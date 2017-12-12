using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollUV : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.x += -Time.deltaTime / 2f;

		mat.mainTextureOffset = offset;
	}
}
