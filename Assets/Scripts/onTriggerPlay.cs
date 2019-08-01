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

public class onTriggerPlay : MonoBehaviour {

    void OnTriggerEnter(Collider playOnTrigger)
    {

        if (playOnTrigger.gameObject.name == "VBall")
            GetComponent<AudioSource>().Play();
    }
}
