using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	float timer;
	public int spawnTime;
	public GameObject target;
	public GameObject spawnLocation;

	// Use this for initialization
	void Start () {
		timer = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > spawnTime) {
			Debug.Log("Spawn");
			SpawnUnit();
			timer = 0;
		}
	}

	void SpawnUnit () {
		Instantiate (target, spawnLocation.transform.position, spawnLocation.transform.rotation);
	}
}
