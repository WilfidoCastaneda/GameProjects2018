using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public KanjiData myKanji;
    [SerializeField]
    private TextMesh textField;
    
    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponentInChildren<TextMesh>();
        //textField.text = myKanji.kanjiString;

        //TextParser kanjiList = GameObject.Find("KanjiList").GetComponent<TextParser>();
        //int numKanji = kanjiList.numKanji;
        //int randomNum = Random.Range(0, 100);
        //Debug.Log(kanjiList.kanjiList.Count);
        //Debug.Log(numKanji);
        //myKanji.CopyData(kanjiList.kanjiList[randomNum % (numKanji - 1)]);
        //textField.text = myKanji.kanjiString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySelf()
    {

        Destroy(this.gameObject);

    }
}
