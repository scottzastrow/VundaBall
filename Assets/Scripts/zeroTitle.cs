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

public class zeroTitle : MonoBehaviour {

    Text zTitle;

	void Start () {
        zTitle = GetComponent<Text>();
        zTitle.text = "Bonus!!!";
	}
	

	void Update () {
        if (VHealth.coreTemp >= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
