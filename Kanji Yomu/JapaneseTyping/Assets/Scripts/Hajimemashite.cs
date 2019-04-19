using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hajimemashite : BaseClass {

	// Use this for initialization
	void Start () {
		
	}

    public override void OnTextComplete()
    {
        Debug.Log("IT WORKED!");
    }

}
