using UnityEngine;
using System.Collections;

public class LeaveCamera : MonoBehaviour {
	GameObject globalObject;
	GameManager gameManager;
    Camera cam;
	// Use this for initialization
	void Start () {
		globalObject = GameObject.Find("GlobalObject");
        cam = GameObject.Find("Camera").GetComponent<Camera>();
		gameManager = globalObject.GetComponent <GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit(Collider col) {
		//if(col.gameObject.name == "Miner") {
		//	Destroy(col.gameObject);
		//	GameObject.Find ("GlobalObject").GetComponent <GameManager>().state = GameManager.gameState.PLAYERDEATH;
		//	Debug.Log (col.gameObject.name + " Destroyed!");
		//}
	}

	void OnGUI() {
		switch(gameManager.state) {
		case GameManager.gameState.PLAYING:
			GUI.Box(new Rect(10,10,100,90), "");
			GUI.Label (new Rect (15,25,100,50), "Score: " + GameObject.Find ("GlobalObject").GetComponent<GameManager>().GetScore());
			GUI.Label (new Rect (15,35,100,50), "Speed: " + GameObject.Find ("GlobalObject").GetComponent<GameManager>().GetGameSpeed());
			break;
		case GameManager.gameState.PLAYERDEATH:
			GUI.Box(new Rect(cam.pixelWidth/2 - 75, cam.pixelHeight/2,150,100), "GAME OVER!");
			GUI.Label (new Rect (15,25,100,50), "Score: " + GameObject.Find ("GlobalObject").GetComponent<GameManager>().GetScore());
			if (GUI.Button (new Rect (cam.pixelWidth/2 - 75, cam.pixelHeight/2 + 20, 150, 100), "Start Running!")) {
				gameManager.ResetLevel();
				gameManager.state = GameManager.gameState.PLAYING;
                    //GameObject.Find ("GlobalObject").AddComponent <LevelGeneration>();
                    Application.LoadLevel(1);
               
				
			}
			break;
		}
	}
}
