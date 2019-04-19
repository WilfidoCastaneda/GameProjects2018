using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

    private Camera target;

    private void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].GetComponentInChildren<Camera>();
    }
    // Update is called once per frame
    void Update () {
        transform.LookAt(transform.position + target.transform.rotation * Vector3.forward, target.transform.rotation * Vector3.up);
    }
}
