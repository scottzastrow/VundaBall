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

public class zeroRise : MonoBehaviour {

    public Text risingZero;

	void Start () {
        //risingZero = GetComponent<Text>();
        risingZero.text = "+"+ VHealth.subZero;
        VHealth.belowZero();
	}
	

	void Update () {
        transform.Translate(0, 1, 0 * Time.deltaTime, Space.World);
        Destroy(this.gameObject, 5f);
	}
}
