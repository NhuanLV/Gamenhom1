using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRobot : MonoBehaviour {

	public float speed = 1000f;
	private Rigidbody rb;

	public GameObject wall_explosion, monster_explosion;

	public float dameGun = 1;

	void Awake(){
		//Explosion_Load ();
	}
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		//Vector3 dir = transform.forward;
		//rb.AddForce (dir * speed);

		rb.AddForce (transform.forward * speed);
		Destroy (transform.gameObject, 0.4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//void Explosion_Load(){
	//	wall_explosion = Resources.Load ("Wall_Explosion") as GameObject;
	//	monster_explosion = Resources.Load ("Monster_Explosion") as GameObject;
	//}
		
	void OnTriggerEnter(Collider other){
		if (other.tag == "Floor") {
			Instantiate (wall_explosion, transform.position, Quaternion.identity);
			Destroy (transform.gameObject);
		}
		if (other.tag == "Monster") {
			MonsterAIHealth theMAI = other.gameObject.GetComponent<MonsterAIHealth> ();
			theMAI.addDamage (dameGun);
			Instantiate (monster_explosion, transform.position, Quaternion.identity);
			Destroy (transform.gameObject);
		} else if (other.tag == "Boss") {
			BossGolemHealth theBH = other.gameObject.GetComponent<BossGolemHealth> ();
			theBH.addDamageBoss (dameGun);
			Instantiate (monster_explosion, transform.position, Quaternion.identity);
			Destroy (transform.gameObject);
		}
	}
}
