using UnityEngine;
using System.Collections;

public class AIPlayerDetection : MonoBehaviour {

	public GameObject _player;
	public float detectRange;
	public bool chase;
	public bool returnToHome;
	public bool playerInSight;
	public bool playerInRange;

	bool farFromHome;
	NavMeshAgent agent;
	float distanceFromPlayer;
	// Use this for initialization
	void Awake () {
		_player = GameObject.Find ("Player");
		agent = gameObject.GetComponent<NavMeshAgent> ();
		playerInSight = false;
		returnToHome = false;
	}
	
	// Update is called once per frame
	void Update () {
		distanceFromPlayer = Vector3.Distance (_player.transform.position, gameObject.transform.position);

		// check if the unit can see the player
		NavMeshHit hit;
		if (!agent.Raycast (_player.transform.position, out hit)) {
			//Debug.Log (playerInSight);
			playerInSight = true;
		} else
			playerInSight = false;

		// set chase to true if player is in range and sight
		if (detectRange > distanceFromPlayer) {
			playerInRange = true;
		} else
			playerInRange = false;
	}

}
