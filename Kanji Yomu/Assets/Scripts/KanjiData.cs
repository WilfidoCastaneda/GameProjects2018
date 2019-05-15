using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class KanjiData{

    public string kanjiString = "一番";
    public string romanjiString = "ichiban";
    public string romanjiStringAlt = null;
    public string englishString = "number one";


    public KanjiData()
    {

    }
    public KanjiData(KanjiData other)
    {
        this.kanjiString = other.kanjiString;
        this.romanjiString = other.romanjiString;
        this.englishString = other.englishString;
        this.romanjiStringAlt = other.romanjiStringAlt;
    }
    public void CopyData(KanjiData otherKanji)
    {
        this.kanjiString = otherKanji.kanjiString;
        this.romanjiString = otherKanji.romanjiString;
        this.englishString = otherKanji.englishString;
        this.romanjiStringAlt = otherKanji.romanjiStringAlt;
    }

}
