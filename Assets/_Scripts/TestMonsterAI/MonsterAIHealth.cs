using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIHealth : MonoBehaviour {

	public float maxHealth;
	float currentHealth;
	[SerializeField]
	private GameObject explosion, item;

	//public bool drop;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update () {

	}

	public void addDamage(float damage){
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
		Vector3 temp = transform.position;
		temp.y += 1f;
		Instantiate (item, temp, transform.rotation);
	}
}
