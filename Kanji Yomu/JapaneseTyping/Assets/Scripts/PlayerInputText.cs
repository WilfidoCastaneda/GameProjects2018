using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInputText : MonoBehaviour {

    private string originalText;

    [SerializeField]private AudioClip openingSound;
    [SerializeField]private AudioClip correctSound;
    [SerializeField]private AudioClip incorrectSound;
    [SerializeField]private AudioClip completeSound;

    private TextMesh myText;
    private BoxCollider myBox;
    private AudioSource myAudio;
    private FirstPersonController player;

    private int counter = 0;

    private bool isActive = false;


    void Start()
    {
        myText = GetComponent<TextMesh>();
        myBox = GetComponent<BoxCollider>();
        myAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].gameObject.GetComponent<FirstPersonController>();

        if (myBox == null)
        {
            throw new System.Exception("Missing Box Collider! Please add a Box Collider component!");
        }
        else if (myBox.isTrigger != true)
        {
            throw new System.Exception("BoxCollider.isTrigger is set to false! Please set BoxCollider.isTrigger to true!");
        }
        originalText = myText.text;
    }

    // Update is called once per frame
    void Update () {
        //Only call if a player presses down on a key. only call if the key pressed is a char. Avoids bugs. Only call if active
        if (Input.anyKeyDown && Input.inputString.Length == 1 && isActive)
        {
            //Debug.Log(Input.inputString);
            if (counter < originalText.Length &&  char.ToLower(Input.inputString[0]) == char.ToLower(originalText[counter]) )
            {
                counter++;
                myText.text = "<color=green>" + originalText.Substring(0, counter) + "</color>" + originalText.Substring(counter);
                if (counter == originalText.Length)
                {

                    myAudio.clip = completeSound;
                    myAudio.Play();

                    player.m_WalkingDisabled = false;
                }
                else
                {
                    myAudio.clip = correctSound;
                    myAudio.Play();

                    player.m_WalkingDisabled = true;
                }
            }
            else
            {
                myText.text = originalText;
                counter = 0;

                myAudio.clip = incorrectSound;
                myAudio.Play();

                player.m_WalkingDisabled = false;
            }
            //Debug.Log(Input.inputString);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("My devil trigger has been pulled");
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("My devilTrigger was reset");
            isActive = false;
            myText.text = originalText;
        }
    }
}
