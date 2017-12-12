using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabGenerator : MonoBehaviour {

	public GameObject thePrefab;
	public Transform generationPoint;
	public float distanceBetween;

	private float prefabWidth;

	public int distanceBetweenMin;
	public int distanceBetweenMax;

	//public GameObject[] thePlatforms;
	private int prefabSelector;
	private float[] prefabWidths;


	public objectPooler[] theObjectPools;

	public GameObject waterSource;
	public Transform waterSourceGenerationPoint;
	public Transform prefabGeneratorLocation;
	public float chanceOfWaterSourceSpawn;

	public GameObject turtleMonster;
	public GameObject bossMonster;



	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

		prefabWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {

			prefabWidths [i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;	//width of element i is equal to the boxcollider and size x of the platform

		}



	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			prefabSelector = Random.Range (0, theObjectPools.Length);

			transform.position = new Vector3 (transform.position.x + prefabWidths [prefabSelector] + distanceBetween, 0, transform.position.z);

					

			//Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);

			GameObject newPlatform = theObjectPools [prefabSelector].GetPooledObject (); //create new platform object and it will equal free object in the list
			//Debug.Log (newPlatform);

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			if (newPlatform.name == ("Platform1(Clone)")) {
				waterSourceGenerationPoint.position = new Vector3 (transform.position.x, prefabGeneratorLocation.position.y - 4, transform.position.z);
				//Debug.Log (prefabGeneratorLocation.position.y - 4);
			} else if (newPlatform != GameObject.Find ("Platform1(Clone)")){
				waterSourceGenerationPoint.position = new Vector3 (transform.position.x, prefabGeneratorLocation.position.y - 3, transform.position.z);
				//Debug.Log (prefabGeneratorLocation.position.y - 3);
			}
			//Debug.Log (Random.value);
			if (Random.value > 0.9) {
				Instantiate (waterSource, waterSourceGenerationPoint.position, waterSourceGenerationPoint.rotation);
				//Debug.Log (Random.value);
			}
			if (Random.value > 0.6 && Random.value < 0.9) {
				Instantiate (turtleMonster, waterSourceGenerationPoint.position, waterSourceGenerationPoint.rotation);
				//Debug.Log (Random.value);
			}
			if (Random.value < 0.2) {
				Instantiate (bossMonster, waterSourceGenerationPoint.position, waterSourceGenerationPoint.rotation);
				//Debug.Log (Random.value);
			}

		}

	}
}
