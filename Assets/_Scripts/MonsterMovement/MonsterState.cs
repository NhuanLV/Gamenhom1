using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class MonsterState : MonoBehaviour {
	Transform player;
	NavMeshAgent nav;

	private Animator anim;
	public float damageMonster = 1;

	public float attackDelay = 1;
	public float attackTimer = 0;

	// Use this for initialization
	void Start () {
		GameObject_Load ();
	}

	// Update is called once per frame
	void Update () {
		FindPlayer ();

	}

	void GameObject_Load(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}

	void FindPlayer(){
		if (player == null)
			return;
		nav.SetDestination (player.position);

		if(player.GetComponent<PlayerHealth>()){
			anim.SetTrigger ("playerDead");
			nav.enabled = false;
			return;
		}
	}

	public void MonsterCheckDead(){
		anim.SetTrigger ("dead");
		nav.enabled = false;
		Destroy (transform.gameObject, 1);
	}


	IEnumerator OnTriggerEnter(Collider other){
		if (other.tag == "BulletRobot") {
			anim.SetBool ("getHit", true);
			nav.enabled = false;
			yield return new WaitForSeconds (1);
			nav.enabled = true;
			anim.SetBool ("getHit", false);
		}

		if (other.tag == "Player") {
			anim.SetBool ("attack", true);
			nav.enabled = false;
			yield return new WaitForSeconds (1);
			PlayerHealth thePH = other.gameObject.GetComponent<PlayerHealth> ();
			thePH.addDame (damageMonster);
			nav.enabled = true;
			anim.SetBool ("attack", false);
		} 
	}
		
}
