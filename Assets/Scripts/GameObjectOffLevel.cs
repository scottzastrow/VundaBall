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
using UnityEngine.SceneManagement;

public class GameObjectOffLevel : MonoBehaviour {

    public string difficulty;
    public string difficultyTwo;
    private string theLevel;

    void Start()
    {
        theLevel = SceneManager.GetActiveScene().name;
        if (theLevel == "SandBox" )///////////////////////////////just for testing////////////////////////////////////////////////////
        {
            
            fileManager.getDiff = "0";//////////////////////////////////////////////just for testing////////////////////////////////////////////////////
            fileManager.getLevel = "4";////////////////////////////////////////////just for testing////////////////////////////////////////////////////
            //print("SandBox is loaded. " + fileManager.getDiff + " Level: " + fileManager.getLevel);
        }

        if (fileManager.getDiff == difficulty | fileManager.getDiff == difficultyTwo)
        {
            this.gameObject.SetActive(false);
        }

    }
}
