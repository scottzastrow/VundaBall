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

public class levelSettings : MonoBehaviour
{

    public static int maxLevel = 25;///////////////////////////Set to Max number of levels
    public static int level;
    public static int lives;
    public static float theCore;
    public static int eSphere;
    public static int vbWall;
    public static int hitGrenade;
    public static float overHeat;
    public static int subZero;
    public static int theDion;
    public static int theTank;
    public static long theScore;
    public static float diffSlider = 1;
    public static float audioSlider = 1;

    //Levelup Points.
    public static float powerCells;
    public static float coreInt;

    //Vectors
    public static Vector3 VBallVector;
    public static Vector3 dionVector;
    public static Vector3 baseVector;
    public static Vector3 eBallVecotr1;
    public static Vector3 eBallVecotr2;
    public static Vector3 eBallVecotr3;
    public static Vector3 eBallVecotr4;
    public static Vector3 eBallVecotr5;
    public static Vector3 eBallVecotr6;
    public static Vector3 eBallVecotr7;
    public static Vector3 eBallVecotr8;
    public static Vector3 eBallVecotr9;
    public static Vector3 eBallVecotr10;

    public static Vector3 tankVector1;
    public static Vector3 tankVector2;
    public static Vector3 tankVector3;
    public static Vector3 tankVector4;

    public static void begin()
    {
        theScore = 0;
    }
    public static void level1()////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    {
        //VBall
        VBallVector = new Vector3(0f, 4.5f, -90f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 90f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(-30f, 0f, -50f);

        //eBalls
        eBallVecotr1 = new Vector3(-27f, 8.2f, -90f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(27f, 8.2f, -90f);
        eBallVecotr3 = new Vector3(0f, 8.2f, -30f);
        eBallVecotr4 = new Vector3(0f, 8.2f, 30f);
        eBallVecotr5 = new Vector3(-27f, 8.2f, 110f);
        eBallVecotr6 = new Vector3(27f, 8.2f, 110f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, 0f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);

        level = 1;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 1;
        overHeat = .1f;
        subZero = 5;
        theDion = 5;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = false;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level2()////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    {

        //VBall
        VBallVector = new Vector3(0f, 4.5f, -115f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(-30f, 0f, 70f);

        //eBalls
        eBallVecotr1 = new Vector3(-27f, 8.2f, -90f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(27f, 8.2f, -90f);
        eBallVecotr3 = new Vector3(0f, 8.2f, -53f);
        eBallVecotr4 = new Vector3(0f, 8.2f, 53f);
        eBallVecotr5 = new Vector3(-27f, 8.2f, 110f);
        eBallVecotr6 = new Vector3(27f, 8.2f, 110f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(-32f, 0f, -20f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);

        level = 2;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 1;
        overHeat = .1f;
        subZero = 5;
        theDion = 5; //eSphere + scoreFactor is the points for Dion.
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;
        if (VHealth.theScore == 0)
            VHealth.theScore = 95;
        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
        {
            InGame.tank1Active = false;
            InGame.tank2Active = false;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
        else
        {
            InGame.tank1Active = true;
            InGame.tank2Active = false;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }

    }
    public static void level3()
    {
        //Vball 
        VBallVector = new Vector3(0f, 4.5f, -90f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, -110f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, 75f);

        //eBalls
        eBallVecotr1 = new Vector3(-15f, 8.2f, -60f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(15f, 8.2f, -60f);
        eBallVecotr3 = new Vector3(0f, 8.2f, -16f);
        eBallVecotr4 = new Vector3(0f, 8.2f, 30f);
        eBallVecotr5 = new Vector3(-27f, 8.2f, 110f);
        eBallVecotr6 = new Vector3(27f, 8.2f, 110f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(-31f, 0f, -27f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);

        level = 3;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 1;
        overHeat = .1f;
        subZero = 5;
        theDion = 5;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
        {
            InGame.tank1Active = false;
            InGame.tank2Active = false;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
        else
        {
            InGame.tank1Active = true;
            InGame.tank2Active = false;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
    }
    public static void level4()
    {
        //Vball 
        VBallVector = new Vector3(-29f, 4.5f, -50f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, 90f);

        //eBalls
        eBallVecotr1 = new Vector3(-30f, 8.2f, -122f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(30f, 8.2f, -122f);
        eBallVecotr3 = new Vector3(-26f, 8.2f, 0f);
        eBallVecotr4 = new Vector3(26f, 8.2f, 0f);
        eBallVecotr5 = new Vector3(-30f, 8.2f, 122f);
        eBallVecotr6 = new Vector3(30f, 8.2f, 122f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, -90f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);

        level = 4;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 1;
        overHeat = .1f;
        subZero = 5;
        theDion = 5;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = false;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
        else
        {
            InGame.tank1Active = true;
            InGame.tank2Active = false;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
    }
    public static void level5()
    {
        //Vball 
        VBallVector = new Vector3(0f, 4.5f, 35f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, -90f);

        //eBalls
        eBallVecotr1 = new Vector3(-31f, 8.2f, -125f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(31f, 8.2f, -125f);
        eBallVecotr3 = new Vector3(-30f, 8.2f, 0f);
        eBallVecotr4 = new Vector3(-31f, 8.2f, 125f);
        eBallVecotr5 = new Vector3(31f, 8.2f, 125f);
        eBallVecotr6 = new Vector3(30f, 8.2f, 0f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, 90f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);

        level = 5;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 1;
        overHeat = .1f;
        subZero = 5;
        theDion = 5;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level6()
    {
        //Vball 
        VBallVector = new Vector3(25f, 4.5f, -118f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(-25f, -0.1f, 118f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(26f, 0f, 119f);

        //eBalls
        eBallVecotr1 = new Vector3(26f, 8.2f, -62.5f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(-22f, 8.2f, -33f);
        eBallVecotr3 = new Vector3(25f, 8.2f, 10f);
        eBallVecotr4 = new Vector3(-25f, 8.2f, 30f);
        eBallVecotr5 = new Vector3(-26.6f, 8.2f, 90f);
        eBallVecotr6 = new Vector3(25f, 8.2f, 70f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, -50f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 6;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 1;
        overHeat = .1f;
        subZero = 5;
        theDion = 10;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level7()
    {
        //Vball 
        VBallVector = new Vector3(0f, 4.5f, -99f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, 85f);

        //eBalls
        eBallVecotr1 = new Vector3(0f, 8.2f, -70.5f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(0f, 8.2f, -43f);
        eBallVecotr3 = new Vector3(0f, 8.2f, 40f);
        eBallVecotr4 = new Vector3(0f, 8.2f, 120.9f);
        eBallVecotr5 = new Vector3(-28.8f, 8.2f, 0f);
        eBallVecotr6 = new Vector3(28.8f, 8.2f, 0f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(27f, 0f, 32f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 7;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 1;
        overHeat = .1f;
        subZero = 5;
        theDion = 10;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level8()
    {
        //Vball 
        VBallVector = new Vector3(25f, 4.5f, -118f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(-25f, -0.1f, -118f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(-23f, 0f, -8f);

        //eBalls
        eBallVecotr1 = new Vector3(25f, 8.2f, -60f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(-25f, 8.2f, -40f);
        eBallVecotr3 = new Vector3(25f, 8.2f, 10f);
        eBallVecotr4 = new Vector3(-25f, 8.2f, 30f);
        eBallVecotr5 = new Vector3(-25f, 8.2f, 90f);
        eBallVecotr6 = new Vector3(25f, 8.2f, 70f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, -50f);
        tankVector2 = new Vector3(0f, 0f, 50f);
        tankVector3 = new Vector3(0f, 0f, 120f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 8;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 1;
        overHeat = .1f;
        subZero = 5;
        theDion = 10;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
        else if (fileManager.getDiff == "1")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = true;
            InGame.tank4Active = false;
        }
        else
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = true;
            InGame.tank4Active = false;
        }
    }
    public static void level9()
    {
        //Vball 
        VBallVector = new Vector3(0f, 4.5f, -76.5f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, -50f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, 50f);

        //eBalls
        eBallVecotr1 = new Vector3(-30f, 8.2f, -123f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(30f, 8.2f, -123f);
        eBallVecotr3 = new Vector3(-30f, 8.2f, 123f);
        eBallVecotr4 = new Vector3(30f, 8.2f, 123f);
        eBallVecotr5 = new Vector3(-20f, 8.2f, 0f);
        eBallVecotr6 = new Vector3(20f, 8.2f, 0f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, 0f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 9;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 1;
        overHeat = .1f;
        subZero = 5;
        theDion = 10;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level10()
    {

        //Vball 
        VBallVector = new Vector3(-30f, 4.5f, -121f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 120f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(29f, 0f, 88f);

        //eBalls
        eBallVecotr1 = new Vector3(-20f, 8.2f, -100f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(20f, 8.2f, -100f);
        eBallVecotr3 = new Vector3(-27f, 8.2f, 60.5f);
        eBallVecotr4 = new Vector3(27f, 8.2f, 60.5f);
        eBallVecotr5 = new Vector3(0f, 8.2f, -4.5f);
        eBallVecotr6 = new Vector3(0f, 8.2f, 60.5f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 10f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, 93f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 10;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .1f;
        subZero = 10;
        theDion = 10;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level11()
    {
        //Vball 
        VBallVector = new Vector3(-25f, 4.5f, -120f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(-25f, -0.1f, 118f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, 90f);

        //eBalls
        eBallVecotr1 = new Vector3(-23f, 8.2f, 1.6f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(20f, 8.2f, -110f);
        eBallVecotr3 = new Vector3(-20f, 8.2f, -60f);
        eBallVecotr4 = new Vector3(20f, 8.2f, -60f);
        eBallVecotr5 = new Vector3(0f, 8.2f, -85f);
        eBallVecotr6 = new Vector3(29f, 8.2f, 123f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 60f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, -30f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 11;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .1f;
        subZero = 10;
        theDion = 15;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level12()
    {
        //Vball 
        VBallVector = new Vector3(-12f, 4.5f, -123f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(27f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(-20f, 0f, 50f);

        //eBalls
        eBallVecotr1 = new Vector3(-22.83f, 8.2f, -109.91f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(0f, 8.2f, -85f);
        eBallVecotr3 = new Vector3(20f, 8.2f, -60f);
        eBallVecotr4 = new Vector3(-25f, 8.2f, 0f);
        eBallVecotr5 = new Vector3(-22.83f, 8.2f, 109.91f);
        eBallVecotr6 = new Vector3(0f, 8.2f, 85f);
        eBallVecotr7 = new Vector3(20f, 8.2f, 60f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, 0f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 12;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .1f;
        subZero = 10;
        theDion = 15;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level13()
    {
        //Vball 
        VBallVector = new Vector3(-30f, 4.5f, -65f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, -123f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(-30f, 0f, 70f);

        //eBalls
        eBallVecotr1 = new Vector3(-27f, 8.2f, -92f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(27f, 8.2f, -92f);
        eBallVecotr3 = new Vector3(0f, 8.2f, -39.2f);
        eBallVecotr4 = new Vector3(0f, 8.2f, 39.2f);
        eBallVecotr5 = new Vector3(-27f, 8.2f, 95f);
        eBallVecotr6 = new Vector3(27f, 8.2f, 95f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 113.1f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, 0f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 13;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .2f;
        subZero = 10;
        theDion = 15;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level14()
    {
        //Vball 
        VBallVector = new Vector3(-31f, 4.5f, 29f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(-25f, 0f, -43f);

        //eBalls
        eBallVecotr1 = new Vector3(-27f, 8.2f, -92f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(27f, 8.2f, -92f);
        eBallVecotr3 = new Vector3(0f, 8.2f, -60.2f);
        eBallVecotr4 = new Vector3(0f, 8.2f, 111f);
        eBallVecotr5 = new Vector3(-30f, 8.2f, 60f);
        eBallVecotr6 = new Vector3(30f, 8.2f, 60f);
        eBallVecotr7 = new Vector3(0f, 8.2f, -121.7f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, -90f);
        tankVector2 = new Vector3(0f, 0f, 90f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 14;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .2f;
        subZero = 10;
        theDion = 15;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = true;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level15()
    {
        //Vball 
        VBallVector = new Vector3(33f, 4.5f, 21f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, 85f);

        //eBalls
        eBallVecotr1 = new Vector3(-20f, 8.2f, -96f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(20f, 8.2f, -96f);
        eBallVecotr3 = new Vector3(-20f, 8.2f, -60f);
        eBallVecotr4 = new Vector3(20f, 8.2f, -60f);
        eBallVecotr5 = new Vector3(-20f, 8.2f, 98.6f);
        eBallVecotr6 = new Vector3(20f, 8.2f, 98.6f);
        eBallVecotr7 = new Vector3(0f, 8.2f, 50f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, -75f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 15;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .2f;
        subZero = 10;
        theDion = 15;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level16()
    {
        //Vball 
        VBallVector = new Vector3(-25f, 4.5f, -115f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, 70f);

        //eBalls
        eBallVecotr1 = new Vector3(-25f, 8.2f, 110f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(-15f, 8.2f, 90f);
        eBallVecotr3 = new Vector3(-25f, 8.2f, 0f);
        eBallVecotr4 = new Vector3(25f, 8.2f, 0f);
        eBallVecotr5 = new Vector3(15f, 8.2f, 90f);
        eBallVecotr6 = new Vector3(25f, 8.2f, 110f);
        eBallVecotr7 = new Vector3(0f, 8.2f, -89.5f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, 120f);
        tankVector2 = new Vector3(-20f, 0f, 40f);
        tankVector3 = new Vector3(20f, 0f, 40f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 16;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .2f;
        subZero = 10;
        theDion = 20;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
        else if (fileManager.getDiff == "1")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = true;
            InGame.tank4Active = false;
        }
        else
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = true;
            InGame.tank4Active = false;
        }
    }
    public static void level17()
    {
        //Vball 
        VBallVector = new Vector3(-25f, 4.5f, -115f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(25f, -0.1f, -80f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(-24f, 0f, -24f);

        //eBalls
        eBallVecotr1 = new Vector3(7f, 8.2f, 123f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(-13f, 8.2f, 49f);
        eBallVecotr3 = new Vector3(27f, 8.2f, 70f);
        eBallVecotr4 = new Vector3(27f, 8.2f, 10f);
        eBallVecotr5 = new Vector3(-4f, 8.2f, -36f);
        eBallVecotr6 = new Vector3(25f, 8.2f, -115f);
        eBallVecotr7 = new Vector3(-27f, 8.2f, 30f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(-25f, 0f, -65f);
        tankVector2 = new Vector3(25f, 0f, 40f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 17;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .2f;
        subZero = 10;
        theDion = 20;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
        {
            InGame.tank1Active = false;
            InGame.tank2Active = true;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
        else
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
    }
    public static void level18()
    {
        //Vball 
        VBallVector = new Vector3(-25f, 4.5f, -115f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(29f, -0.1f, 34f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(25f, 0f, 119f);

        //eBalls
        eBallVecotr1 = new Vector3(-25f, 8.2f, 120f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(-9.5f, 8.2f, 90f);
        eBallVecotr3 = new Vector3(-11.7f, 8.2f, -26f);
        eBallVecotr4 = new Vector3(25f, 8.2f, 0f);
        eBallVecotr5 = new Vector3(8.7f, 8.2f, 90f);
        eBallVecotr6 = new Vector3(25f, 8.2f, -115f);
        eBallVecotr7 = new Vector3(0f, 8.2f, -82f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(25f, 0f, -37f);
        tankVector2 = new Vector3(-25f, 0f, 70f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 18;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .2f;
        subZero = 10;
        theDion = 20;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
        else
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
    }
    public static void level19()
    {
        //Vball 
        VBallVector = new Vector3(-12f, 4.5f, -123f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(27f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(-20f, 0f, 50f);

        //eBalls
        eBallVecotr1 = new Vector3(-22.83f, 8.2f, -109.91f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(0f, 8.2f, -85f);
        eBallVecotr3 = new Vector3(20f, 8.2f, -60f);
        eBallVecotr4 = new Vector3(-25f, 8.2f, 0f);
        eBallVecotr5 = new Vector3(-22.83f, 8.2f, 109.91f);
        eBallVecotr6 = new Vector3(0f, 8.2f, 85f);
        eBallVecotr7 = new Vector3(20f, 8.2f, 60f);
        eBallVecotr8 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, 0f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 19;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 10;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .2f;
        subZero = 10;
        theDion = 20;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level20()
    {
        //Vball 
        VBallVector = new Vector3(-20f, 4.5f, -115f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 115f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, 20f);

        //eBalls
        eBallVecotr1 = new Vector3(0f, 8.2f, 5f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(0f, 8.2f, 64.5f);
        eBallVecotr3 = new Vector3(28f, 8.2f, -34f);
        eBallVecotr4 = new Vector3(28f, 8.2f, 31.5f);
        eBallVecotr5 = new Vector3(0f, 8.2f, 80f);
        eBallVecotr6 = new Vector3(28f, 8.2f, -.5f);
        eBallVecotr7 = new Vector3(0f, 8.2f, -81f);
        eBallVecotr8 = new Vector3(-28f, 8.2f, -34f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(0f, 0f, -20f);
        tankVector2 = new Vector3(-25f, 0f, 70f);
        tankVector3 = new Vector3(27f, 0f, -95f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 20;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 15;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .3f;
        subZero = 15;
        theDion = 20;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
        }
        else if (fileManager.getDiff == "1")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = true;
            InGame.tank4Active = false;
        }
        else
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = true;
            InGame.tank4Active = false;
        }
    }
    public static void level21()
    {
        //Vball 
        VBallVector = new Vector3(-30f, 4.5f, -80f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(30f, 0f, 77f);

        //eBalls
        eBallVecotr1 = new Vector3(-24f, 8.2f, -24f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(-24f, 8.2f, 24f);
        eBallVecotr3 = new Vector3(24f, 8.2f, -24f);
        eBallVecotr4 = new Vector3(24f, 8.2f, 24f);
        eBallVecotr5 = new Vector3(-20f, 8.2f, -113f);
        eBallVecotr6 = new Vector3(20f, 8.2f, -113f);
        eBallVecotr7 = new Vector3(-20f, 8.2f, 113f);
        eBallVecotr8 = new Vector3(20f, 8.2f, 113f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);


        level = 21;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 15;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .3f;
        subZero = 15;
        theDion = 25;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = false;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
            tankVector1 = new Vector3(0f, 0f, 65f);
            tankVector2 = new Vector3(0f, 0f, 0f);
            tankVector3 = new Vector3(0f, 0f, 0f);
            tankVector4 = new Vector3(0f, 0f, 0f);
        }
        else if (fileManager.getDiff == "1")
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = false;
            InGame.tank4Active = false;
            tankVector1 = new Vector3(0f, 0f, 65f);
            tankVector2 = new Vector3(0f, 0f, -65f);
            tankVector3 = new Vector3(0f, 0f, 0f);
            tankVector4 = new Vector3(0f, 0f, 0f);
        }
        else
        {
            InGame.tank1Active = true;
            InGame.tank2Active = true;
            InGame.tank3Active = true;
            InGame.tank4Active = true;
            tankVector1 = new Vector3(-9f, 0f, -50.5f);
            tankVector2 = new Vector3(-9f, 0f, 51.5f);
            tankVector3 = new Vector3(9f, 0f, -50.5f);
            tankVector4 = new Vector3(9f, 0f, 51.5f);
        }
    }
    public static void level22()
    {
        //Vball
        VBallVector = new Vector3(-17f, 4.5f, -109f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 91.6f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(27f, 0f, 120f);

        //eBalls
        eBallVecotr1 = new Vector3(30f, 8.2f, -69f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(-30f, 8.2f, -123f);
        eBallVecotr3 = new Vector3(23f, 8.2f, 19f);
        eBallVecotr4 = new Vector3(-17f, 8.2f, 12f);
        eBallVecotr5 = new Vector3(0f, 8.2f, -18.5f);
        eBallVecotr6 = new Vector3(18f, 8.2f, -110.5f);
        eBallVecotr7 = new Vector3(30f, 8.2f, -53f);
        eBallVecotr8 = new Vector3(30f, 8.2f, 57f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(-28.3f, 0f, 121.1f);
        tankVector2 = new Vector3(0f, 0f, 0f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 22;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 15;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .3f;
        subZero = 15;
        theDion = 25;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = false;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level23()
    {
        //Vball 
        VBallVector = new Vector3(-28f, 4.5f, -121f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(-28f, -0.1f, 121f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(-31f, 0f, -28f);

        //eBalls
        eBallVecotr1 = new Vector3(0f, 8.2f, -90f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(0f, 8.2f, -42.2f);
        eBallVecotr3 = new Vector3(0f, 8.2f, 6f);
        eBallVecotr4 = new Vector3(0f, 8.2f, 94.5f);
        eBallVecotr5 = new Vector3(21f, 8.2f, 61f);
        eBallVecotr6 = new Vector3(21f, 8.2f, -40f);
        eBallVecotr7 = new Vector3(-22f, 8.2f, 42f);
        eBallVecotr8 = new Vector3(21f, 8.2f, 18f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(32f, 0f, 0f);
        tankVector2 = new Vector3(32f, 0f, -123f);
        tankVector3 = new Vector3(32f, 0f, 123f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 23;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 15;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .3f;
        subZero = 15;
        theDion = 25;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        if (fileManager.getDiff == "0")
            InGame.tank1Active = false;
        else
            InGame.tank1Active = true;
        InGame.tank2Active = true;
        InGame.tank3Active = true;
        InGame.tank4Active = false;
    }
    public static void level24()
    {
        //Vball 
        VBallVector = new Vector3(0f, 4.5f, -58.5f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, 106.5f);

        //eBalls
        eBallVecotr1 = new Vector3(28f, 8.2f, -88f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(-28f, 8.2f, -27.5f);
        eBallVecotr3 = new Vector3(0f, 8.2f, 58.5f);
        eBallVecotr4 = new Vector3(0f, 8.2f, -106.5f);
        eBallVecotr5 = new Vector3(28f, 8.2f, 27.5f);
        eBallVecotr6 = new Vector3(-28f, 8.2f, 87.5f);
        eBallVecotr7 = new Vector3(28f, 8.2f, 87.5f);
        eBallVecotr8 = new Vector3(-28f, 8.2f, -88f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(31f, 0f, -27.5f);
        tankVector2 = new Vector3(-31f, 0f, 29.5f);
        tankVector3 = new Vector3(0f, 0f, 0f);
        tankVector4 = new Vector3(0f, 0f, 0f);
        level = 24;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 15;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .3f;
        subZero = 15;
        theDion = 25;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = true;
        InGame.tank3Active = false;
        InGame.tank4Active = false;
    }
    public static void level25()
    {
        //Vball 
        VBallVector = new Vector3(0f, 4.5f, -120f); //Keep Y at 4.5f

        //Home Base
        baseVector = new Vector3(0f, -0.1f, 0f); //Keep Y at -0.1f

        //Dion
        dionVector = new Vector3(0f, 0f, -100f);

        //eBalls
        eBallVecotr1 = new Vector3(0f, 8.2f, -70f); //Keep Y at 8.2f
        eBallVecotr2 = new Vector3(-30f, 8.2f, 0f);
        eBallVecotr3 = new Vector3(30f, 8.2f, 0f);
        eBallVecotr4 = new Vector3(0f, 8.2f, 70f);
        eBallVecotr5 = new Vector3(30f, 8.2f, 70f);
        eBallVecotr6 = new Vector3(-30f, 8.2f, 70f);
        eBallVecotr7 = new Vector3(15f, 8.2f, 125f);
        eBallVecotr8 = new Vector3(-15f, 8.2f, 125f);
        eBallVecotr9 = new Vector3(0f, 8.2f, 0f);
        eBallVecotr10 = new Vector3(0f, 8.2f, 0f);

        //Tanks
        tankVector1 = new Vector3(-30f, 0f, -123f);
        tankVector2 = new Vector3(30f, 0f, -123f);
        tankVector3 = new Vector3(-30f, 0f, 123f);
        tankVector4 = new Vector3(30f, 0f, 123f);
        level = 25;///////////////////////////////////////////////////////
        theCore = 0f;
        eSphere = 15;
        vbWall = 5;
        hitGrenade = 2;
        overHeat = .3f;
        subZero = 15;
        theDion = 25;
        theTank = 50;
        if (VBall.levelStatus == 0)
            theScore = VHealth.theScore; // only if level complete!
        else if (VBall.levelStatus != 0)
            theScore = VHealth.baseScore;

        //Levelup Points.
        powerCells = 25f;
        coreInt = 25f;

        //Tank Activation
        InGame.tank1Active = true;
        InGame.tank2Active = true;
        InGame.tank3Active = true;
        InGame.tank4Active = true;
    }

}