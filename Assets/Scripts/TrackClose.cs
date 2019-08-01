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

public class TrackClose : MonoBehaviour {

    public Transform trackBall;
    public Transform myCamera;

	void Update ()
    {
        myCamera.transform.localPosition = new Vector3(trackBall.localPosition.x, trackBall.localPosition.y, .9f);
    }
	
}
