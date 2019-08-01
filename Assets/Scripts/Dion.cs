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
using UnityEngine.UI;

public class Dion : MonoBehaviour {

    public GameObject explosion;
    //public AudioSource dionBlow;
    public static bool vBallandDion;
    int zeroCount;
    
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
        vBallandDion = false;


    }
	

	void Update ()
    {
        this.transform.Rotate(Vector3.up * Time.deltaTime * 50f); //rotates clockwise.

        if (VHealth.coreTemp < 0 && vBallandDion == false)
        {
            this.GetComponent<Renderer>().enabled = true;
            this.GetComponent<Collider>().enabled = true;
        }
        else 
        {
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
        }

	}


    private void OnCollisionEnter(Collision dBump)
    {

        if (dBump.gameObject.name == "VBall")
        {
            VHealth.energyDion(); //Calling a static method from the VHealth Class.
            VHealth.dScore();
            GetComponent<AudioSource>().Play();
            Instantiate(explosion, transform.position, Quaternion.identity);
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
            vBallandDion = true;
        }
    }


}
