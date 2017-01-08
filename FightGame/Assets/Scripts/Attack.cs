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
        targetStats = target.GetComponent<stats>();
        myStats = attacker.GetComponent<stats>();
        unitSelector = GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<Selector>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RegularAttack ()
    {
        target = unitSelector.currentSelection;
        targetStats = target.GetComponent<stats>();
        myStats = attacker.GetComponent<stats>();
        targetStats.currentHP -= myStats.CalculateAttackDamage();
        target.GetComponent<Enemy>().CheckForDeath();

    }
}
