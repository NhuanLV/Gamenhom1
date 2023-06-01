using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIFind : MonoBehaviour {

	public Transform player;
	public float chaseRange;

	public float maxSpeed = 5f;
	Animator anim;
	public float damageMonster = 1;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {

		if(player == null){
			GameObject goPlayer = GameObject.FindWithTag ("Player");

			if(goPlayer != null){
				player = goPlayer.transform;
			}
		}

		if (player == null)
			return;
		float distanceToTarget = Vector3.Distance (transform.position, player.position);
		if (distanceToTarget < chaseRange) {
			anim.SetBool ("getWalk", true);
			//Monster rotation
			Vector3 dir = player.position - transform.position;
			dir.Normalize ();

			float yAngle = Mathf.Atan2 (dir.x, dir.z) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0, yAngle, 0);

			//Monster run
			//maxSpeed = 5f;
			Vector3 pos = transform.position;
			Vector3 velocity = new Vector3 (0, 0, maxSpeed * Time.deltaTime);
			pos += transform.rotation * velocity;

			transform.position = pos;
		} else {
			anim.SetBool ("getWalk", false);
		}
	}

	IEnumerator OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			anim.SetBool ("getAttack", true);
			yield return new WaitForSeconds (1);
			PlayerHealth thePH = other.gameObject.GetComponent<PlayerHealth> ();
			thePH.addDame (damageMonster);
			anim.SetBool ("getAttack", false);

		}
	}
}
