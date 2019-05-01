using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private UnityEngine.UI.InputField TextField;

    [SerializeField]
    private bool activeField;

	void Start () {
        activeField = false;
        TextField = GameObject.Find("Canvas").GetComponentInChildren<UnityEngine.UI.InputField>();
        TextField.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Submit") == true)
        {
            if (activeField == false)
            {
                activeField = true;
                TextField.interactable = true;
                TextField.Select();
            }

            else
            {
                //submit and disable text box
                activeField = false;
                TextField.interactable = false;
                TextField.text = "";
            }

        }

        if (Input.GetButtonDown("Shoot") && activeField == true)
        {
            //submit only. does not disable text box
            TextField.text = "";
        }
		
	}

}
