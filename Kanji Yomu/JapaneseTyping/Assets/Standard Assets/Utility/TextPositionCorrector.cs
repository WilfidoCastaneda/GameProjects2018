using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPositionCorrector : MonoBehaviour {

    public float parentVerticalOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y + parentVerticalOffset, gameObject.transform.parent.position.z);

    }
}
