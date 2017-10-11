using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Animator anim;
	private bool isJumping;
	private float moveSpeed = 5f;
    private Rigidbody rigid;


	public float jumpHeight = 5.0f;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		isJumping = true;
        rigid = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = gameObject.transform.position;
		moveSpeed = 20.0f;
	//	rigidbody.mass = 100;
		//Input
		if (Input.GetButton ("Jump") && !isJumping) {
			rigid.AddForce (0,jumpHeight,0);

		}  else if (Input.GetButtonUp ("Jump")) {
			rigid.AddForce(0, -jumpHeight * 50,0);
		}
		//Left/Right
		if (Input.GetAxis("Horizontal") != 0) {
			pos.x += Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		}

/*		//depth... need to fix colliders on camera
		if (Input.GetAxis ("Vertical") != 0) {
			pos.z += Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime / 3;
		}
*/
		//Running
		if (Input.GetButton ("Run"))	{
			moveSpeed += 15.0f;
		}

		gameObject.transform.position = pos;

		//Animations
		if (Input.GetButton ("Run"))	{
			anim.SetBool ("isRunning", true);
		} else if (Input.GetButtonUp ("Run")) {
			anim.SetBool ("isRunning", false);
		}

		if (Input.GetButton ("Jump"))	{
			anim.SetBool ("isJumping", true);
		} else if (Input.GetButtonUp ("Jump")) {
	//		rigidbody.mass = 100000;
		}


	}

	void OnCollisionEnter(Collision col) {
		//Add more as objects can be jumped on... OR Figure out how to use layers properly
		if(col.gameObject.name == "Floor" || col.gameObject.name == "Crate") {
			isJumping = false;
			anim.SetBool ("isJumping", false);
		} else {
			isJumping = true;
		}
	}
}