using UnityEngine;
using System.Collections;

public class InfiniteRunnerSection : MonoBehaviour {
	private GameObject globalObject; 
	private GameManager gameManager; 
	private float moveSpeed;
	// Use this for initialization
	void Awake () {
		globalObject = GameObject.Find("GlobalObject");
		gameManager = globalObject.GetComponent <GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = gameObject.transform.position;
		moveSpeed = gameManager.GetGameSpeed();
		pos.x -= moveSpeed;
		gameObject.transform.position = pos;
	}
}
