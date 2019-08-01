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

public class Lerp : MonoBehaviour {


    private float speed = .5F;
    private Vector3 newPosition;
    private int changeColor;
    private Color baseColor;
    Vector3 positionA = new Vector3(0.13407f, 1.8303f, -0.92602f);
    Vector3 positionB = new Vector3(0.13407f, 1.0545f, 4f);
    Vector3 positionC = new Vector3(0.13407f, -0.89292f, 3.5819f);
    Vector3 positionD = new Vector3(0.13407f, -0.16139f, -1.8706f);

    void Start()
    {
        this.GetComponent<Renderer>().material.color = VBall.color1;
        baseColor = VBall.color1;
        changeColor = 1;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    void Awake()
    {
        newPosition = transform.position;
    }
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);

        //Debug.Log(changeColor);

        //color based on int changeColor value:
        if (changeColor <= 4)
        {
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 4 & changeColor <= 8)
        {
            VBall.color1 = Color.Lerp(VBall.color1, VBall.color2, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 8 & changeColor <= 12)
        {
            VBall.color1 = Color.Lerp(VBall.color1, VBall.color3, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 12 & changeColor <= 16)
        {
            VBall.color1 = Color.Lerp(VBall.color1, VBall.color4, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 16 & changeColor <= 20)
        {
            VBall.color1 = Color.Lerp(VBall.color1, VBall.color5, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 20 & changeColor <= 24)
        {
            VBall.color1 = Color.Lerp(VBall.color1, VBall.color6, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 24 & changeColor <= 28)
        {
            VBall.color1 = Color.Lerp(VBall.color1, VBall.color7, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 28 & changeColor <= 32)
        {
            VBall.color1 = Color.Lerp(VBall.color1, VBall.color8, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 32 & changeColor <= 36)
        {
            VBall.color1 = Color.Lerp(VBall.color1, VBall.color9, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 36 & changeColor <= 40)
        {
            VBall.color1 = Color.Lerp(VBall.color1, VBall.color10, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 40 & changeColor <= 44)
        {
            VBall.color1 = Color.Lerp(VBall.color1, baseColor, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = VBall.color1;
        }
        else if (changeColor > 44)
        {
            changeColor = 5;
        }
    }

    void OnTriggerEnter(Collider myTrigger) 
    {

        if (myTrigger.gameObject.name == "1")
        {
            newPosition = positionB;
            changeColor += 1;
        }

        else if (myTrigger.gameObject.name == "2")
        {
            newPosition = positionC;
            changeColor += 1;
        }

        else if (myTrigger.gameObject.name == "3")
        {
            newPosition = positionD;
            changeColor += 1;
        }

        else if (myTrigger.gameObject.name == "4")
        {
            newPosition = positionA;
            changeColor += 1;
        }

    }


}
