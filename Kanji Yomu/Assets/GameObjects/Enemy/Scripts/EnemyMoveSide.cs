using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveSide : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private bool goingLeft = false;
    private Rigidbody2D myBod;

    private void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //go left
        if (goingLeft)
        {
            myBod.AddForce(new Vector2(moveSpeed, 0));
        }

        //go right
        else
        {
            myBod.AddForce(new Vector2(-moveSpeed, 0));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            goingLeft = !goingLeft;
    }
}
