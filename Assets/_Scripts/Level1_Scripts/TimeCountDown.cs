using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCountDown : MonoBehaviour {
	public float startTime;
	public Text timeText;

	[SerializeField]
	private GameObject pauseButton, showDeadPanel;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - startTime;
		string minutes = ((int)t / 60).ToString ();
		string seconds = (t %  60).ToString ("f0 ");
		timeText.text = "Time: " + minutes + " : " + seconds;
		//if (minutes.Contains ("0") && seconds.Contains ("0")) {
		//	pauseButton.SetActive (false);
		//	showDeadPanel.SetActive (true);
		//	Time.timeScale = 0;
		//}

	}

}
