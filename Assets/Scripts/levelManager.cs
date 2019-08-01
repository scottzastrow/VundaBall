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

public class levelManager : MonoBehaviour {

    Text level;

	void Start () {
        level = GetComponent<Text>();
        level.text = "Level: " + VHealth.level;
	}
	
}
