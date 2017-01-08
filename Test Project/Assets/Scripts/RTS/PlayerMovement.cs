using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	NavMeshAgent agent;	
	public GameObject moveToTarget;
	Vector3 newTargetPostion;
	bool atDestination;
	public GameObject movementIndicatorPrefab;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetMouseButtonDown (1)) {
			UpdateTargetPosition();
			agent.SetDestination (moveToTarget.transform.position);
			Instantiate(movementIndicatorPrefab, new Vector3(moveToTarget.transform.position.x, moveToTarget.transform.position.y + 0.5f, moveToTarget.transform.position.z), moveToTarget.transform.rotation);
		}
		//MovePlayer ();
		//press s to stop moving
		if (Input.GetKeyDown(KeyCode.S)){
			agent.SetDestination(this.transform.position);
			atDestination = true;
		}
	}

	void UpdateTargetPosition() {
		int layerMask = 1 << 8;
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask)) {
			newTargetPostion = hit.point;
			moveToTarget.transform.position = newTargetPostion;
			atDestination = false;
		}
	}

	void MovePlayer() {
		// Check if we've reached the destination - NOT USING RIGHT NOW, BUT COULD BE USEFUL
		if (!agent.pathPending) {
			if (agent.remainingDistance <= agent.stoppingDistance) {
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
					// Done
					//Debug.Log ("I've reached my destination!");
					atDestination = true;
				}
			}
		}
	}
}
