using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 3;
	float currentHealth;
	public GameObject diePartical;

	public Slider playerHealthSlider;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		playerHealthSlider.maxValue = maxHealth;
		playerHealthSlider.value = maxHealth;  
	}

	// Update is called once per frame
	void Update () {

	}

	public void addDame(float dame){
		if (dame <= 0)
			return;
		currentHealth -= dame;
		playerHealthSlider.value = currentHealth;//thanh slider sẽ giảm dần

		if (currentHealth <= 0) {
			Instantiate (diePartical, transform.position, transform.rotation);
			LevelControllerScript.instance.ShowDeadPanel ();

		}			
	}

	public void addHealth(float healthAmount){
		currentHealth += healthAmount;
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
		playerHealthSlider.value = currentHealth;
	}
}
