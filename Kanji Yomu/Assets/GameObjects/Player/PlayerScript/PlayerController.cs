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
    public GameObject gameOver;

    private Rigidbody2D myBody;

    [Header("My Data")]
    [SerializeField]

    public float NormalSpeed;
    public float SlowSpeed;
    private float walkingSpeed;
    private Vector2 myAngle;
    private bool activeField;

    void Start () {
        activeField = false;
        TextField = GameObject.Find("Canvas").GetComponentInChildren<UnityEngine.UI.InputField>();
        for (int i = 0; i < 10; i++)
        {
            gameOver = GameObject.Find("Canvas").transform.GetChild(i).gameObject;
            if (gameOver.name == "GameOver")
            {
                break;
            }
        }
        gameOver.SetActive(false);
        TextField.interactable = false;
        //activeEnemyManager = GameObject.Find("Enemy Manager").GetComponent<EnemyListManager>();
        myBody = this.GetComponent<Rigidbody2D>();
        walkingSpeed = NormalSpeed;
        //recycling the same space to avoid constant creation of vectors
        myAngle = new Vector2();
        //activeEnemyManager = GameObject.Find("Enemy Manager(Clone)").GetComponent<EnemyListManager>();
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

    }
    private void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
        {
            myAngle.Set(Input.GetAxis("Horizontal") * walkingSpeed, 0);
            myBody.AddForce(myAngle);
        }
        if (Input.GetButton("Vertical"))
        {
            myAngle.Set(0, Input.GetAxis("Vertical") * walkingSpeed);
            myBody.AddForce(myAngle);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            KillSelfProtocol();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            KillSelfProtocol();
        }
    }

    private void KillSelfProtocol()
    {
        gameOver.SetActive(true);
        Destroy(this.gameObject);
    }
}
