using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {
	public float maxHealth = 3;
	float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDame(float dame){
		if (dame <= 0)
			return;
		currentHealth -= dame;

		if (currentHealth <= 0) {
			MonsterState theMS = transform.gameObject.GetComponent<MonsterState> ();
			theMS.MonsterCheckDead ();
		} else {
			return;
		}
	}

}
