using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    public float scrollX;
    public float scrolly;
    private Renderer myRender;

    private void Start()
    {
        myRender = GetComponent<Renderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrolly;
        myRender.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }

}
