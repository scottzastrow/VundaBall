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

public class Spin : MonoBehaviour {

    public float speed;

    void Update()
    {
        this.transform.Rotate(Vector3.down * 1.75f * Time.deltaTime * speed); /// rotates clockwise
    }
}
