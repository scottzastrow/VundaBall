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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InGame : MonoBehaviour {


    public GameObject map;
    public GameObject VBall;
    public GameObject eBall1;
    public GameObject eBall2;
    public GameObject eBall3;
    public GameObject eBall4;
    public GameObject eBall5;
    public GameObject eBall6;
    public GameObject eBall7;
    public GameObject eBall8;
    public GameObject eBall9;
    public GameObject eBall10;
    public GameObject tank1;
    public GameObject tank2;
    public GameObject tank3;
    public GameObject tank4;
    public static bool tank1Active;
    public static bool tank2Active;
    public static bool tank3Active;
    public static bool tank4Active;
    public GameObject dion;
    public GameObject dionPanel;
    public GameObject homeBase;
    public Image arrow;
    public GameObject navigationPanel;
    private GameObject level;
    private GameObject LevelWalls;

    public void Start()
    {
 
        defineLevel();
        navigationPanel.SetActive(false);

        if (fileManager.getUser == null)
                fileManager.getUser = fileManager.gameArray[fileManager.gameID, 1];
            fileManager.addToXML();

            VBall.SetActive(true);
            homeBase.SetActive(true);
            dion.SetActive(true);
            dionPanel.SetActive(false);

            Resources.UnloadAsset(LevelWalls);
            LevelWalls = (GameObject)Instantiate(Resources.Load("Walls/level" + VHealth.level));
            LevelWalls.transform.parent = map.transform;
            LevelWalls.transform.localPosition = new Vector3(0f, 0f, 0f);
            LevelWalls.SetActive(true);

            GameObject Easy = GameObject.Find("EASY");
            GameObject Medium = GameObject.Find("MEDIUM");
            GameObject Hard = GameObject.Find("HARD");

            if (fileManager.getDiff == "2")
            {
                Easy.SetActive(true);
                Medium.SetActive(true);
                Hard.SetActive(true);
            }
            else if (fileManager.getDiff == "1")
            {
                Easy.SetActive(true);
                Medium.SetActive(true);
                Hard.SetActive(false);
            }
            else if (fileManager.getDiff == "0")
            {
                Easy.SetActive(true);
                Medium.SetActive(false);
                Hard.SetActive(false);
            }
            //if (fileManager.getID == null)
                fileManager.getID = fileManager.gameID.ToString();

            //Tanks
            if (tank1Active == true)
                tank1.SetActive(true);
            else if (tank1Active == false)
                tank1.SetActive(false);
            if (tank2Active == true)
                tank2.SetActive(true);
            else if (tank2Active == false)
                tank2.SetActive(false);
            if (tank3Active == true)
                tank3.SetActive(true);
            else if (tank3Active == false)
                tank3.SetActive(false);
            if (tank4Active == true)
                tank4.SetActive(true);
            else if (tank4Active == false)
                tank4.SetActive(false);

            //print("===============================InGame======================================getID " + fileManager.getID);
            //print("===============================InGame======================================gameID " + fileManager.gameID);
        
        //For Levels 40-50 Tanks have to be SetActive for each level/////////////////////////////////////////////////////////////////////////////////

        if (VHealth.level < 10)/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        {
            //eBalls
            eBall1.SetActive(true);
            eBall2.SetActive(true);
            eBall3.SetActive(true);
            eBall4.SetActive(true);
            eBall5.SetActive(true);
            eBall6.SetActive(true);
            eBall7.SetActive(false);
            eBall8.SetActive(false);
            eBall9.SetActive(false);
            eBall10.SetActive(false);


        }
        else if (VHealth.level >=10 & VHealth.level < 20)//////////////////////////////////////////////////////////////////////////////////////////////
        {
            //eBalls
            eBall1.SetActive(true);
            eBall2.SetActive(true);
            eBall3.SetActive(true);
            eBall4.SetActive(true);
            eBall5.SetActive(true);
            eBall6.SetActive(true);
            eBall7.SetActive(true);
            eBall8.SetActive(false);
            eBall9.SetActive(false);
            eBall10.SetActive(false);

        }

        else if (VHealth.level >= 20 & VHealth.level < 30)//////////////////////////////////////////////////////////////////////////////////////////////
        {
            //eBalls
            eBall1.SetActive(true);
            eBall2.SetActive(true);
            eBall3.SetActive(true);
            eBall4.SetActive(true);
            eBall5.SetActive(true);
            eBall6.SetActive(true);
            eBall7.SetActive(true);
            eBall8.SetActive(true);
            eBall9.SetActive(false);
            eBall10.SetActive(false);

        }

        else if (VHealth.level >= 30 & VHealth.level < 40)//////////////////////////////////////////////////////////////////////////////////////////////
        {
            //eBalls
            eBall1.SetActive(true);
            eBall2.SetActive(true);
            eBall3.SetActive(true);
            eBall4.SetActive(true);
            eBall5.SetActive(true);
            eBall6.SetActive(true);
            eBall7.SetActive(true);
            eBall8.SetActive(true);
            eBall9.SetActive(true);
            eBall10.SetActive(false);

        }

        else if (VHealth.level >= 40 & VHealth.level <= 50)//////////////////////////////////////////////////////////////////////////////////////////////
        {

            //eBalls
            eBall1.SetActive(true);
            eBall2.SetActive(true);
            eBall3.SetActive(true);
            eBall4.SetActive(true);
            eBall5.SetActive(true);
            eBall6.SetActive(true);
            eBall7.SetActive(true);
            eBall8.SetActive(true);
            eBall9.SetActive(true);
            eBall10.SetActive(true);
        }

        //VBall
        VBall.transform.localPosition = new Vector3(levelSettings.VBallVector.x, levelSettings.VBallVector.y, levelSettings.VBallVector.z);

        //Home base
        homeBase.transform.localPosition = new Vector3(levelSettings.baseVector.x, levelSettings.baseVector.y, levelSettings.baseVector.z);
        
        //Dion
        dion.transform.localPosition = new Vector3(levelSettings.dionVector.x, levelSettings.dionVector.y, levelSettings.dionVector.z);
        
        //eBalls
        eBall1.transform.localPosition = new Vector3(levelSettings.eBallVecotr1.x, levelSettings.eBallVecotr1.y, levelSettings.eBallVecotr1.z);
        eBall2.transform.localPosition = new Vector3(levelSettings.eBallVecotr2.x, levelSettings.eBallVecotr2.y, levelSettings.eBallVecotr2.z);
        eBall3.transform.localPosition = new Vector3(levelSettings.eBallVecotr3.x, levelSettings.eBallVecotr3.y, levelSettings.eBallVecotr3.z);
        eBall4.transform.localPosition = new Vector3(levelSettings.eBallVecotr4.x, levelSettings.eBallVecotr4.y, levelSettings.eBallVecotr4.z);
        eBall5.transform.localPosition = new Vector3(levelSettings.eBallVecotr5.x, levelSettings.eBallVecotr5.y, levelSettings.eBallVecotr5.z);
        eBall6.transform.localPosition = new Vector3(levelSettings.eBallVecotr6.x, levelSettings.eBallVecotr6.y, levelSettings.eBallVecotr6.z);
        eBall7.transform.localPosition = new Vector3(levelSettings.eBallVecotr7.x, levelSettings.eBallVecotr7.y, levelSettings.eBallVecotr7.z);
        eBall8.transform.localPosition = new Vector3(levelSettings.eBallVecotr8.x, levelSettings.eBallVecotr8.y, levelSettings.eBallVecotr8.z);
        eBall9.transform.localPosition = new Vector3(levelSettings.eBallVecotr9.x, levelSettings.eBallVecotr9.y, levelSettings.eBallVecotr9.z);
        eBall10.transform.localPosition = new Vector3(levelSettings.eBallVecotr10.x, levelSettings.eBallVecotr10.y, levelSettings.eBallVecotr10.z);

        //Tanks
        tank1.transform.localPosition = new Vector3(levelSettings.tankVector1.x, levelSettings.tankVector1.y, levelSettings.tankVector1.z);
        tank2.transform.localPosition = new Vector3(levelSettings.tankVector2.x, levelSettings.tankVector2.y, levelSettings.tankVector2.z);
        tank3.transform.localPosition = new Vector3(levelSettings.tankVector3.x, levelSettings.tankVector3.y, levelSettings.tankVector3.z);
        tank4.transform.localPosition = new Vector3(levelSettings.tankVector4.x, levelSettings.tankVector4.y, levelSettings.tankVector4.z);

        //print("X: " + levelSettings.baseVector.x + " Y: " + levelSettings.baseVector.y + " Z: " + levelSettings.baseVector.z);

    }
    void Update()
    {

        
        if(pcellManager.turnOn == true && fileManager.getDiff == "0" | VHealth.level == 1 | VHealth.level == 2 | VHealth.level == 3)
        {
            navigationPanel.SetActive(true);
            Vector3 VectorBall = VBall.transform.localPosition;
            Vector3 currentV3 = arrow.transform.eulerAngles;
            float spinSpeed = 3f;

            Vector3 headEast = new Vector3(0,0,90);
            Vector3 headNEast = new Vector3(0, 0, 130);
            Vector3 headLNEast = new Vector3(0,0,110);
            Vector3 headNorth = new Vector3(0, 0, 180);
            Vector3 headNWest = new Vector3(0, 0, 225);
            Vector3 headLNWest = new Vector3(0,0,245);
            Vector3 headWest = new Vector3(0, 0, 270);
            Vector3 headSWest = new Vector3(0, 0, 315);
            Vector3 headLSWest = new Vector3(0,0, 295);
            Vector3 headSouth = new Vector3(0, 0, 0);
            Vector3 headSEast = new Vector3(0, 0, 45);
            Vector3 headLSEast = new Vector3(0, 0, 65);

            if (VectorBall.z < levelSettings.baseVector.z - 15 & VectorBall.x < levelSettings.baseVector.x + 15 & VectorBall.x > levelSettings.baseVector.x - 15)
            {
                //print("Head East");
                arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headEast, Time.deltaTime * spinSpeed);
            }
            else if (VectorBall.z < levelSettings.baseVector.z - 15 & VectorBall.x > levelSettings.baseVector.x + 15)
            {
                //print("Head North East");
                if(VectorBall.z > levelSettings.baseVector.z - 35)
                    arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headNEast, Time.deltaTime * spinSpeed);
                else
                    arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headLNEast, Time.deltaTime * spinSpeed);
            }
            else if (VectorBall.z > levelSettings.baseVector.z - 15 & VectorBall.z < levelSettings.baseVector.z + 15 & VectorBall.x > levelSettings.baseVector.x + 15)
            {
                //print("Head North");
                arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headNorth, Time.deltaTime * spinSpeed);
            }
            else if (VectorBall.z > levelSettings.baseVector.z + 15 & VectorBall.x > levelSettings.baseVector.x + 15)
            {
                //print("Head North West");
                if(VectorBall.z < levelSettings.baseVector.z + 35)
                    arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headNWest, Time.deltaTime * spinSpeed);
                else
                    arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headLNWest, Time.deltaTime * spinSpeed);

            }
            else if (VectorBall.z > levelSettings.baseVector.z + 15 & VectorBall.x < levelSettings.baseVector.x + 15 & VectorBall.x > levelSettings.baseVector.x - 15)
            {
                //print("Head West");
                arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headWest, Time.deltaTime * spinSpeed);
            }
            else if (VectorBall.z > levelSettings.baseVector.z + 15 & VectorBall.x < levelSettings.baseVector.x - 15)
            {
                //print("Head South West");
                if(VectorBall.z < levelSettings.baseVector.z + 35)
                    arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headSWest, Time.deltaTime * spinSpeed);
                else
                    arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headLSWest, Time.deltaTime * spinSpeed);
            }
            else if (VectorBall.z < levelSettings.baseVector.z + 15 & VectorBall.z > levelSettings.baseVector.z - 15 & VectorBall.x < levelSettings.baseVector.x - 15)
            {
                //print("Head South");
                arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headSouth, Time.deltaTime * spinSpeed);
            }
            else if (VectorBall.z < levelSettings.baseVector.z - 15 & VectorBall.x < levelSettings.baseVector.x - 15)
            {
                //print("Head South East");
                if(VectorBall.z > levelSettings.baseVector.z - 35)
                    arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headSEast, Time.deltaTime * spinSpeed);
                else
                    arrow.transform.eulerAngles = Vector3.Slerp(currentV3, headLSEast, Time.deltaTime * spinSpeed);
            }
        }
        else
            navigationPanel.SetActive(false);


    }

    public void defineLevel()
    {
        if (VHealth.level == 1)
            levelSettings.level1();
        else if (VHealth.level == 2)
            levelSettings.level2();
        else if (VHealth.level == 3)
            levelSettings.level3();
        else if (VHealth.level == 4)
            levelSettings.level4();
        else if (VHealth.level == 5)
            levelSettings.level5();
        else if (VHealth.level == 6)
            levelSettings.level6();
        else if (VHealth.level == 7)
            levelSettings.level7();
        else if (VHealth.level == 8)
            levelSettings.level8();
        else if (VHealth.level == 9)
            levelSettings.level9();
        else if (VHealth.level == 10)
            levelSettings.level10();
        else if (VHealth.level == 11)
            levelSettings.level11();
        else if (VHealth.level == 12)
            levelSettings.level12();
        else if (VHealth.level == 13)
            levelSettings.level13();
        else if (VHealth.level == 14)
            levelSettings.level14();
        else if (VHealth.level == 15)
            levelSettings.level15();
        else if (VHealth.level == 16)
            levelSettings.level16();
        else if (VHealth.level == 17)
            levelSettings.level17();
        else if (VHealth.level == 18)
            levelSettings.level18();
        else if (VHealth.level == 19)
            levelSettings.level19();
        else if (VHealth.level == 20)
            levelSettings.level20();
        else if (VHealth.level == 21)
            levelSettings.level21();
        else if (VHealth.level == 22)
            levelSettings.level22();
        else if (VHealth.level == 23)
            levelSettings.level23();
        else if (VHealth.level == 24)
            levelSettings.level24();
        else if (VHealth.level == 25)
            levelSettings.level25();

    }

}
