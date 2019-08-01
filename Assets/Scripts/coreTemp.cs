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
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class coreTemp : MonoBehaviour {
    //coreTemp is attached to Main Canvas
    public Slider tempSlider;
    public Text tempText;
    private string level;
    private string levelNum;
    private float temp;
    private float coreIntegrity;
    public static float corePoints;
    private string coreRating;
    private float heartHealth;
    public GameObject theHeart;
    private bool heartThrob;
    public GameObject VundaBall;
    private string theLevel;

    void Start()
    {
        theLevel = SceneManager.GetActiveScene().name;
        levelNum = VHealth.level.ToString();
        level = "Level" + levelNum;
        coreIntegrity = levelSettings.coreInt;

    }

    void Update()
    {
        if (VHealth.coreTemp >= 100 & VHealth.coreTemp < 1001)
        {
            heartHealth = 0;
        }
        else if (VHealth.coreTemp < 0)
        {
            heartHealth = 100 - VHealth.coreTemp;
        }
        else if (VHealth.coreTemp == 1001)
        {
            if (VBall.finalTemp <= 100 | VBall.finalTemp >= 0)
                heartHealth = 100 - VBall.finalTemp;
            else
                heartHealth = 1;
        }
        else
            heartHealth = 100 - VHealth.coreTemp;

        if (heartHealth <= 30)
        {
            //Run a method that uses pcellManager.theSeconds

            flashOnOff();
        }
        else if (heartHealth > 30)
        {
            stopFlash();
        }

        if (VHealth.coreTemp <= 100 | VHealth.coreTemp >= 0)
            tempSlider.value = heartHealth;
        else
            tempSlider.value = 1;

        if (theLevel == ("Level"))//////////////////////////////////////////////////Level Settings///////////////////////////////////////////////////////////
        {
            trackCoreTemp();
            overHeatRate();
            if (VHealth.coreTemp == 1000f | VundaBall.GetComponent<Renderer>().enabled == false)
            {
                StartCoroutine(waitForit());
            }
        }
    }

    public void flashOnOff()
    {
        if (int.Parse(pcellManager.theSeconds) % 2 != 0)
        {
            heartThrob = true;

        }
        else if (int.Parse(pcellManager.theSeconds) % 2 == 0)
        {
            heartThrob = false;
        }
        if (heartThrob == true)
        {
            theHeart.SetActive(false);
        }
        else
        {
            theHeart.SetActive(true);
            heartThrob = false;
        }
    }

    public void stopFlash()
    {
        heartThrob = false;
        theHeart.SetActive(true);
    }
    
    void trackCoreTemp()
    {
        if (VHealth.coreTemp < 1000f)
        {
            tempText.text = heartHealth.ToString("#,##0") + "%";
        }
        else if (VHealth.coreTemp == 1000)
            tempText.text = "Boom!!";

    }
    void overHeatRate()
    {
        if (VHealth.coreTemp < 1000f)
        {
        VHealth.coreTemp = VHealth.coreTemp + Time.deltaTime * levelSettings.overHeat;
        }
    }

    
    
    IEnumerator waitForit()
    {
        yield return new WaitForSeconds(4f);

        if (VHealth.lives > 1)
        {
            VHealth.lives -= 1;
            //SceneManager.LoadScene(VHealth.setLevel); //Restarts Previous level./////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SceneManager.LoadScene("Level");
        }

        else {
            VHealth.lives = 0;
            VHealth.baseScore = VHealth.theScore;
            fileManager.addToXML();
            fileManager.fromGame = true;
            SceneManager.LoadScene("Begin");///////////////////////////If you die///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }


}
