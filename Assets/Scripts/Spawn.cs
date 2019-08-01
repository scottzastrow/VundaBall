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

public class Spawn : MonoBehaviour {
	
	public GameObject eBall;
    //public Transform DionText;
	public GameObject baseMap;
    private GameObject[] beginPCells;
    public static float beginNumPCells;
    //public Transform mySpawnPoint;
    //public Transform dionPoint;


    void Start()
    {
        getPCell();

    }

    void getPCell()
    {

        GameObject eBall1 = Instantiate(eBall, new Vector3(0f, 8.01648f, -35.67f), Quaternion.identity) as GameObject;
        eBall1.transform.parent = baseMap.transform;
    }

}
