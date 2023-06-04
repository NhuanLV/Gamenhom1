using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour {

	public Slider volume;
	public AudioSource myMusic;
	// Use this for initialization
	void Start () {
		myMusic.volume = volume.value;
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
