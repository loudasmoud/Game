using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public GameObject previousSelection;
    public GameObject currentSelection;
    public GameObject nextSelection;
    public GameObject selectedUnitDisplay;
    public GameObject currentTurn;
    //create list for all units to determine order?
    public List<GameObject> enemies;
    public List<GameObject> playerUnits;

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start ()
    {
        selectedUnitDisplay = GameObject.FindGameObjectWithTag("CurrentTarget");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveSelectedIcon (float x, float y)
    {
        selectedUnitDisplay.transform.position = new Vector3(x, y);

    }

    public void ChangeSelection(GameObject selected)
    {
        currentSelection = selected;

    }

    public void HideSelectorIcon()
    {
        selectedUnitDisplay.GetComponent<SpriteRenderer>().enabled = false;
    }
}
