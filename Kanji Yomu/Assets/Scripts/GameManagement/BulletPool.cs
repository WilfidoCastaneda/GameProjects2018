using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletObject;
    GameObject[] myBullets;
    public int poolSize;
    int lastArrayPosition;


    // Start is called before the first frame update
    void Start()
    {
        myBullets = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++) 
        {
            myBullets[i] = Instantiate(bulletObject);
            myBullets[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetBullet()
    {
        //return setup
        GameObject foundBullet = null;

        //check last position for an inactive bullet
        if (myBullets[lastArrayPosition].activeSelf == false)
        {
            //reserve the bullet
            foundBullet = myBullets[lastArrayPosition];
            //move cursor to the next spot
            lastArrayPosition++;
            if (lastArrayPosition >= poolSize)
            {
                lastArrayPosition = 0;
            }

        }
        else
        {
            //start looking at the next location from the current one
            int bulletWalker = lastArrayPosition;
            bulletWalker++;

            //loop until an inactive bullet is found
            while (bulletWalker != lastArrayPosition)
            {
                if (bulletWalker >= poolSize)
                {
                    bulletWalker = 0;
                }
                //when we find an inactive bullet...
                if (myBullets[bulletWalker].activeSelf == false)
                {
                    //reserve it
                    foundBullet = myBullets[bulletWalker];
                    //move the cursor to the next spot
                    bulletWalker++;
                    if (bulletWalker >= poolSize)
                    {
                        bulletWalker = 0;
                    }
                    lastArrayPosition = bulletWalker;
                    break;
                }
                //check the next spot
                bulletWalker++;
            }

        }

        //NOTICE: Function is giving an INACTIVE bullet object if not null! Activate the bullet after this function is called!
        return foundBullet;
    }
}
