using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollow : MonoBehaviour {

	public GameObject thePlayer;
	public float targetDistance;
	public float allowedRange = 10;
	public GameObject theMonster;
	public float monsterSpeed;
	public int attackTrigger;
	public RaycastHit shot;

	// Update is called once per frame
	void Update () {
		transform.LookAt (thePlayer.transform);
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot)){
			targetDistance = shot.distance;
			if (targetDistance < allowedRange) {
				monsterSpeed = 0.1f;
				if (attackTrigger == 0) {
					theMonster.GetComponent<Animation> ().Play ("Walk");
					transform.position = Vector3.MoveTowards (transform.position, thePlayer.transform.position, monsterSpeed);
				}
			} else {
				monsterSpeed = 0;
				theMonster.GetComponent<Animation> ().Play ("Idle");
			}
		}

		if(attackTrigger == 1){
			monsterSpeed = 0;
			theMonster.GetComponent<Animation> ().Play ("Attack02");
		}
	}

	void OnTriggerEnter(){
		attackTrigger = 1;
	}

	void OnTriggerExit(){
		attackTrigger = 0;
	}
}
