using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLichAI_Find : MonoBehaviour {

	public Transform player;
	public float chaseRange;

	Animator anim;
	public float damageMonster = 2;

	public Transform gunBarrel;
	public GameObject bulletLich;
	public float fireDelay = 1f;
	float coolDownTime = 0;
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
			anim.SetBool ("getAttack", true);
			//Monster rotation
			Vector3 dir = player.position - transform.position;
			dir.Normalize ();

			float yAngle = Mathf.Atan2 (dir.x, dir.z) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0, yAngle, 0);

			Shot ();

		} else {
			anim.SetBool ("getAttack", false);
			return;
		}
	}

	void Shot(){
		coolDownTime -= Time.deltaTime;

		if(coolDownTime <= 0){
			coolDownTime = fireDelay;
			Instantiate (bulletLich, gunBarrel.position, gunBarrel.rotation);

		}
	}
		
}
