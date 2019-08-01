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

public class Grenade : MonoBehaviour {

    public GameObject blowGrenade;
    public Transform liveGrenade;

    void Start()
    {
        StartCoroutine(waitFirst());
    }
    
    private void OnCollisionEnter(Collision gBump) //On Enter
    {

        if (gBump.gameObject.name == "VBall")
        {
            Instantiate(blowGrenade, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit(Collision gBump) //On Exit
    {

        if (gBump.gameObject.name == "VBall")
        {
            Instantiate(blowGrenade, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator waitFirst()
    {
        yield return new WaitForSeconds(1);
        Instantiate(blowGrenade, transform.position, Quaternion.identity);
        Destroy(liveGrenade.gameObject);
    }
}
