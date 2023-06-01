using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPS : MonoBehaviour {
	public float mouseSensitivity = 3f, moveSpeed = 3f;
	public GameObject eyes;

	private float moveFB, moveLR, rotX, rotY;
	private CharacterController player;

	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement(){
		moveFB = Input.GetAxis ("Vertical") * moveSpeed;
		moveLR = Input.GetAxis ("Horizontal") * moveSpeed;

		rotX = Input.GetAxis ("Mouse X") * mouseSensitivity;
		rotY = Input.GetAxis ("Mouse Y") * mouseSensitivity;

		Vector3 movement = new Vector3 (moveLR, 0, moveFB);

		transform.Rotate (0, rotX, 0);

		movement = transform.rotation * movement;

		eyes.transform.localRotation = Quaternion.Euler (rotY, 0, 0);

		player.Move (movement * Time.deltaTime);
	}
}
