using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	public GameObject unit;
    Slider hpBar;
    stats unitStats;
    public GameObject healthDisplay;
    public GameObject nameDisplay;



	int unitsCurrentHP;
	int unitsMaxHP;

    private void Awake()
    {
    }

    void Start ()
    {
        hpBar = GetComponent<Slider>();
        unitStats = unit.GetComponent<stats>();
        //healthDisplay = GetComponentInChildren<Text>();
        nameDisplay.GetComponent<Text>().text = unitStats.myName;
        hpBar.maxValue = unitStats.maxHP;
        healthDisplay.GetComponent<Text>().text = "" + unitStats.currentHP;



		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHealthBar();
		
	}

    public void UpdateHealthBar()
    {
        hpBar.value = unitStats.currentHP;
        healthDisplay.GetComponent<Text>().text = "" + unitStats.currentHP;
    }
}
