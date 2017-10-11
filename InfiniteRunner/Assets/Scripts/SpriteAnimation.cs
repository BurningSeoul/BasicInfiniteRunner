#define DEBUG
using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour {

	public string animationName = "Sprite Animation Name!";
	public Material sheetMaterial;
	public Texture sheetTexture;
	public bool loop = true;
	public bool playOnAwake = true;
	public float updateRate = 1f; //in seconds
	public int totalFrames;
	public int currentFrame = 1;
	public float sheetWidth = 8f;	//number of tiles across
	public float sheetHeight = 8f;
	public int tileHeight;
	public int tileWidth;
    private Renderer rend;
	private bool isPlaying;

	void Awake() {
        rend = gameObject.GetComponent<Renderer>();
		rend.material = sheetMaterial;
		if (playOnAwake) {
			Play();
		}
	}

	public void Play() {
#if DEBUG
		Debug.Log("Play: " + animationName);
#endif
		if (!isPlaying) {
			isPlaying = true;
			sheetMaterial.mainTexture = sheetTexture;
			StartCoroutine (Draw());
		}
	}

	// Use this for initialization
	void Start () {
	
	}
#if DEBUG	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Update: " + animationName);
	}
#endif
	//Draw
	public IEnumerator Draw() {
		while (isPlaying) {

			//determine the frame position
			int offsetX = (currentFrame -1) % (int)sheetWidth;
			int offsetY = (currentFrame - 1) / (int)sheetWidth;

			//set the texture to the right offset
			sheetMaterial.mainTextureOffset = new Vector2 (offsetX/sheetWidth, 1f-((offsetY+1)/sheetHeight));

			//set the scale of the texture
			sheetMaterial.mainTextureScale = new Vector2 (1f/sheetWidth, 1f / sheetHeight);

			//increment the frame vounter for the next iteration
			currentFrame++;

			//check to see if the animation is looping
			if(currentFrame > totalFrames) {
				if(loop){
					currentFrame = 1;
				} else {
					currentFrame = totalFrames;
					isPlaying = false;
				}
			}
			
			//run the loop again after a short delay based on our frame rate.
			if (isPlaying) {
				yield return new WaitForSeconds(updateRate);
			}
		}
#if DEBUG
		Debug.Log ("Ended: " + animationName);
#endif
		//exit the drawing loop
		yield return null;
	}

	//stop the animmation!
	public void Stop(){
#if DEBUG
		Debug.Log ("Stop: " + animationName);
#endif
		isPlaying = false;
		currentFrame = 1;
	}
}
