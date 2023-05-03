using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControllerScreenPlay : MonoBehaviour {

	public void level1Button(){
		SceneManager.LoadScene ("Level1");
		Time.timeScale = 1;
	}
	public void level2Button(){
		SceneManager.LoadScene ("Level2");
		Time.timeScale = 1;
	}

	public void backButton(){
		SceneManager.LoadScene ("MenuScreen");	
	}
}
