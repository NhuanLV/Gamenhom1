using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Health : MonoBehaviour {

	public float healthAmount;
	public float rotationSpeed;

	void Update(){
		transform.Rotate (Vector3.up * rotationSpeed);
		
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			
			PlayerHealth thePH = other.gameObject.GetComponent<PlayerHealth> ();
			thePH.addHealth (healthAmount);
			Destroy (gameObject);
			
		}
	}

}
