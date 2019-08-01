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

public class ListBtnClick : MonoBehaviour {




    public void OnClick()
    {
        //print("Level: " + fileManager.gameArray[(int.Parse(this.name)), 3]);
        //print("Name used for OnClick: " + int.Parse(this.name));

        //Everything you need to load a game save
        fileManager.gameID = int.Parse(fileManager.gameArray[(int.Parse(this.name)), 0]);
        fileManager.getUser = fileManager.gameArray[(int.Parse(this.name)), 1];
        fileManager.getScore = fileManager.gameArray[(long.Parse(this.name)), 2];
        fileManager.getLevel = fileManager.gameArray[(int.Parse(this.name)), 3];
        fileManager.getLives = fileManager.gameArray[(int.Parse(this.name)), 4];
        fileManager.getDiff = fileManager.gameArray[(int.Parse(this.name)), 5];
        audioManager.getAudio = fileManager.gameArray[(int.Parse(this.name)), 6];
        VHealth.cameFromBegin = true;

        SceneManager.LoadScene("Level");
        VHealth.setTheLevel();
    }

    public void deleteOnClick()
    {
        fileManager.thisID = this.name;
        fileManager.removeFromXML();
        //print("ID: " + fileManager.thisID);
    }

}
