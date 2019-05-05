using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyListObject
{
    public string textAnswer;
    public GameObject objectReference;

    public EnemyListObject(GameObject enemy)
        
    {
        textAnswer = enemy.GetComponent<Enemy>().myKanji.romanjiString;
        objectReference = enemy;

    }
}