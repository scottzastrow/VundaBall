/*
 * 
 * Copyright (c) 2015 All Rights Reserved, VERGOSOFT LLC
 * Title: VundaBall
 * Author: Scott Zastrow
 * iOS Version: 1.2
 * 
 * 
 */
using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {

    public Transform trackBall;
    public Transform hisShadow;
    public GameObject vBall;

    void Start() 
    {
        hisShadow.GetComponent<Renderer>().enabled = true;
    }
    
    void Update()
    {
        if (vBall.GetComponent<Rigidbody>().isKinematic == false)
        {
            hisShadow.GetComponent<Renderer>().enabled = true;
            hisShadow.transform.localPosition = new Vector3(trackBall.localPosition.x, .007f, trackBall.localPosition.z);
        }

        else
            hisShadow.GetComponent<Renderer>().enabled = false;

    }
}
