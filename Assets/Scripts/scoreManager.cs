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

public class scoreManager : MonoBehaviour {

    Text myScore;


	void Start () {
        myScore = GetComponent<Text>();
	}
	

	void Update () {
        myScore.text = "Score: " + VHealth.theScore.ToString("#,##0");
	}
}
