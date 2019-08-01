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

public class SpaPoints : MonoBehaviour {

    public Text ePoint;
    public GameObject ePanel;
    public static Vector3 vectorUp = new Vector3(0f, 1f, 0f);

    void Update()
    {
        ePanel.SetActive(true);
        ePoint.text = "+ " + levelSettings.eSphere.ToString();
        this.transform.Translate(vectorUp * 1.5f * Time.deltaTime, Space.World);
        StartCoroutine(waitForit());
  
    }

    IEnumerator waitForit()
    {
        yield return new WaitForSeconds(5f);
        ePanel.SetActive(false);
    }
	

}
