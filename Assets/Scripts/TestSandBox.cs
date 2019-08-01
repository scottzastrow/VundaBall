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

public class TestSandBox : MonoBehaviour {

    void Update()
    {

        ////////////////Change Levels for testing at GameObjectOffLevels.cs///////////////
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
            if(Hard != null)
                Hard.SetActive(false);
        }
        else if (fileManager.getDiff == "0")
        {
            Easy.SetActive(true);
            if (Medium != null)
                Medium.SetActive(false);
            if (Hard != null)
                Hard.SetActive(false);
        }
        
        
        GameObject VundaBall = GameObject.Find("VBall");
        GameObject Dion = GameObject.Find("Dion");
        GameObject HomeBase = GameObject.Find("HomeBase");

        GameObject Tank1 = GameObject.Find("Tank1");
        GameObject Tank2 = GameObject.Find("Tank2");
        GameObject Tank3 = GameObject.Find("Tank3");
        GameObject Tank4 = GameObject.Find("Tank4");

        //Tanks
        if (InGame.tank1Active == true)
            Tank1.SetActive(true);
        else if (InGame.tank1Active == false & Tank1 != null)
            Tank1.SetActive(false);
        if (InGame.tank2Active == true)
            Tank2.SetActive(true);
        else if (InGame.tank2Active == false & Tank2 != null)
            Tank2.SetActive(false);
        if (InGame.tank3Active == true)
            Tank3.SetActive(true);
        else if (InGame.tank3Active == false & Tank3 != null)
            Tank3.SetActive(false);
        if (InGame.tank4Active == true)
            Tank4.SetActive(true);
        else if (InGame.tank4Active == false & Tank4 != null)
            Tank4.SetActive(false);


        if(Tank1 != null)
        Tank1.transform.localPosition = new Vector3(levelSettings.tankVector1.x, levelSettings.tankVector1.y, levelSettings.tankVector1.z);
        if(Tank2 != null)
        Tank2.transform.localPosition = new Vector3(levelSettings.tankVector2.x, levelSettings.tankVector2.y, levelSettings.tankVector2.z);
        if(Tank3 != null)
        Tank3.transform.localPosition = new Vector3(levelSettings.tankVector3.x, levelSettings.tankVector3.y, levelSettings.tankVector3.z);
        if(Tank4 != null)
        Tank4.transform.localPosition = new Vector3(levelSettings.tankVector4.x, levelSettings.tankVector4.y, levelSettings.tankVector4.z);
        

        //VBall
        VundaBall.transform.localPosition = new Vector3(levelSettings.VBallVector.x, levelSettings.VBallVector.y, levelSettings.VBallVector.z);
        VundaBall.SetActive(true);

        //Home base
        HomeBase.transform.localPosition = new Vector3(levelSettings.baseVector.x, levelSettings.baseVector.y, levelSettings.baseVector.z);
        HomeBase.SetActive(true);

        //Dion
        Dion.transform.localPosition = new Vector3(levelSettings.dionVector.x, levelSettings.dionVector.y, levelSettings.dionVector.z);
        Dion.SetActive(true);
        
        GameObject eBall1 = GameObject.Find("eBall1");
        GameObject eBall2 = GameObject.Find("eBall2");
        GameObject eBall3 = GameObject.Find("eBall3");
        GameObject eBall4 = GameObject.Find("eBall4");
        GameObject eBall5 = GameObject.Find("eBall5");
        GameObject eBall6 = GameObject.Find("eBall6");
        GameObject eBall7 = GameObject.Find("eBall7");
        GameObject eBall8 = GameObject.Find("eBall8");
        GameObject eBall9 = GameObject.Find("eBall9");
        GameObject eBall10 = GameObject.Find("eBall10");

        if (int.Parse(fileManager.getLevel) < 10)/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        {
            //eBalls
            eBall1.transform.localPosition = new Vector3(levelSettings.eBallVecotr1.x, levelSettings.eBallVecotr1.y, levelSettings.eBallVecotr1.z);
            eBall2.transform.localPosition = new Vector3(levelSettings.eBallVecotr2.x, levelSettings.eBallVecotr2.y, levelSettings.eBallVecotr2.z);
            eBall3.transform.localPosition = new Vector3(levelSettings.eBallVecotr3.x, levelSettings.eBallVecotr3.y, levelSettings.eBallVecotr3.z);
            eBall4.transform.localPosition = new Vector3(levelSettings.eBallVecotr4.x, levelSettings.eBallVecotr4.y, levelSettings.eBallVecotr4.z);
            eBall5.transform.localPosition = new Vector3(levelSettings.eBallVecotr5.x, levelSettings.eBallVecotr5.y, levelSettings.eBallVecotr5.z);
            eBall6.transform.localPosition = new Vector3(levelSettings.eBallVecotr6.x, levelSettings.eBallVecotr6.y, levelSettings.eBallVecotr6.z);
            eBall1.SetActive(true);
            eBall2.SetActive(true);
            eBall3.SetActive(true);
            eBall4.SetActive(true);
            eBall5.SetActive(true);
            eBall6.SetActive(true);
            if(eBall7 != null)
                eBall7.SetActive(false);
            if (eBall8 != null)
                eBall8.SetActive(false);
            if (eBall9 != null)
                eBall9.SetActive(false);
            if (eBall10 != null)
                eBall10.SetActive(false);

        }
        else if (int.Parse(fileManager.getLevel) >= 10 & int.Parse(fileManager.getLevel) < 20)//////////////////////////////////////////////////////////////////////////////////////////////
        {
            //eBalls
            eBall1.transform.localPosition = new Vector3(levelSettings.eBallVecotr1.x, levelSettings.eBallVecotr1.y, levelSettings.eBallVecotr1.z);
            eBall2.transform.localPosition = new Vector3(levelSettings.eBallVecotr2.x, levelSettings.eBallVecotr2.y, levelSettings.eBallVecotr2.z);
            eBall3.transform.localPosition = new Vector3(levelSettings.eBallVecotr3.x, levelSettings.eBallVecotr3.y, levelSettings.eBallVecotr3.z);
            eBall4.transform.localPosition = new Vector3(levelSettings.eBallVecotr4.x, levelSettings.eBallVecotr4.y, levelSettings.eBallVecotr4.z);
            eBall5.transform.localPosition = new Vector3(levelSettings.eBallVecotr5.x, levelSettings.eBallVecotr5.y, levelSettings.eBallVecotr5.z);
            eBall6.transform.localPosition = new Vector3(levelSettings.eBallVecotr6.x, levelSettings.eBallVecotr6.y, levelSettings.eBallVecotr6.z);
            eBall7.transform.localPosition = new Vector3(levelSettings.eBallVecotr7.x, levelSettings.eBallVecotr7.y, levelSettings.eBallVecotr7.z);
            eBall1.SetActive(true);
            eBall2.SetActive(true);
            eBall3.SetActive(true);
            eBall4.SetActive(true);
            eBall5.SetActive(true);
            eBall6.SetActive(true);
            eBall7.SetActive(true);
            if (eBall8 != null)
                eBall8.SetActive(false);
            if (eBall9 != null)
                eBall9.SetActive(false);
            if (eBall10 != null)
                eBall10.SetActive(false);

        }

        else if (int.Parse(fileManager.getLevel) >= 20 & int.Parse(fileManager.getLevel) < 30)//////////////////////////////////////////////////////////////////////////////////////////////
        {
            //eBalls
            eBall1.transform.localPosition = new Vector3(levelSettings.eBallVecotr1.x, levelSettings.eBallVecotr1.y, levelSettings.eBallVecotr1.z);
            eBall2.transform.localPosition = new Vector3(levelSettings.eBallVecotr2.x, levelSettings.eBallVecotr2.y, levelSettings.eBallVecotr2.z);
            eBall3.transform.localPosition = new Vector3(levelSettings.eBallVecotr3.x, levelSettings.eBallVecotr3.y, levelSettings.eBallVecotr3.z);
            eBall4.transform.localPosition = new Vector3(levelSettings.eBallVecotr4.x, levelSettings.eBallVecotr4.y, levelSettings.eBallVecotr4.z);
            eBall5.transform.localPosition = new Vector3(levelSettings.eBallVecotr5.x, levelSettings.eBallVecotr5.y, levelSettings.eBallVecotr5.z);
            eBall6.transform.localPosition = new Vector3(levelSettings.eBallVecotr6.x, levelSettings.eBallVecotr6.y, levelSettings.eBallVecotr6.z);
            eBall7.transform.localPosition = new Vector3(levelSettings.eBallVecotr7.x, levelSettings.eBallVecotr7.y, levelSettings.eBallVecotr7.z);
            eBall8.transform.localPosition = new Vector3(levelSettings.eBallVecotr8.x, levelSettings.eBallVecotr8.y, levelSettings.eBallVecotr8.z);
            eBall1.SetActive(true);
            eBall2.SetActive(true);
            eBall3.SetActive(true);
            eBall4.SetActive(true);
            eBall5.SetActive(true);
            eBall6.SetActive(true);
            eBall7.SetActive(true);
            eBall8.SetActive(true);
            if (eBall9 != null)
                eBall9.SetActive(false);
            if (eBall10 != null)
                eBall10.SetActive(false);

        }

        else if (int.Parse(fileManager.getLevel) >= 30 & int.Parse(fileManager.getLevel) < 40)//////////////////////////////////////////////////////////////////////////////////////////////
        {
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
            eBall1.SetActive(true);
            eBall2.SetActive(true);
            eBall3.SetActive(true);
            eBall4.SetActive(true);
            eBall5.SetActive(true);
            eBall6.SetActive(true);
            eBall7.SetActive(true);
            eBall8.SetActive(true);
            eBall9.SetActive(true);
            if (eBall10 != null)
                eBall10.SetActive(false);

        }

        else if (int.Parse(fileManager.getLevel) >= 40 & int.Parse(fileManager.getLevel) <= 50)//////////////////////////////////////////////////////////////////////////////////////////////
        {

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
    }

}
