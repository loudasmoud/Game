using UnityEngine;
using System.Collections;

public class UnitStats : MonoBehaviour {
	public int unitMaxHealth;
	public int unitCurrentHealth;
	public int unitStrength;
	public int unitDetectionLevel;
	public string unitName;
	public int attackRange;
	UnitSelector unitSelector;
	// Use this for initialization
	void Start () {
		unitCurrentHealth = unitMaxHealth;
		unitSelector = GameObject.Find ("UnitController").GetComponent<UnitSelector> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//check for death
		if (unitCurrentHealth <= 0) {
			unitCurrentHealth = 0;
			if (unitSelector.selectedUnit = gameObject){
				unitSelector.selectedUnit = GameObject.Find ("UnitController");
			}
			Destroy (gameObject);
		}

	
	}
}
