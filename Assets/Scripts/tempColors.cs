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

public class tempColors : Outline {

    private Color red = new Color(1f, 0f, 0f, 1f);
    private Color blue = new Color(0f, .6f, 1f, 1f);
    private Color white =  new Color(1f, 1f, 1f, .5f);
    private Color black = new Color(0f, 0f, 0f, .5f);
    public Text tempText;

	void Start () {
        tempText.color = red;
        effectColor = black;
	}
	

	void Update () {
        if (VHealth.coreTemp <= 0 | VBall.finalTemp <= 0)
        {
            tempText.color = blue;
            effectColor = white;
        }
        else 
        {
            tempText.color = red;
            effectColor = black;
        }
	}
}
