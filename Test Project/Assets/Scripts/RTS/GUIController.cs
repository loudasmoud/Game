 using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {


	public GameObject selectedUnitBackground;
	public GameObject mainUI;
	public GameObject selectedObject;
	bool unitSelectedOpen;
	UnitStats unitStats;
	//public GameObject unitController;
	UnitSelector unitSelector;
	GameObject selectedUnitBG;
	Vector3 unitSelectedUIPos;
	//use worldspace canvas to put "ui" things in world space like an animation at the location you right click to move to
	//could use this to put health above the players head.

	// Use this for initialization
	void Awake () {
		unitSelectedOpen = false;
		//unitStats = selectedObject.GetComponent<UnitStats> ();
		unitSelector = gameObject.GetComponent<UnitSelector> ();
		unitSelectedUIPos = new Vector3 (500, 175, 0);

	}


	void OnGUI () {
		if (unitSelector.selectedUnit.tag == "Enemy" && !unitSelectedOpen) {
			//need to set the position for this.
			//create children UI elements named to help script them based on unit stats component
			selectedUnitBG = Instantiate (selectedUnitBackground);
			selectedUnitBG.transform.SetParent (mainUI.transform);
			RectTransform selectedUnitPos = selectedUnitBG.GetComponent<RectTransform>();
			selectedUnitPos.anchoredPosition3D = unitSelectedUIPos;
			unitSelectedOpen = true;
		}
		if (unitSelector.selectedUnit.tag != "Enemy" && unitSelectedOpen) {
			Debug.Log("Hello?");
			Destroy (selectedUnitBG);
			unitSelectedOpen = false;
		}
	}
}
