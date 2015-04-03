using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;
	float distance;
	Vector3 wanderTo;
	bool arrived;


	// Use this for initialization
	void Start () {
		arrived = true;
		agent = GetComponent<NavMeshAgent> ();
		Wander ();
	}
	
	// Update is called once per frame
	void Update () {
		//distance = Vector3.Distance (this.transform.position, target.transform.position);
		//if (distance < 20) {
		//	agent.SetDestination (target.position);
		//} else
		Wander ();

	}

	void Wander () {
		if (arrived == true) {
			wanderTo = Random.insideUnitSphere * 1000;
			wanderTo.y = 0;
			agent.SetDestination (wanderTo);
			arrived = false;
		} else if (agent.autoBraking)
			arrived = true;
	}
}
