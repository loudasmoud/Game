using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    //experience rewarded for killing.
    public int expReward;
    public int goldReward;
    public bool useGoldRange;
    public int randGoldMin;
    public int randGoldMax;
    stats thisEnemyStats;
    Info battleInfo;

    //set up 3 different possible drops and their drop rates
    public GameObject itemDrop1;
    public GameObject itemDrop2;
    public GameObject itemDrop3;
    public int item1chance;
    public int item2chance;
    public int item3chance;


    public GameObject selectedDisplay;
    public GameObject currentTargetDisplay;
    public GameObject healthBarUI;


    Selector unitSelectorSelector;
    GameObject healthBar;

    public GameObject unitSelector;


    // Use this for initialization
    void Awake () {
		
	}

    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartBattle()
    {

        unitSelector = GameObject.FindGameObjectWithTag("UnitSelector");
        currentTargetDisplay = GameObject.FindGameObjectWithTag("CurrentTarget");
        unitSelectorSelector = unitSelector.GetComponent<Selector>();
        //get this enemies stats
        thisEnemyStats = GetComponent<stats>();
        //add to list of enemies

        //
        battleInfo = unitSelector.GetComponent<Info>();
        //create hp bar
        CreateHealthBar();
        SetEnemyPosition();
    }

    private void OnMouseDown()
    {
        //update the selected target and move icon
        unitSelectorSelector.MoveSelectedIcon(gameObject.transform.position.x, (gameObject.transform.position.y + 0.7f));
        unitSelectorSelector.ChangeSelection(gameObject);
    }

    public void CheckForDeath()
    {
        if (thisEnemyStats.currentHP <= 0)
        {
            battleInfo.earnedXP += expReward;
            GiveGold();
            //Debug.Log("" + unitSelectorSelector.enemies.IndexOf(gameObject));
            unitSelectorSelector.enemies.Remove(gameObject);
            Destroy(gameObject);
            Destroy(healthBar);
            if (!CheckForBattleEnd())
            {
                unitSelectorSelector.MoveSelectedIcon(unitSelectorSelector.enemies[0].transform.position.x, unitSelectorSelector.enemies[0].transform.position.y + 0.7f);
                unitSelectorSelector.ChangeSelection(unitSelectorSelector.enemies[0]);
            }
        }
    }

    public bool CheckForBattleEnd()
    {
        if (unitSelectorSelector.enemies.Count == 0)
        {
            battleInfo.EndBattle();
            unitSelectorSelector.HideSelectorIcon();
            battleInfo.EndBattle();
            return true;
        }
        return false;
    }

    public void CreateHealthBar ()
    {
        healthBar = Instantiate(healthBarUI);
        healthBar.GetComponent<HealthBar>().unit = gameObject;
        healthBar.transform.SetParent(GameObject.FindGameObjectWithTag("Enemy Stat Display").transform);
        healthBar.transform.localPosition = new Vector3(-80, 80 - (unitSelectorSelector.enemies.IndexOf(gameObject)*20));
    }

    public void SetEnemyPosition ()
    {
        gameObject.transform.localPosition = new Vector3(-5, 3 - (unitSelectorSelector.enemies.IndexOf(gameObject) * 2));
    }

    void GiveGold()
    {
        if (useGoldRange)
        {
            goldReward = Random.Range(randGoldMin, randGoldMax);
        }
        battleInfo.earnedGold += goldReward;
    }


}
