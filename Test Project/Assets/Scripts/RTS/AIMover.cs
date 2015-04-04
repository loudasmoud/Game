using UnityEngine;
using System.Collections;

public class AIMover : MonoBehaviour {

	public GameObject playerTarget;
	public float detectRange;
	public float chaseRange;
	public float searchTime;
	public float homeAreaRadius;
	float searchTimer;
	//float idleSearchTime;
	float autoWanderTimer;
	float distanceFromHome;
	Vector3 returnPos;
	NavMeshAgent agent;
	//bool chasing;
	bool playerDetected;
	bool returningHome;
	//bool wandering;
	Vector3 wanderTo;
	Vector3 wanderArea;
	float updateChaseTimer;
	UnitStats unitStats;

	private AIPlayerDetection playerDetector;
	private State currentState;

	enum State {Waiting, Wandering, Chasing}

	// Use this for initialization
	void Awake () {
		playerTarget = GameObject.Find ("Player");
		agent = gameObject.GetComponent<NavMeshAgent> ();
		playerDetector = gameObject.GetComponent<AIPlayerDetection> ();
		returnPos = gameObject.transform.position;
		wanderArea = gameObject.transform.position;
		unitStats = gameObject.GetComponent<UnitStats> ();

		searchTimer = searchTime;
		updateChaseTimer = 0.0f;
		//idleSearchTime = searchTime;


		//chasing = false;
		//wandering = false;

		//idleSearchTime = 0.0f;	
		searchTimer = 0.0f;
		autoWanderTimer = 5;
		//homeAreaRadius = 5.0f;

		currentState = State.Waiting;

		FindNewWanderPosition ();
	}


	// Update is called once per frame
	void Update () {

		if (playerDetector.playerInRange && playerDetector.playerInSight)
			playerDetected = true;
		else
			playerDetected = false;
		//Debug.Log (playerDetected);
		if (playerDetected)
			currentState = State.Chasing;
		switch (currentState) {
		case State.Waiting:
			Wait ();
			break;
		case State.Wandering:
			WanderToTarget();
			break;
		case State.Chasing:
			Chasing();
			break;
		}

//		if (playerDetector.playerInRange && playerDetector.playerInSight)
//			playerDetected = true;
//		else
//			playerDetected = false;
//
//
//
//		if (playerDetected) {
//			Chasing ();
//		}else
//		ReturnHome ();
//
//		if (!playerDetected && !returningHome) {
//			Wander ();
//		}
	}


	void Wait (){
		searchTimer += Time.deltaTime;
		//Debug.Log("waiting");
		if (searchTimer > searchTime) {
			searchTimer = 0.0f;
			currentState = State.Wandering;
		} 
	}

	void WanderToTarget(){
		autoWanderTimer -= Time.deltaTime;
		agent.SetDestination (wanderTo);
		//Debug.Log("wandering");
		//Debug.Log (agent.velocity);
		//Debug.Log (Vector3.Distance (wanderTo, gameObject.transform.position));

		//add something to check if it's running into an object
		//if it is, change state to waiting - this may prove difficult to perfect. come back to it. currently will look for a new spot after a timer runs out
		if (Vector3.Distance(gameObject.transform.position, wanderTo) < agent.stoppingDistance || autoWanderTimer < 0){
			currentState = State.Waiting;
			FindNewWanderPosition ();
			autoWanderTimer = 5;
		}
	}

	void FindNewWanderPosition(){
		wanderTo = wanderArea + (Random.insideUnitSphere * homeAreaRadius);
		//Debug.Log (wanderTo);
	}

	void Chasing(){

		updateChaseTimer += Time.deltaTime;
		//stop chasing if outside of chase range
		distanceFromHome = Vector3.Distance (returnPos, gameObject.transform.position);
		//Debug.Log (distanceFromHome);
		if (chaseRange < distanceFromHome){
			currentState = State.Waiting;
			return;
		}
		//IF THE PLAYER IS NOT IN RANGE OR IN SIGHT CHANGE STATE TO WAITING
		if ((!playerDetector.playerInRange && !playerDetector.playerInSight)) {
			currentState = State.Waiting;
			return;
		}
		//IF THE PLAYER IS CLOSE ENOUGH ATTACK
		if (Vector3.Distance (gameObject.transform.position, playerTarget.transform.position) < unitStats.attackRange) {
			currentState = State.Wandering;
			Debug.Log("Attack");
			return;
		}
		//OTHER WISE KEEP CHASING
		//need to try to stop doing this every time
		if (updateChaseTimer > 1) {
			agent.SetDestination (playerTarget.transform.position);
			updateChaseTimer = 0.0f;
		}
	}

//	void ReturnHome(){
//		searchTimer -= Time.deltaTime;
//		//Debug.Log (searchTimer);
//		if (searchTimer <= 0) {
//			if (!agent.pathPending && !returningHome) {
//				if (agent.remainingDistance <= agent.stoppingDistance) {
//					if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
//						searchTimer = searchTime;
//						returningHome = true;
//						agent.SetDestination (returnPos);
//						Debug.Log ("Going Home");
//						wandering = false;
//					}
//				}
//			}
//		}
//	}
//
//	void OnDrawGizmos () {
//		Gizmos.color = Color.white;
//		Gizmos.DrawWireSphere (wanderArea, homeAreaRadius);
//	}
}