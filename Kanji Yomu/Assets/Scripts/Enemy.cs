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
        textField.text = myKanji.kanjiString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
