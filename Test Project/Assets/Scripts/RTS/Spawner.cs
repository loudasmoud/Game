using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject objectToSpawn;
	public int maxObjects;
	int currentObjects;
	public float spawnTime;
	float spawnTimer;
	public GameObject[] spawnPoints;
	public Vector3 currentSpawnPoint;
	// Use this for initialization
	void Awake () {
		spawnTimer = 0.0f;
		currentObjects = 0;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;
		//if we aren't at max objects
		//and spawn timer is up
		if ((currentObjects < maxObjects) && (spawnTimer > spawnTime)) {
			int rand = (int) Random.Range(0, spawnPoints.Length);
			currentSpawnPoint = spawnPoints[rand].transform.position;
			spawnTimer = 0.0f;
			//Debug.Log("Spawn");
			Instantiate (objectToSpawn, currentSpawnPoint, spawnPoints[rand].transform.rotation);
			currentObjects++;
			//choose random spawn point (use length)
			//instantiate new enemy
		}
		
	}
}
