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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class pcellManager : MonoBehaviour {

    public Text powerCells;
    public Text baseText;
    public Text navText;
    public GameObject zeroPCells;
    public GameObject PCellPanel;
    public GameObject PCellTXTPanel;
    public static string theSeconds;
    public static bool turnOn;

    void Start()
    {
        powerCells = GetComponent<Text>();
        PCellTXTPanel.SetActive(true);
        turnOn = false;

    }

	void Update () {
        GameObject[] pCells = GameObject.FindGameObjectsWithTag("Sphere1");
        VBall.numPCells = pCells.Length;
        theSeconds = DateTime.Now.ToString("ss");     /////////////////////////////////////TimeLine Mechanism//////////////////
        if (VBall.numPCells != 0)
            powerCells.text = VBall.numPCells.ToString();
        else if (VBall.numPCells == 0)
        {

            PCellTXTPanel.SetActive(false);
            flashOnOff();
        }
	}

    void popUpText()
    {
        if (turnOn == false)
        {
            GameObject newPCs = Instantiate(zeroPCells) as GameObject;
            newPCs.transform.parent = PCellPanel.transform;
            RectTransform transform = newPCs.gameObject.GetComponent<RectTransform>();
            Vector2 position = transform.anchoredPosition;
            transform.anchoredPosition = new Vector2(0, 30);
            Destroy(newPCs, 2f);
        }
    }

    void flashOnOff()
    {
        

        if (int.Parse(theSeconds) % 2 != 0)
        {
            popUpText();
            turnOn = true;
            baseText.text = "Go To";
            navText.text = "Go To";
        }
        else if (int.Parse(theSeconds) % 2 == 0)
        {
            baseText.text = "The Base!";
            navText.text = "Base!";
        }
    }

}
