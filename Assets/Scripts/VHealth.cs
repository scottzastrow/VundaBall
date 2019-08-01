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

public class VHealth : MonoBehaviour
{

    public static string setLevel;
    public static string setNextLevel;
    public static int level;
    public static int lives;
    public static float coreTemp;
    public static long theScore;
    public static long baseScore;
    public static int powerUpCore;
    public static float powerCells;
    public static int subZero;
    public Text userName;
    public static bool cameFromBegin;


    void Start()
    {
        userName.text = fileManager.getUser;
            setTheLevel();
            if (cameFromBegin == true)
            {
                level = int.Parse(fileManager.getLevel);
                lives = int.Parse(fileManager.getLives);
                baseScore = theScore = long.Parse(fileManager.getScore);
                userName.text = fileManager.getUser;
                cameFromBegin = false;
                
            }
            else
            {
                if (VBall.systemOverload == true)
                {
                    PlayerPrefs.SetString("Level", "Incomplete");
                    theScore = baseScore;
                    VBall.systemOverload = false;
                    PlayerPrefs.SetInt("TanksInPlay", 0);
            }
                else if (VBall.systemOverload == false)
                {
                    PlayerPrefs.SetString("Level", "Complete");
                    baseScore = theScore;
                    PlayerPrefs.SetInt("BustedTanks", (PlayerPrefs.GetInt("BustedTanks") + PlayerPrefs.GetInt("TanksInPlay")));
                    PlayerPrefs.SetInt("TanksInPlay", 0);
            }

                //print("WARNING: VHealth says File Manager data was Null.");

            }


        Screen.sleepTimeout = (int)SleepTimeout.NeverSleep; //Disable screen dimming may also be Screen.sleepTimeout = SleepTimeout.NeverSleep; OR Screen.sleepTimeout = 0.0f;

        coreTemp = levelSettings.theCore;

        //Levelup
        powerCells = levelSettings.powerCells;
        subZero = levelSettings.subZero;

        setLevel = (level).ToString(); /////////////////////////////////////////////////////////////where is setLevel being used/////////////////////////////////////////////////////////////////
        setNextLevel = (level + 1).ToString(); ////////////////////////////////////////////////////CoreTemp uses it/////////////////////////////////////////////////////////////////////////////

    }

    public static void energy() //For eSphere.
    {
        coreTemp -= levelSettings.eSphere;
    }
    public static void energyDion() //For Dion.
    {
        coreTemp -= levelSettings.eSphere;
    }

    public static void eScore() //For eSphere.
    {
        theScore += levelSettings.eSphere;
    }
    public static void dScore() //For Dion.
    {
        theScore += levelSettings.theDion;
        //lives += 1;
    }

    public static void tankBuster()
    {
        theScore += levelSettings.theTank;
        PlayerPrefs.SetInt("TanksInPlay", (PlayerPrefs.GetInt("TanksInPlay") + 1));
    }

    public static void belowZero()
    {
        theScore += subZero;
    }

    public static void wall()
    {
        coreTemp += levelSettings.vbWall;
    }

    public static void PrivaTank()
    {
        coreTemp += levelSettings.theTank;
    }
    public static void setTheLevel()/////////////////////////////////////////////////////////Sets for Start the level from fileManager//////////////////////////////////////////////////////////////////
    {

        if (fileManager.getLevel == "1")
            levelSettings.level1();
        else if (fileManager.getLevel == "2")
            levelSettings.level2();
        else if (fileManager.getLevel == "3")
            levelSettings.level3();
        else if (fileManager.getLevel == "4")
            levelSettings.level4();
        else if (fileManager.getLevel == "5")
            levelSettings.level5();
        else if (fileManager.getLevel == "6")
            levelSettings.level6();
        else if (fileManager.getLevel == "7")
            levelSettings.level7();
        else if (fileManager.getLevel == "8")
            levelSettings.level8();
        else if (fileManager.getLevel == "9")
            levelSettings.level9();
        else if (fileManager.getLevel == "10")
            levelSettings.level10();
        else if (fileManager.getLevel == "11")
            levelSettings.level11();
        else if (fileManager.getLevel == "12")
            levelSettings.level12();
        else if (fileManager.getLevel == "13")
            levelSettings.level13();
        else if (fileManager.getLevel == "14")
            levelSettings.level14();
        else if (fileManager.getLevel == "15")
            levelSettings.level15();
        else if (fileManager.getLevel == "16")
            levelSettings.level16();
        else if (fileManager.getLevel == "17")
            levelSettings.level17();
        else if (fileManager.getLevel == "18")
            levelSettings.level18();
        else if (fileManager.getLevel == "19")
            levelSettings.level19();
        else if (fileManager.getLevel == "20")
            levelSettings.level20();
        else if (fileManager.getLevel == "21")
            levelSettings.level21();
        else if (fileManager.getLevel == "22")
            levelSettings.level22();
        else if (fileManager.getLevel == "23")
            levelSettings.level23();
        else if (fileManager.getLevel == "24")
            levelSettings.level24();
        else if (fileManager.getLevel == "25")
            levelSettings.level25();
    }

}
