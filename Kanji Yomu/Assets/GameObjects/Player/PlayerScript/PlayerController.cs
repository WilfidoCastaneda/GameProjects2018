using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    [Header("Pointers")]
    [SerializeField]
    public UnityEngine.UI.InputField TextField;

    [SerializeField]
    public EnemyListManager activeEnemyManager;

    private Rigidbody2D myBody;

    [Header("My Data")]
    [SerializeField]
    private bool activeField;

    public float NormalSpeed;
    public float SlowSpeed;
    private float walkingSpeed;


    void Start () {
        activeField = false;
        TextField = GameObject.Find("Canvas").GetComponentInChildren<UnityEngine.UI.InputField>();
        TextField.interactable = false;
        //activeEnemyManager = GameObject.Find("Enemy Manager").GetComponent<EnemyListManager>();
        myBody = this.GetComponent<Rigidbody2D>();
        walkingSpeed = NormalSpeed;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Submit") == true)
        {
            if (activeField == false)
            {
                activeField = true;
                TextField.interactable = true;
                TextField.ActivateInputField();
                TextField.Select();
                walkingSpeed = SlowSpeed;
            }

            else
            {
                //submit and disable text box
                activeField = false;
                TextField.interactable = false;
                activeEnemyManager.CheckList(TextField.text);
                TextField.DeactivateInputField();
                TextField.text = "";
                walkingSpeed = NormalSpeed;
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

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetButton("Horizontal"))
        {
            myBody.AddForce(new Vector2(Input.GetAxis("Horizontal") * walkingSpeed, 0));
        }
        if (Input.GetButton("Vertical"))
        {
            myBody.AddForce(new Vector2(0 , Input.GetAxis("Vertical") * walkingSpeed));
        }

    }

}
