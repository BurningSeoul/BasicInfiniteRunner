using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour {
	float score;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime;
		Debug.Log ("Score: " + score);
	}

	public float GetScore() {
		return Mathf.RoundToInt(score);
	}

	public void AddBonus(float bonus) {
		score += bonus;
	}

}
