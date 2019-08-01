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

public class TopScoreHightlight : MonoBehaviour {

    private Color hightlightBK = new Color(1f, 0f, 1f, .55f);
    private Color defaultColor = new Color(0f, 0f, 0f, .3f);
    public Text userLevel;
    private GameObject gamePanel;
    private Image gamePanelImage;
    public static bool boolMyColor;

	void Start ()
    {
        //Attached to Score Prefab
        
        gamePanel = GameObject.Find("Score# " + fileManager.getID);
        if (gamePanel != null)
        {
            gamePanelImage = gamePanel.GetComponent<Image>();
            if (boolMyColor == false)
                gamePanelImage.color = hightlightBK;
            else
            {
                gamePanelImage.color = defaultColor;
            }
            
            try
            {
                int level = int.Parse(userLevel.text);
                if (level > levelSettings.maxLevel)
                {
                    userLevel.text = levelSettings.maxLevel.ToString();
                }
            }
            catch
            {
                userLevel.text = "-";
            }
        }

	}
	

}
