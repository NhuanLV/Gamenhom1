using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerLv1 : MonoBehaviour {

	public GameObject[] spawns;
	public float spawn_call_delay = 3f;
	public float spawn_delay = 5f;

	public GameObject[] monsters;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnMonster", spawn_call_delay, spawn_delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnMonster(){
		GameObject monster;
		GameObject spawn_point;

		monster = Monster_Load ();
		spawn_point = Point_Load ();
		Instantiate (monster, spawn_point.transform.position, Quaternion.identity);

	}

	GameObject Monster_Load(){
		int index = Random.Range (0, monsters.Length);
		return monsters [index];
	} 

	GameObject Point_Load(){
		int index = Random.Range (0, spawns.Length);
		return spawns [index];
	}

}
