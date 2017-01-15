using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Info : MonoBehaviour {

    public int earnedXP;
    public int earnedGold;
    public GameObject player;
    Selector unitSelector;
    public GameObject attackButton;
    public EventSystem eventSystem;

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

    public void StartBattle()
    {
        //set attack button as active option
        eventSystem.SetSelectedGameObject(attackButton, null);
    }

    public void EndBattle()
    {
        AwardExperience();
        AwardGold();
        foreach (GameObject i in unitSelector.playerUnits)
        {
            i.GetComponent<PlayerUnit>().EndBattle();
        }

        //disable battle overlord and menu, enable regular menu
        gameObject.SetActive(false);
        unitSelector.battleUI.alpha = 0;
        unitSelector.battleUI.interactable = false;
        unitSelector.battleUI.blocksRaycasts = false;
        unitSelector.menuUI.alpha = 1;
        unitSelector.menuUI.interactable = true;
        unitSelector.menuUI.blocksRaycasts = true;



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
