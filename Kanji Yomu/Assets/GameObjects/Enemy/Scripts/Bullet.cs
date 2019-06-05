using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float xDir;
    public float yDir;
    private float xActual;
    private float yActual;

    private void Start()
    {
        xActual = xDir / 100;
        yActual = yDir / 100;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(xActual, yActual,0);    
    }
}
