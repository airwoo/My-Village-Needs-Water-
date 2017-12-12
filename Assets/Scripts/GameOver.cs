using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverScreen;
	public Text scoreWater;
	public int score;
	private bool gameOver;
	public GameObject player;
	private playerController playerScript;


	void Start(){
		playerScript = player.GetComponent<playerController> ();
	}

	void Update(){
		if (gameOver == true) {
			if(Input.GetKeyDown(KeyCode.R)){
				SceneManager.LoadScene("scene1");
			}
		}
	}

	public IEnumerator ActivateGameOver(){
		yield return new WaitForSeconds (1f);
		gameOverScreen.SetActive (true);
		score = playerScript.score;
		scoreWater.text = ("Score: " + score.ToString());
		gameOver = true;

	}
}
