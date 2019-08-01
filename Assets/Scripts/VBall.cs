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
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class VBall : MonoBehaviour
{
    public Text notReadyText;
    public GameObject myExplosion;
    public GameObject flashRing; //eBall Blowup.
    public AudioSource taDa;
    public AudioSource warning;
    public AudioSource explodingTank;
    public GameObject endImplulse;
    public Transform tankBlow;
    public static float finalTemp;
    public Transform farCamera;
    //public Transform closeCamera;
	private float audiopitch;
    public GameObject tank;
    public static Color color1 = new Color(.6f, .2f, .3f, 1f); //Maroon and Dark Blue Swirls        Calc. RGB Calc. 51/255 = .2f
    public static Color color2 = new Color(.6f, .2f, .3f, 1f); //Maroon and Dark Blue Swirls
    public static Color color3 = new Color(0f, .4f, 1f, 1f); //Blue and Dark Blue Swirls
    public static Color color4 = new Color(0f, .4f, 1f, 1f); //Blue and Dark Blue Swirls
    public static Color color5 = new Color(.37f, 1f, .37f, 1f); //Green and Blue Swirls
    public static Color color6 = new Color(.37f, 1f, .37f, 1f); //Green and Blue Swirls
    public static Color color7 = new Color(1f, 1f, .6f, 1f); //Light Yellow and Purple Swirls
    public static Color color8 = new Color(1f, 1f, .6f, 1f); //Light Yellow and Purple Swirls
    public static Color color9 = new Color(1f, 1f, 1f, 1f); //Bright White and Blue Swirls
    public static Color color10 = new Color(1f, 1f, 1f, 1f); //Bright White and Blue Swirls

    public static Color resetColor = new Color(.2f, .3f, .4f, 1f); //Dark Blue and Dark Blue Swirls

    public Transform endGame;
    private GameObject[] pCells;
    public static float numPCells;
    public static int levelStatus;
    public GameObject powerTube;
    private Color colorP1 = new Color(.8f, .8f, .88f, 1f);
    private Color colorP2 = new Color(.65f, .84f, .98f, 1f);
    public static bool systemOverload;
    public GameObject map;
    public GameObject tankMark;
    public GameObject grenade;
    public GameObject notReadyPanel;
    public static bool levelComplete;
    private bool soThatJustHappened;

	void Start()
    {
        notReadyPanel.SetActive(false);
        this.GetComponent<Renderer>().enabled = true;
		GetComponent<AudioSource>().pitch = audiopitch;
        powerTube.GetComponent<Renderer>().material.color = colorP1;
        finalTemp = 0f;
        levelComplete = false;
	}
	
	void Update()
	{
        //print("So That..." + soThatJustHappened + " is Kinetic? " + gameObject.GetComponent<Rigidbody>().isKinematic);
        if (VHealth.coreTemp >= 99.2f && VHealth.coreTemp < 1000f)
        {
            VHealth.coreTemp = 100f;
            if (VHealth.coreTemp == 100f)
            {
                VHealth.coreTemp = 1000f;
                Handheld.Vibrate();
                Instantiate(myExplosion, transform.position, transform.rotation);
                levelStatus = 1;
                this.GetComponent<Renderer>().enabled = false;
                this.GetComponent<Rigidbody>().isKinematic = true;
                systemOverload = true;
            }
        }

        if (VHealth.coreTemp < 10)
        {
            audiopitch = 1f;
            gameObject.GetComponent<Renderer>().material.color = resetColor;
            color1 = resetColor;
        }
        else if (VHealth.coreTemp >= 10 && VHealth.coreTemp < 20f)
        {
            audiopitch = 1.15f;
            color1 = Color.Lerp(color1, color2, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = color1;
        }
        else if (VHealth.coreTemp >= 20 && VHealth.coreTemp < 30f)
        {
            audiopitch = 1.25f;
            color1 = Color.Lerp(color1, color3, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = color1;
        }
        else if (VHealth.coreTemp >= 30 && VHealth.coreTemp < 40f)
        {
            audiopitch = 1.5f;
            color1 = Color.Lerp(color1, color4, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = color1;
        }
        else if (VHealth.coreTemp >= 40 && VHealth.coreTemp < 50f)
        {
            audiopitch = 1.75f;
            color1 = Color.Lerp(color1, color5, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = color1;
        }
        else if (VHealth.coreTemp >= 50 && VHealth.coreTemp < 60f)
        {
            audiopitch = 2f;
            color1 = Color.Lerp(color1, color6, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = color1;
        }
        else if (VHealth.coreTemp >= 60 && VHealth.coreTemp < 70f)
        {
            audiopitch = 2.25f;
            color1 = Color.Lerp(color1, color7, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = color1;
        }
        else if (VHealth.coreTemp >= 70 && VHealth.coreTemp < 80f)
        {
            audiopitch = 2.5f;
            color1 = Color.Lerp(color1, color8, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = color1;
        }
        else if (VHealth.coreTemp >= 80 && VHealth.coreTemp < 90f)
        {
            audiopitch = 2.75f;
            color1 = Color.Lerp(color1, color9, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = color1;
        }
        else if (VHealth.coreTemp >= 90 && VHealth.coreTemp <= 100f)
        {
            audiopitch = 3f;
            color1 = Color.Lerp(color1, color10, 1 * Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = color1;
        }

    }

    void OnTriggerEnter(Collider myTrigger)
        {
            if (myTrigger.gameObject.name == "snapToTheEnd" & soThatJustHappened == false)
            {
            transform.position = Vector3.Lerp(this.transform.position, endGame.position , 1f);
                StartCoroutine(doneReady());
            //print("snapToTheEnd");
            }

            else if (myTrigger.gameObject.tag == "snapCatch")
            {
                //Goto Starting position
                this.transform.position = Vector3.Lerp(this.transform.position, levelSettings.VBallVector, 1f);////////////Lerp Example//////////
                //StartCoroutine(notReady());

            //print("snapCatch");
        }
            else if (myTrigger.gameObject.name == "theEnd" & soThatJustHappened == false) 
            {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
                checkPower();
                if (numPCells == 0) //Make it to Home Base and you're done.
                {
                    levelStatus = 0;
                    powerTube.GetComponent<Renderer>().material.color = colorP2;
                    taDa.Play();
                    Instantiate(endImplulse, transform.position, transform.rotation);
                    getTemp();
                    //Debug.Log(finalTemp);
                    VHealth.coreTemp = 1001f;
                    StartCoroutine(waitForit());
                }
                else if (numPCells != 0) //Make it to Home Base and you're not done yet.
                {
                    warning.Play();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                for (int i = 0; i <= numPCells; i++)
                    {
                        if (i != 1)
                            notReadyText.text = i + "\n PowerCells left!";
                        else if (i == 1)
                            notReadyText.text = i + "\n PowerCell left!";
                    }
                StartCoroutine(notReady());
                //print("theEnd");
            }

            }
        }
    
    private void OnCollisionEnter(Collision Bump)
	{

		if (Bump.gameObject.tag == "Wall")
		{
			VHealth.wall (); //Calling a static method from the VHealth Class.	
			Handheld.Vibrate ();
			GetComponent<AudioSource>().pitch = audiopitch;
			//Debug.Log (audiopitch);
			GetComponent<AudioSource>().Play(); //Buzz sound
		}
      
        else if (Bump.gameObject.tag == "Grenade")
        {
            VHealth.coreTemp += levelSettings.hitGrenade;
            Handheld.Vibrate();
        }

	}
    IEnumerator fewSeconds()
    {
        yield return new WaitForSeconds(5f);
        tankMark.GetComponent<ParticleSystem>().Stop();
    }

    public void checkPower()
    {
        GameObject[] pCells = GameObject.FindGameObjectsWithTag("Sphere1");
        numPCells = pCells.Length;
    }

    public static void getTemp() 
    {
        finalTemp = VHealth.coreTemp; //Grabs last Temp. reading.
    }

    IEnumerator waitForit()
    {
        yield return new WaitForSeconds(4.0f);
        VHealth.level = VHealth.level + 1;
        if (VBall.numPCells == 0 && VHealth.level < levelSettings.maxLevel + 1)////////////////////////////////////////////Caps off Levels at 4///////////////////
            SceneManager.LoadScene("Level");//////////////////////////////////////////////////Loads Level AFter Level Complete/////////////////////////////////////
        else
        {
            VHealth.lives = 0;
            VHealth.baseScore = VHealth.theScore;
            fileManager.addToXML();
            fileManager.fromGame = true;
            SceneManager.LoadScene("Begin");

        }
    }
    IEnumerator notReady()
    {
        soThatJustHappened = true;
        notReadyPanel.SetActive(true);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(1.0f);
        notReadyPanel.SetActive(false);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(10.0f);        
        soThatJustHappened = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
    IEnumerator doneReady()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(1.0f);
    }


}
