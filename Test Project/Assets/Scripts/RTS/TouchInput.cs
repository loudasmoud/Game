using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {
	public LayerMask touchInputMask;
	public GameObject player;
	NavMeshAgent agent;
	void Awake (){
		agent = player.GetComponent<NavMeshAgent> ();
	}
		// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches) {
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, touchInputMask)){
				//GameObject recipient = hit.transform.gameObject;
				if (touch.phase == TouchPhase.Began){
					//recipient.SendMessage("OnTouchDown", hit.point
					agent.SetDestination(hit.transform.position);
				}
			}
		}
	}
}
