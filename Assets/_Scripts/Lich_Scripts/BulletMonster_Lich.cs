using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMonster_Lich : MonoBehaviour {
	
	public float maxSpeed = 20f;
	public float damageMonster;
	public GameObject wall_explosion;

	// Use this for initialization
	void Start () {
		Destroy (transform.gameObject, 2f);
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, 0, maxSpeed* Time.deltaTime);

		pos += transform.rotation * velocity;

		transform.position = pos;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			PlayerHealth thePH = other.gameObject.GetComponent<PlayerHealth> ();
			thePH.addDame (damageMonster);
			Destroy (transform.gameObject);
		}
		if(other.tag == "Floor"){
			Instantiate (wall_explosion, transform.position, Quaternion.identity);
			Destroy (transform.gameObject);
		}
	}
}
