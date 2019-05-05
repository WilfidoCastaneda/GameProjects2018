using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private UnityEngine.UI.InputField TextField;

    [SerializeField]
    private EnemyListManager activeEnemyManager;

    [SerializeField]
    private bool activeField;

	void Start () {
        activeField = false;
        TextField = GameObject.Find("Canvas").GetComponentInChildren<UnityEngine.UI.InputField>();
        TextField.interactable = false;
        activeEnemyManager = GameObject.Find("Enemy Manager").GetComponent<EnemyListManager>();
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
                activeEnemyManager.CheckList(TextField.text);
                TextField.text = "";
            }

        }

        if (Input.GetButtonDown("Shoot") && activeField == true)
        {
            //submit only. does not disable text box
            //Debug.Log(TextField.text + '+');
            int strlen = TextField.text.Length;
            //Debug.Log(TextField.text.Substring(0, strlen - 1) + '+');
            if (strlen > 0)
            {
                activeEnemyManager.CheckList(TextField.text.Substring(0, strlen - 1));
            }
            TextField.text = "";
        } 
		
	}

}
