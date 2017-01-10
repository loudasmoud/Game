using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public GameObject player;
    public GameObject gameInfo;
    public CanvasGroup battleUI;
    public GameObject previousSelection;
    public GameObject currentSelection;
    public GameObject nextSelection;
    public GameObject selectedUnitDisplay;
    public GameObject currentTurn;
    //create list for all units to determine order?
    public List<GameObject> enemies;
    public List<GameObject> playerUnits;

    private void Awake()
    {
        


    }
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnEnable()
    {
        EnableBattleUI();
        //start battle for all players in the active party;
        foreach (GameObject i in player.GetComponent<PlayerParty>().activeParty)
        {
            playerUnits.Add(i);
            i.GetComponent<PlayerUnit>().StartBattle();
        }

        // start battle for all enemies
        foreach (GameObject i in gameInfo.GetComponent<EnemyCreator>().newEnemies)
        {
            enemies.Add(i);
            i.GetComponent<Enemy>().StartBattle();
        }
        gameInfo.GetComponent<EnemyCreator>().newEnemies.Clear();
        currentSelection = playerUnits[0];
    }

    public IEnumerator SelectTarget()
    {
        while (!Input.GetKeyDown("Submit"))
        {
            yield return null;
        }
    }

    private void EnableBattleUI()
    {
        selectedUnitDisplay.SetActive(true);
        battleUI.alpha = 1;
        battleUI.interactable = true;
        battleUI.blocksRaycasts = true;
    }

    public void MoveSelectedIcon (float x, float y)
    {
        selectedUnitDisplay.transform.position = new Vector3(x, y);

    }

    public void ChangeSelection(GameObject selected)
    {
        currentSelection = selected;

    }

    public void HideSelectorIcon()
    {
        selectedUnitDisplay.SetActive(false);
    }
}
