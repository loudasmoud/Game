using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {

    public int earnedXP;
    public int earnedGold;
    public GameObject player;
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
        AwardGold();
        //add gold to users gold
        gameObject.SetActive(false);
        unitSelector.battleUI.alpha = 0;
        unitSelector.battleUI.interactable = false;
        unitSelector.battleUI.blocksRaycasts = false;
    }

    void AwardExperience()
    {
        //list of player units to add experience too
        foreach (GameObject i in unitSelector.playerUnits)
        {
            i.GetComponent<stats>().currentXP += earnedXP;
        }
        earnedXP = 0;
    }
    void AwardGold()
    {
        player.GetComponent<Inventory>().totalGold += earnedGold;
        earnedGold = 0;
    }
}
