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


public class DionPoints : MonoBehaviour {

    private Vector3 vectorUp = new Vector3(0f, 1f, 0f);
    public Text dPoint;
    public GameObject dionPanel;


    void Start()
    {
        dionPanel.SetActive(false);
        dPoint.text = "+ " + levelSettings.theDion.ToString();
    }

    void FixedUpdate()
    {
        if (Dion.vBallandDion == true) //References a public bool variable in Dion.cs
        {

            
            dionPanel.SetActive(true);
            dionPanel.transform.Translate(vectorUp * 1.5f * Time.deltaTime, Space.World);
            //Destroy(dionPanel.gameObject, 5f);
            StartCoroutine(waitForit());
        }
    }

    IEnumerator waitForit()
    {
        yield return new WaitForSeconds(5f);
        dionPanel.SetActive(false);
        //Dion.vBallandDion = false;
    }
}
