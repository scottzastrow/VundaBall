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

public class TankPoints : MonoBehaviour
{
    private Vector3 vectorUp = new Vector3(0f, 1f, 0f);
    public Text TankPoint;
    public static bool tankBoom;
    public GameObject tankPanel;

	/*void Start () {
        tankBoom = false;
        tankPanel.SetActive(false);
        TankPoint.text = "+ " + VHealth.hitTank.ToString();
	}*/

    void Update()
    {
        TankPoint.text = "+ " + levelSettings.theTank.ToString();
            tankPanel.SetActive(true);
            tankPanel.transform.Translate(vectorUp * 1.5f * Time.deltaTime, Space.World);
            Destroy(tankPanel.gameObject, 5f);
            StartCoroutine(waitForit());

    }

    IEnumerator waitForit()
    {
        yield return new WaitForSeconds(5f);
        tankPanel.SetActive(false);
    }

}
