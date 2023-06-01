using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 4.0F;
	public CharacterController controller;
	public Animator anim;
	public bool isMovingHorizontalLeft = false;
	public bool isMovingHorizontalRight = false;
	public bool isMovingVerticalUp = false;
	public bool isMovingVerticalDown = false;

	public Camera cam;
	public float camRayLength = 100f;
	//Rigidbody playerRigidbody;
	int floorMask;

	public Transform playerCamera;

	public Transform gunBarrel;
	public float shotTimer = 0;
	public float shotDelay= 0.2f;
	public GameObject gunParticles;
	public GameObject bulletRobot;

	public AudioSource audioSource;
	public AudioClip shotPlayer;

	void Awake(){
		floorMask = LayerMask.GetMask ("Floor");//de khi goi bien nay` thi model nao co Layer la "Floor"
		//thi duong Draw se bi chặn lại.
		//playerRigidbody = GetComponent<Rigidbody> ();
		//anim = GameObject.Find ("Player").GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		AddMovement ();
		AddLook ();
		AddShot ();
	}

	void AddMovement(){
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		controller.SimpleMove (movement * speed);

		//Animator
		isMovingHorizontalLeft = false;
		isMovingHorizontalRight = false;
		isMovingVerticalUp = false;
		isMovingVerticalDown = false;

		float positionZ = transform.position.z;
		float positionX = transform.position.x;
		//Debug.Log ("PositionZ:  "+positionZ);
		//Debug.Log (positionX);

		if (moveVertical != 0) {
			float vz = transform.position.z - positionZ;
			//Debug.Log ("VZ: "+vz);
			if(vz > positionZ){
				isMovingVerticalUp = true;
			}
			if(vz < positionZ){
				isMovingVerticalDown = true;
			}
		} else if (moveHorizontal != 0) {
			float hx = transform.position.x - positionX;
			//Debug.Log (hx);
			if(hx > positionX){
				isMovingHorizontalRight = true;
			}
			if(hx < positionX){
				isMovingHorizontalLeft = true;
			}
		}
		anim.SetBool ("isMovingVerticalUp", isMovingVerticalUp);
		anim.SetBool ("isMovingVerticalDown", isMovingVerticalDown);
		anim.SetBool ("isMovingHorizontalRight", isMovingHorizontalRight);
		anim.SetBool ("isMovingHorizontalLeft", isMovingHorizontalLeft);

	}

	void AddLook(){
		Ray camRay = cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		//Debug.DrawRay (cam.transform.position, camRay.direction * 1000f, Color.green);//DrawRay de ve duong co 1 diem

		if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)){
			Debug.DrawLine (cam.transform.position, floorHit.point, Color.blue);//draw tai vi tri camera

			Vector3 playerMouse = floorHit.point - transform.position;
			Debug.DrawRay (transform.position, playerMouse, Color.yellow);//draw tai vi tri player
			playerMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerMouse);
			playerCamera.rotation = newRotation;
			//playerRigidbody.MoveRotation (newRotation);
		}
	}

	void AddShot(){
		shotTimer += Time.deltaTime;//chưa tối ưu vì n liên tục tạo biến, chương trình lớn ko nên dùng
		if(shotTimer < shotDelay) return;

		if(Input.GetAxis("Fire1")==0) return;
		shotTimer = 0;

		GameObject obj;
		obj= Instantiate(gunParticles, gunBarrel.position, gunBarrel.rotation);
		obj.transform.parent = gunBarrel;//để gunParticles luôn ở đầu súng
		Destroy (obj, 0.4f);

		Instantiate (bulletRobot, gunBarrel.position, gunBarrel.rotation);
		audioSource.PlayOneShot (shotPlayer);
	}

	public GameObject sigsag, cross;
	void OnTriggerEnter(Collider other){
		if (other.tag == "SigSag_Trigger") {
			sigsag.SetActive (false);
		} else if (other.tag == "Cross_Trigger") {
			cross.SetActive (false);
		}else if (other.tag == "Win") {
			LevelControllerScript.instance.ShowWinPanel();
		}else if(other.tag == "Item_BulletReal"){
			bulletRobot = Resources.Load ("BulletPlayer_Fire_1_Real") as GameObject;
			Destroy (other.gameObject);
		}else if(other.tag == "Item_BulletCartoon"){
			bulletRobot = Resources.Load ("BulletPlayer_Fire_1_Cartoon") as GameObject;
			Destroy (other.gameObject);
		}
	}
}
