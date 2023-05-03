using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryController : MonoBehaviour {
	//tham chiếu đến đối tượng trò chơi có kiểm soát.
	public GameObject scrifi, monster1, monster2, monster3, monster4;

	//Bien chua Model nao dag hoat dong
	int whichModelIsOn = 1;


	// Use this for initialization
	void Start () {

		scrifi.gameObject.SetActive (true);
		monster1.gameObject.SetActive (false);
		monster2.gameObject.SetActive (false);
		monster3.gameObject.SetActive (false);
		monster4.gameObject.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

	}

	public void BackButton(){
		SceneManager.LoadScene ("MenuScreen");	
	}

	//Cach chuyen Model bang cach an nut UI button
	public void SwitchModel(){

		//Xu ly bien whichModelIsOn
		switch(whichModelIsOn){
		//Neu scrifi dc bat
		case 1:
			//Sau do la Monster1
			whichModelIsOn = 2;

			scrifi.gameObject.SetActive (false);
			monster1.gameObject.SetActive (true);
			break;

		case 2:
			whichModelIsOn = 3;

			monster1.gameObject.SetActive (false);
			monster2.gameObject.SetActive (true);
			break;

		case 3:
			whichModelIsOn = 4;

			monster2.gameObject.SetActive (false);
			monster3.gameObject.SetActive (true);
			break;

		case 4:
			whichModelIsOn = 5;

			monster3.gameObject.SetActive (false);
			monster4.gameObject.SetActive (true);
			break;

		case 5:
			whichModelIsOn = 1;

			monster4.gameObject.SetActive (false);
			scrifi.gameObject.SetActive (true);
			break;
		}
	}
}
