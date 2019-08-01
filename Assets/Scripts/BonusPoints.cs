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

public class BonusPoints : MonoBehaviour {

    public Text eBonus;
    public GameObject bonusPanel;
    public static Vector3 vectorUp = new Vector3(0f, 1f, 0f);	

	void Update () 
    {
        bonusPanel.SetActive(true);
        eBonus.text = "+" + VHealth.subZero;
        this.transform.Translate(vectorUp * 1.8f * Time.deltaTime, Space.World);
        StartCoroutine(waitForit());
	}

    IEnumerator waitForit()
    {
        yield return new WaitForSeconds(5f);
        bonusPanel.SetActive(false);
    }
}
