using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControllerScript : MonoBehaviour {

	public static LevelControllerScript instance;
	//GameObject levelSign;
	//int sceneIndex, levelPassed;

	[SerializeField]
	private GameObject pauseButton, showPausePanel, showWinPanel, showDeadPanel;

	// Use this for initialization
	void Start () {
		
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);

		//levelSign = GameObject.Find ("LevelNumber");

		//sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		//levelPassed = PlayerPrefs.GetInt ("LevelPassed");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PauseButton(){
		pauseButton.SetActive (false);
		showPausePanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void ResumeButton(){
		pauseButton.SetActive (true);
		showPausePanel.SetActive (false);
		Time.timeScale = 1;
	}

	public void QuitButton(){
		SceneManager.LoadScene ("MenuPlay");
	}

	public void ShowWinPanel(){
		pauseButton.SetActive (false);
		showWinPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void NextButton(){
		SceneManager.LoadScene ("Level2");
		Time.timeScale = 1;
	}

	public void ShowDeadPanel(){
		pauseButton.SetActive (false);
		showDeadPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void ReturnButton(){
		showDeadPanel.SetActive (false);
		SceneManager.LoadScene ("Level1");
		Time.timeScale = 1;
	}
}
