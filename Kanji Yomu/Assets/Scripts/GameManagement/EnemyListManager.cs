using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListManager : MonoBehaviour
{


    public List<EnemyListObject> currentEnemies;
    public int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] foundEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        int enemySize = foundEnemy.Length;

        for (int i = 0; i < enemySize; i++)
        {
            currentEnemies.Add(new EnemyListObject(foundEnemy[i]));
            numEnemies++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Checks the enemy list for any matches to the player input. If there is, then it is removed from the list and deleted
    public bool CheckList(string playerInput)
    {
        bool iFoundYou = false;

        for (int i = 0; i < numEnemies; i++)
        {
            if (string.Compare(currentEnemies[i].textAnswer, playerInput) == 0)
            {
                //if the inputs are the same, do something
                //Debug.Log("Atari!");
                GameObject markedForDeletion = currentEnemies[i].objectReference;
                currentEnemies.Remove(currentEnemies[i]);
                DeleteEnemy(markedForDeletion);
                iFoundYou = true;
                break;
            }
        }

        return iFoundYou;
    }

    public void AddEnemy(GameObject enemyObject)
    {
        currentEnemies.Add(new EnemyListObject(enemyObject));
        numEnemies++;
    }

    public void DeleteEnemy(GameObject enemyObject)
    {
        //Destroy(enemyObject);
        enemyObject.GetComponent<Enemy>().DestroySelf();
        numEnemies--;
    }

}
