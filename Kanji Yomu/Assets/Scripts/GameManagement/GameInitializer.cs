using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    public GameObject enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Kanji List
        TextParser kanjiList = GameObject.Find("KanjiList").GetComponent<TextParser>();

        //Find existing enemies to control
        GameObject[] foundEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        //change all of the enemies


        int numKanji = kanjiList.numKanji;
        for (int i = 0; i < foundEnemy.Length; i++)
        {

            int randomNum = Random.Range(0, 100);
            //Debug.Log(kanjiList.kanjiList.Count);
            //Debug.Log(numKanji);

            //change enemy kanji
            foundEnemy[i].GetComponent<Enemy>().myKanji = new KanjiData(kanjiList.kanjiList[randomNum % (numKanji - 1)]);
            foundEnemy[i].GetComponentInChildren<TextMesh>().text = foundEnemy[i].GetComponent<Enemy>().myKanji.kanjiString;
        }

        //create the enemy list
        GameObject.Instantiate(enemyManager);
        //fix the pointers
        GameObject.Find("Player").GetComponent<PlayerController>().TextField = GameObject.Find("Canvas").GetComponentInChildren<UnityEngine.UI.InputField>();
        GameObject.Find("Player").GetComponent<PlayerController>().activeEnemyManager = GameObject.Find("Enemy Manager(Clone)").GetComponent<EnemyListManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
