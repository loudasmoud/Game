using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {

    public GameObject target;
    public GameObject attacker;
    Selector unitSelector;
    stats targetStats;
    stats myStats;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTarget()
    {
        unitSelector = GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<Selector>();
        target = unitSelector.enemies[0];
        attacker = unitSelector.playerUnits[0];
        targetStats = target.GetComponent<stats>();
        myStats = attacker.GetComponent<stats>();

    }

    public void RegularAttack ()
    {
        unitSelector = GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<Selector>();
        StartCoroutine(unitSelector.SelectTarget());
        target = unitSelector.currentSelection;
        targetStats = target.GetComponent<stats>();
        myStats = attacker.GetComponent<stats>();
        targetStats.currentHP -= myStats.CalculateAttackDamage();
        target.GetComponent<Enemy>().CheckForDeath();
    }
}
