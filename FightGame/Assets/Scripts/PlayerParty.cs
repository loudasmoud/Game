using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour {

    public GameObject unitPrefab;
    public int partyMaxSize;
    public List<GameObject> inactiveParty;
    public List<GameObject> activeParty;
    public int totalUnits;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewBaseUnit()
    {
        int newStr = Random.Range(5, 10);
        int newInt = Random.Range(5, 10);
        int newDex = Random.Range(5, 10);
        GameObject newUnit = Instantiate(unitPrefab);
        newUnit.GetComponent<stats>().baseStrength = newStr;
        newUnit.GetComponent<stats>().baseIntelligence = newInt;
        newUnit.GetComponent<stats>().baseDexterity = newDex;
        //add to active party if it isn't full, else add to inactive. Either way update the total.
        if (activeParty.Count < partyMaxSize)
        {
            activeParty.Add(newUnit);
        }

    }
}
