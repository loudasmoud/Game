﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectedUnitWindow : MonoBehaviour {
	 
	public GameObject unitController;
	UnitSelector unitSelector;
	GameObject unitNameText;
	GameObject unitHPBar;
	float currentHP;
	float maxHP;
	Slider healthBar;

	UnitStats unitStats;
	// Use this for initialization
	void Awake () {
		//unitController = 
		unitController = GameObject.Find ("UnitController");
		unitSelector = unitController.GetComponent<UnitSelector> ();
		unitNameText = GameObject.Find ("SelectedUnitName");
		healthBar = GameObject.Find ("SUHealthBar").GetComponent<Slider>();
		unitNameText.GetComponent<Text> ().text = unitSelector.selectedUnit.name;
		unitStats = unitSelector.selectedUnit.GetComponent<UnitStats> ();
		currentHP = unitStats.unitCurrentHealth;
		maxHP = unitStats.unitMaxHealth;
		healthBar.maxValue = maxHP;

	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CalculateHPPercent(){

	}

	void OnGUI(){
		if (unitNameText.GetComponent<Text> ().text != unitSelector.selectedUnit.name) {
			unitNameText.GetComponent<Text> ().text = unitSelector.selectedUnit.name;
		}
		unitStats = unitSelector.selectedUnit.GetComponent<UnitStats> ();
		currentHP = unitStats.unitCurrentHealth;
		maxHP = unitStats.unitMaxHealth;
		healthBar.maxValue = maxHP;
		healthBar.value = currentHP;
	}
}
