using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
		
	private static AudioManager instance = null;
	public static AudioManager Instance { get { return instance; } }

	// Use this for initialization
	void Awake () {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
