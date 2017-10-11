using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.name == "Miner") {
			Destroy (col.gameObject);
			GameObject.Find ("GlobalObject").GetComponent <GameManager>().state = GameManager.gameState.PLAYERDEATH;
		}
	}
}
