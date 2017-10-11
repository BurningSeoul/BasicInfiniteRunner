using UnityEngine;
using System.Collections;

public class LevelGeneration : MonoBehaviour {
	
	private const float TUNNEL_WIDTH = 80f;
	private Vector3 spawnPoint;
	private GameObject lastBaseObject;
	private GameObject sectionPrefab;
	private GameObject newPrefab;

	public GameObject[] basePrefabs = new GameObject[3];

	// Use this for initialization
	void Awake () {
		spawnPoint = new Vector3 (90.54189f, 10.43705f, -4.998047f);
		CreateNewSegment (true);
	}
	
	// Update is called once per frame
	void Update () {
		if(lastBaseObject.transform.position.x - spawnPoint.x <= -TUNNEL_WIDTH) {
			CreateNewSegment(false);
		}
	}
	void CreateNewSegment(bool firstSegment) {
/*		if(firstSegment) {
			basePrefabs.SetValue(newPrefab.transform.name = "Hallway",0);
			basePrefabs.SetValue(newPrefab.transform.name = "BarrelWay",1);
			basePrefabs.SetValue(newPrefab.transform.name = "Crates",2);
		} else {	//change once i have more prefabs
		//	basePrefabs.SetValue(newPrefab.transform.name = "Hallway",0);
		//	basePrefabs.SetValue(newPrefab.transform.name = "BarrelWay",1);
		//	basePrefabs.SetValue(newPrefab.transform.name = "Crates",2);
		}
*/
		sectionPrefab = getSections ();
		GameObject spawnedSection = Instantiate(sectionPrefab, spawnPoint,Quaternion.identity) as GameObject;
		lastBaseObject = spawnedSection;
		spawnedSection.transform.parent = this.gameObject.transform;
	}

	 private GameObject getSections() {
		Random.InitState((int)Time.time);
		return basePrefabs[Random.Range(0, basePrefabs.Length)];
	}
}
