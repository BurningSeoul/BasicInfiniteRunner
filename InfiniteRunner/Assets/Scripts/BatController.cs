using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))	{
			anim.SetBool("glide", true);
		}
	}
}
