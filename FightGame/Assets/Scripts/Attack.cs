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
    public int targetNumber;
    private bool scrolling;

	// Use this for initialization
	void Start () {
        targetNumber = 0;
        scrolling = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /* unused set target thing, delete when annoying.
    public void SetTarget()
    {
        unitSelector = GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<Selector>();
        target = unitSelector.enemies[0];
        attacker = unitSelector.playerUnits[0];
        targetStats = target.GetComponent<stats>();
        myStats = attacker.GetComponent<stats>();

    }
    */

    public void RegularAttack()
    {
        gameObject.GetComponent<Button>().interactable = false;
        unitSelector = GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<Selector>();
        attacker = unitSelector.currentTurn;
        Input.ResetInputAxes();
        StartCoroutine(SelectTarget());
    }

    public void DoAttack()
    {
        target = unitSelector.currentSelection;
        targetStats = target.GetComponent<stats>();
        myStats = attacker.GetComponent<stats>();
        targetStats.currentHP -= myStats.CalculateAttackDamage();
        gameObject.GetComponent<Button>().interactable = true;
        unitSelector.GetComponent<Info>().StartBattle();
        target.GetComponent<Enemy>().CheckForDeath();

    }


    //use this for menu controls.. should be cool
    //while loop until A is used
    //up and down to change menu items
    //a selects current hover
    public IEnumerator SelectTarget()
    {
        unitSelector.selectedUnitDisplay.SetActive(true);
        if (!unitSelector.nextSelection)
        {
            unitSelector.nextSelection = unitSelector.enemies[0];
            unitSelector.MoveSelectedIcon(unitSelector.enemies[0].transform.position.x, (unitSelector.enemies[0].transform.position.y + 0.7f));
            targetNumber = 0;
        }

        while (!Input.GetButtonDown("Submit"))
        {
            //update to getaxis
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (scrolling == false)
                {
                    Debug.Log("up");
                    if (targetNumber > 0)
                    {
                        targetNumber--;
                        unitSelector.nextSelection = unitSelector.enemies[targetNumber];
                        unitSelector.MoveSelectedIcon(unitSelector.enemies[targetNumber].transform.position.x, (unitSelector.enemies[targetNumber].transform.position.y + 0.7f));
                    }
                    else if (targetNumber == 0)
                    {
                        unitSelector.nextSelection = unitSelector.enemies[unitSelector.enemies.Count - 1];
                        targetNumber = unitSelector.enemies.Count - 1;
                        unitSelector.MoveSelectedIcon(unitSelector.enemies[targetNumber].transform.position.x, (unitSelector.enemies[targetNumber].transform.position.y + 0.7f));
                    }
                    scrolling = true;
                }
                

            }
            if (Input.GetAxisRaw("Vertical") == 0)
            {
                scrolling = false;
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (scrolling == false)
                {
                    Debug.Log("down");
                    if (targetNumber < unitSelector.enemies.Count - 1)
                    {
                        Debug.Log("go down one");
                        targetNumber++;
                        unitSelector.nextSelection = unitSelector.enemies[targetNumber];
                        Debug.Log(targetNumber);
                        unitSelector.MoveSelectedIcon(unitSelector.enemies[targetNumber].transform.position.x, (unitSelector.enemies[targetNumber].transform.position.y + 0.7f));

                    }
                    else if (targetNumber == unitSelector.enemies.Count - 1)
                    {
                        Debug.Log("go to top");
                        unitSelector.nextSelection = unitSelector.enemies[0];
                        targetNumber = 0;
                        Debug.Log(targetNumber);
                        unitSelector.MoveSelectedIcon(unitSelector.enemies[targetNumber].transform.position.x, (unitSelector.enemies[targetNumber].transform.position.y + 0.7f));
                    }
                    scrolling = true;
                }
            }
            yield return null;
        }
        unitSelector.selectedUnitDisplay.SetActive(false);
        unitSelector.currentSelection = unitSelector.nextSelection;
        DoAttack();
        Debug.Log("A");
        yield return null;
    }

}
