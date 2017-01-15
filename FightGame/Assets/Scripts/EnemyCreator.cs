using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour {

    public int numberOfEnemies;
    public GameObject enemyType;
    public List<GameObject> newEnemies;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject newEnemy = Instantiate(enemyType);
            newEnemies.Add(newEnemy);            
        }
    }
}
