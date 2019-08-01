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

public class SwipeHandler : MonoBehaviour
{
	public float minMovement = 10.0f;
    public GameObject panelOne;
    public GameObject panelTwo;
    public GameObject panelThree;
    public GameObject panelFour;
    public GameObject panelFive;
    public GameObject panelSix;
    public GameObject panelSeven;
    public GameObject creditsPanel;
	
	void Start ()
	{
        panelOne.SetActive(true);
        panelTwo.SetActive(false);
        panelThree.SetActive(false);
        panelFour.SetActive(false);
        panelFive.SetActive(false);
        panelSix.SetActive(false);
        panelSeven.SetActive(false);
        creditsPanel.SetActive(false);
	}	
	private Vector2 StartPos;
	private int SwipeID = -1;
	
	void Update ()
	{
		foreach (var T in Input.touches)
		{
			var P = T.position;
			if (T.phase == TouchPhase.Began && SwipeID == -1)
			{
				SwipeID = T.fingerId;
				StartPos = P;
			}
			else if (T.fingerId == SwipeID)
			{
				var delta = P - StartPos;
				if (T.phase == TouchPhase.Moved && delta.magnitude > minMovement)
				{
					SwipeID = -1;
					if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
					{
						if (delta.x > 0)
						{
                            //print("Swipe Right");
                            PanelManagerRight();
                        }//Swipe Right

						else if (delta.x < 0)
						{
                            //print("Swipe Left");
                            panelManagerLeft();
                        }//Swipe Left
					}
					else
					{

						if (delta.y > 0)
                        { //Swipe Up
                            //print("Swipe Up");
                            panelManagerLeft();
                        }

						else if (delta.y < 0)
						{ //Swipe Down
                            //print("Swipe Down");
                            PanelManagerRight();
						}
					}
				}
				else if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended)
					SwipeID = -1;
			}
		}
	}

    private void panelManagerLeft()
    {
        if (panelOne.activeInHierarchy)
        {
            panelOne.SetActive(false);
            panelTwo.SetActive(true);
        }
        else if(panelTwo.activeInHierarchy)
        {
            panelTwo.SetActive(false);
            panelThree.SetActive(true);
        }
        else if(panelThree.activeInHierarchy)
        {
            panelThree.SetActive(false);
            panelFour.SetActive(true);
        }
        else if(panelFour.activeInHierarchy)
        {
            panelFour.SetActive(false);
            panelFive.SetActive(true);
        }
        else if(panelFive.activeInHierarchy)
        {
            panelFive.SetActive(false);
            panelSix.SetActive(true);
        }
        else if(panelSix.activeInHierarchy)
        {
            panelSix.SetActive(false);
            panelSeven.SetActive(true);
        }
        else if(panelSeven.activeInHierarchy)
        {
            panelSeven.SetActive(false);
            creditsPanel.SetActive(true);
        }
    }
    private void PanelManagerRight()
    {
        if(creditsPanel.activeInHierarchy)
        {
            creditsPanel.SetActive(false);
            panelSeven.SetActive(true);
        }
        else if (panelSeven.activeInHierarchy)
        {
            panelSeven.SetActive(false);
            panelSix.SetActive(true);
        }
        else if(panelSix.activeInHierarchy)
        {
            panelSix.SetActive(false);
            panelFive.SetActive(true);
        }
        else if(panelFive.activeInHierarchy)
        {
            panelFive.SetActive(false);
            panelFour.SetActive(true);
        }
        else if(panelFour.activeInHierarchy)
        {
            panelFour.SetActive(false);
            panelThree.SetActive(true);
        }
        else if(panelThree.activeInHierarchy)
        {
            panelThree.SetActive(false);
            panelTwo.SetActive(true);
        }
        else if(panelTwo.activeInHierarchy)
        {
            panelTwo.SetActive(false);
            panelOne.SetActive(true);
        }
    }
}