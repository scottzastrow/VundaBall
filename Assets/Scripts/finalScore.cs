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

public class finalScore : MonoBehaviour {

    Text score;
    long myScore;

	void Start () {
        myScore = VHealth.theScore;
        score = GetComponent<Text>();
        score.text = "Your Score:\n" + myScore.ToString("#,##0");
	}
	

}
