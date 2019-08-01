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

public class MapColor : MonoBehaviour {

    public Color color;

    void Start()
    {
        this.GetComponent<Renderer>().material.color = color;
    }
}
