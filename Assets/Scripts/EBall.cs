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
using System.Collections.Generic;

public class EBall : MonoBehaviour {

	public GameObject ShockWave1;
    public GameObject pointsPanel;
    public GameObject bonusPanel;
    public AudioSource bonusSound;

    void Start()
    {
        this.GetComponent<Renderer>().enabled = true;
        this.GetComponent<Collider>().enabled = true;
    }

    void Update()
    {
        this.transform.Rotate(Vector3.down * 1.75f * Time.deltaTime * 50f); ///counter rotates clockwise
    }
    
    
    private void OnCollisionEnter(Collision eBump)
	{
		
		if (eBump.gameObject.name == "VBall" & VHealth.coreTemp >= 1)
		{
            VHealth.energy (); //Calling a static method from the VHealth Class.
            VHealth.eScore ();
			Instantiate (ShockWave1,transform.position, Quaternion.identity);
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
            SpaPoints scriptSpaPoints;
            scriptSpaPoints = pointsPanel.GetComponent<SpaPoints>();
            scriptSpaPoints.enabled = true;
            pointsPanel.SetActive(true);
            StartCoroutine(waitForit());
		}
        else if (VHealth.coreTemp < 1 & eBump.gameObject.name == "VBall") /////////////For extra points
        {
            VHealth.energy(); //Calling a static method from the VHealth Class.
            VHealth.eScore();
            VHealth.belowZero();
            Instantiate(ShockWave1, transform.position, Quaternion.identity);
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
            SpaPoints scriptSpaPoints;
            scriptSpaPoints = pointsPanel.GetComponent<SpaPoints>();
            scriptSpaPoints.enabled = true;
            pointsPanel.SetActive(true);
            BonusPoints scriptBonusPoints;
            scriptBonusPoints = bonusPanel.GetComponent<BonusPoints>();
            scriptBonusPoints.enabled = true;
            bonusPanel.SetActive(true);
            if (VBall.numPCells > 1)
            {

                bonusSound.Play();
            }
            StartCoroutine(waitForit());
        }

	}

    IEnumerator waitForit()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }

}
