using UnityEngine;
using System.Collections;

public class RTSMover : MonoBehaviour {

	//public Transform target;
	public Transform controlledTarget;
	private NavMeshAgent agent;
	private bool moving;
	private bool selected;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		moving = false;
		selected = false;
		newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		SelectUnit ();
		MoveUnit ();
	}

	void UpdateTargetPosition() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			newPosition = hit.point;
			controlledTarget.transform.position = newPosition;
		}
		moving = true;
	}

	void MoveUnit() {
		if (moving) {
			agent.SetDestination (controlledTarget.position);
		}
		if (Input.GetMouseButtonDown (1)) {
			if (selected)
			{
				UpdateTargetPosition();
				Debug.Log (controlledTarget.position);
			}
		}
	}

	void SelectUnit() {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit checkForUnit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out checkForUnit)){
					if (checkForUnit.transform.gameObject.tag == "Unit")
				{
					Debug.Log ("Unit");
					selected = true;
				}
				else {
					Debug.Log("No Unit");
					selected = false;
				}

		}
	}
}
}

