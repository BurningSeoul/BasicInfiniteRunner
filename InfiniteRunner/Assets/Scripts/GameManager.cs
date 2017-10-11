using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private static GameManager instance = null;
	private float score;
	private float gameSpeed = 0.0f;
    private bool rateUp = true;
	
	public static GameManager Instance { get { return instance; } }
	public float startingGameSpeed = 1.0f;
	public float rate = 0.1f;
	public  enum gameState {INTRO, PLAYING, PLAYERDEATH, HIGHSCORES}
	public gameState state { get; set; }

	// Use this for initialization
	void Awake () {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;

		} else {
			instance = this;
		}

		DontDestroyOnLoad (this.gameObject);
		gameObject.SetActive (true);
		state = gameState.INTRO;


		switch(state){
		case gameState.INTRO:
			score = 0.0f;
			gameSpeed = startingGameSpeed;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case gameState.PLAYING: 
                float newScore = (score + Time.deltaTime);
                if((int)newScore != (int)score)
                {
                    rateUp = true;
                }
                score = newScore;
			if((int)score % 10 == 0 && rateUp) {
                    Debug.Log("Hey i made it ma");
				gameSpeed += rate;
                    rateUp = false;

            }
			break;

		case gameState.PLAYERDEATH:

			break;
		}
	}

	void FixedUpdate () {
		switch (state) {
		case gameState.PLAYING: 

			break;
		
		case gameState.PLAYERDEATH:
			GetGameSpeed();
			gameSpeed = 0.0f;
			break;
			
		}
	}

	public void ResetLevel() {
		score = 0;
		gameSpeed = startingGameSpeed;
	}

	public float GetScore() {
		return Mathf.RoundToInt(score);
	}

	public float GetGameSpeed() {
		return gameSpeed;
	}
	
	public void AddBonus(float bonus) {
		score += bonus;
	}

	private void DebugThis(object output) {
		Debug.Log (output);
	}

}
