using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public playerController thePlayer;
	private Vector3 playerStartPoint;

	private prefabDestroyer[] platformList;

	public GameObject[] waterSourcesToBeDestroyed;
	public GameObject[] turtleMonstersToBeDestroyed;
	public GameObject[] bossMonstersToBeDestroyed;

	public GameObject dragonPrefab;
	public Transform dragonStartPoint;

	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	public GameObject gameOverScreen;
	public Text ScoreWater;
	private int score;


	// Use this for initialization
	void Start () {
		//GameObject villageHero = GameObject.FindWithTag ("Player");
		//playerController villageHeroScript = villageHero.GetComponent<playerController> ();
		//villageHeroScript.playerHealth = 3;
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

	}

	// Update is called once per frame
	void Update () {
		score = thePlayer.score;
	}

	public void RestartGame(){
		StartCoroutine ("RestartGameCo");
	}

	public IEnumerator RestartGameCo() {
		thePlayer.gameObject.SetActive (false);
		gameOverScreen.SetActive (true);
		ScoreWater.text = ("Score: " + score.ToString ());
		yield return new WaitForSeconds (5f);
		gameOverScreen.SetActive (false);

		platformList = FindObjectsOfType<prefabDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);

		}

		waterSourcesToBeDestroyed = GameObject.FindGameObjectsWithTag ("waterSource");
		for(int i =0; i < waterSourcesToBeDestroyed.Length; i++){
			Destroy (waterSourcesToBeDestroyed [i]);
		}

		turtleMonstersToBeDestroyed = GameObject.FindGameObjectsWithTag ("turtleMonster");
		for(int i =0; i < turtleMonstersToBeDestroyed.Length; i++){
			Destroy (turtleMonstersToBeDestroyed [i]);
		}

		bossMonstersToBeDestroyed = GameObject.FindGameObjectsWithTag ("bossMonster");
		for(int i =0; i < bossMonstersToBeDestroyed.Length; i++){
			Destroy (bossMonstersToBeDestroyed [i]);
		}

		dragonPrefab.transform.position = dragonStartPoint.transform.position;

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		heart1.SetActive (true);
		heart2.SetActive (true);
		heart3.SetActive (true);
	}

}
