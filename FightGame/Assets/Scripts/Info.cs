﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {

    public int earnedXP;
    public int earnedGold;
    Selector unitSelector;

    private void Awake()
    {
        unitSelector = GetComponent<Selector>();
    }
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndBattle()
    {
        AwardExperience();
        //add gold to users gold
    }

    void AwardExperience()
    {
        foreach (GameObject i in unitSelector.playerUnits)
        {
            i.GetComponent<stats>().currentXP += earnedXP;
        }
        //need list of player units to add experience too
    }
}
