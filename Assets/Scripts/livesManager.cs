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

public class livesManager : MonoBehaviour {

    Text lives;

	void Start () {
        lives = GetComponent<Text>();
        lives.text = "Lives: " + VHealth.lives;
	}

    void Update()
    {
        lives.text = "Lives: " + VHealth.lives;
    }
	
}
