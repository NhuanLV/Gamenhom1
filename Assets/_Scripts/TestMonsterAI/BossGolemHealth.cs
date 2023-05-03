using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGolemHealth : MonoBehaviour {

	public float maxHealth;
	float currentHealth;

	public GameObject explosion, wallLantern;

	//public bool drop;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update () {

	}

	public void addDamageBoss(float damage){
		if (damage <= 0)
			return;
		currentHealth -= damage;

		if (currentHealth <= 0) {
			makeDead ();
		}
	}

	void makeDead(){
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
		wallLantern.SetActive (false);
	}
}
