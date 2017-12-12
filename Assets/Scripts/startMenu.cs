using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

	public GameObject startGame;
	public GameObject showInstructionsMenu;
	public GameObject imgForText;

	public void PlayGame(){
		SceneManager.LoadScene ("scene1");
	}

	public void seeInstructions(){
		startGame.SetActive (false);
		showInstructionsMenu.SetActive (true);
		imgForText.SetActive (true);
	}

	public void goBackToStart(){
		startGame.SetActive (true);
		showInstructionsMenu.SetActive (false);
		imgForText.SetActive (false);
	}
}
