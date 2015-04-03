using UnityEngine;
using System.Collections;

public class UnitSelector : MonoBehaviour {

	public GameObject selectedUnit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			SelectUnit();
		}
	
	}

	void SelectUnit() {
		//NEED TO LIMIT TO ONLY ON THE GROUND, NEED TO STOP TRYING TO MOVE TO WALLS AND ROOFS 
		//also need to not remove target if a GUI object is clicked on
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.gameObject.tag == "Player") {
					selectedUnit = hit.transform.gameObject;
					Debug.Log ("Unit: " + selectedUnit);
				} 
				else if (hit.transform.gameObject.tag == "Enemy"){
					selectedUnit = hit.transform.gameObject;
					Debug.Log ("Unit: " + selectedUnit);
				}
				else { 
					selectedUnit = gameObject;
					Debug.Log ("No Unit");
				}
			}
	}
}
