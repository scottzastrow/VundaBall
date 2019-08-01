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

public class Timer : MonoBehaviour {

    int timeCount;
    public Text timerCount;
    public GameObject timerPanel;
    public GameObject vBall;

    
    
	void Start ()
    {
        timeCount = 3;
        Freeze();
        StartCoroutine(countDown());
	}



    IEnumerator countDown()
    {
        while (timeCount > 0)
        {
            
            yield return new WaitForSeconds(1);

            timerCount.text = "Level: " + VHealth.level + "\n" + timeCount;

            timeCount -= 1;
        }
        
        timerCount.text = "-";
        UnFreeze();
    }

    public void Freeze()
    {
        vBall.GetComponent<Rigidbody>().isKinematic = true;
        timerPanel.SetActive(true);
    }
    public void UnFreeze()
    {
        vBall.GetComponent<Rigidbody>().isKinematic = false;
        timerPanel.SetActive(false);
    }


}
