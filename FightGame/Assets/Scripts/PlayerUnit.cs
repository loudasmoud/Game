﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour {
    GameObject healthBar;
    public GameObject healthBarUI;
    public GameObject overlord;
    Selector overlordSelector;

    private void Awake()
    {
        overlord = GameObject.FindGameObjectWithTag("UnitSelector");
        overlordSelector = overlord.GetComponent<Selector>();
        overlordSelector.playerUnits.Add(gameObject);
    }

    // Use this for initialization
    void Start () {
        CreateHealthBar();
        SetPlayerUnitPosition();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        //need to be able to target allies for healing
    }

    public void CreateHealthBar()
    {
        healthBar = Instantiate(healthBarUI);
        healthBar.GetComponent<HealthBar>().unit = gameObject;
        healthBar.transform.SetParent(GameObject.FindGameObjectWithTag("Player Stat Display").transform);
        //healthBar.transform.localPosition = new Vector3(-80, 80 - (overlord.enemies.IndexOf(gameObject) * 20));
        healthBar.transform.localPosition = new Vector3(-3, 50 - (overlordSelector.playerUnits.IndexOf(gameObject) * 20));
    }

    public void SetPlayerUnitPosition()
    {
        gameObject.transform.localPosition = new Vector3(-15, 3 - (overlordSelector.playerUnits.IndexOf(gameObject) *2));
    }


}
