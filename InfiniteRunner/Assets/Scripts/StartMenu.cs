using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
    Camera cam;
	//public GameObject Button;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (cam.pixelWidth/2 - 75, cam.pixelHeight/2 + 75, 150, 100), "Start Running!")) {
			GameObject.Find ("GlobalObject").GetComponent <GameManager>().state = GameManager.gameState.PLAYING;
			//GameObject.Find ("GlobalObject").AddComponent <LevelGeneration>();
			Application.LoadLevel(1);

		}
	}
}
