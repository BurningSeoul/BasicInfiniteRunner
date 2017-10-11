using UnityEngine;
using System.Collections;

public class DestroyPrefab : MonoBehaviour {

	public GameObject destroyee;
	public Transform whatever;
	public float distance = -100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(whatever.position.x < distance) {
			Destroy (destroyee);
		}
	}
}
