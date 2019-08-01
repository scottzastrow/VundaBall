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
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.Xml;
using System.Security.Cryptography;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]

public class fileManager : MonoBehaviour
{

    public static int gameID;
    public static string currentDate;
    public static string currentTime;
    public static string getID;
    public static string getUser;
    public static string getScore;
    public static string getLevel;
    public static string getLives;
    public static string getDiff;
    public static string getDate;
    public static string getTime;
    public InputField assignUser;
    public static XmlDocument xDoc = new XmlDocument();
    public static string getXML;
    public GameObject userPanel;
    public GameObject setTheDiff;
    public GameObject setTheGame;
    public GameObject displayScoreBoard;
    public static int maxCount;
    public static bool recordMatch;
    public static string[,] gameArray;
    public static string[,] scoreArray;
    public static string[,] topTenArray = new string[10, 5];
    public Text txtUsername;
    public Text txtLevel;
    public Text txtLives;
    public Text txtDifficulty;
    public Text txtDate;
    public Text txtScore;
    public Text txtGameSave;
    public Text scrTXTRank;
    public Text scrTXTUser;
    public Text scrTXTLevel;
    public Text scrTXTDate;
    public Text scrTXTScore;
    public Text scrTXTDiff;
    public Text scrTXTID;
    public GameObject deletePanel;
    public GameObject deleteButton;
    public GameObject pinScore;
    public GameObject Score;
    public GameObject ScorePanel;
    public GameObject listPanel;
    public GameObject howToPanel;
    private Boolean openFromDiff;
    public Button listButton;
    public GameObject newGame;
    private string userName;
    public Slider difficultySetting;
    public static bool fromGame;
    private int scoreID = 0;
    public Text txtFinlScore;
    public static String thisID;
    private int rotate;

    private int[,] sortArray;


    public void Start()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetString("IAP", "YesIAP");
        rotate = 1;
        TopScoreHightlight.boolMyColor = false;
        txtFinlScore.text = VHealth.baseScore.ToString();
        if (fromGame == false)
        {
            activateSettingsPanel();
            userPanel.transform.SetSiblingIndex(4);
            deactivateDiffPanel();
            deactivateGamePanel();
            deactivateNewGame();
            deactivateScoreBoard();
            deactivateHowToPanel();
            openFromDiff = false;
            if (getUser != null)
            {
                assignUser.text = getUser;
            }
            //print("In Start fromGame == false: " + fromGame);

        }
        else if (fromGame == true)
        {
            txtFinlScore.text = VHealth.baseScore.ToString();
            activateScoreBoard();
            deactivateDiffPanel();
            deactivateGamePanel();
            deactivateNewGame();
            deactivateSettingsPanel();
            deactivateHowToPanel();
            openFromDiff = false;
            highScore();
            assignUser.text = getUser;
            //print(getUser);
            //print("In Start fromGame == true: " + fromGame);

        }
        openXML();
        if(getDiff == null)
            getDiff = "1";
        recordMatch = true;
    }

    void Update()
    {
        if (fromGame == true)
        {

            //print("In UPdate fromGame == true: " + fromGame);
            activateScoreBoard();
            ScorePanel.transform.SetSiblingIndex(4);
            deactivateDiffPanel();
            deactivateGamePanel();
            deactivateNewGame();
            deactivateSettingsPanel();
            TopScoreHightlight.boolMyColor = false;
            highScore();
            assignUser.text = getUser;
            //print(getUser);
            fromGame = false;
        }
    }

    public void openXML()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.wi"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.wi", FileMode.Open);
            getXML = ((string)bf.Deserialize(file));
            xDoc.Load(new StringReader(getXML));
            file.Close();
            print(xDoc.OuterXml + " File exists!");


        }
        else
        {
            xDoc.Load(Application.dataPath + "/Raw/gamesave.txt"); //Pulls from Streaming Assets
            saveXML(xDoc);
            print(xDoc.ToString() + " File had to load from text file.");
        }

    }

    public static void saveXML(XmlDocument xmlDoc)
    {
        StringBuilder myXmlDoc = new StringBuilder(xmlDoc.InnerXml);
        getXML = myXmlDoc.ToString();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.wi");
        bf.Serialize(file, getXML);
        file.Close();
        //print("gamsave.wi was just saved.");
    }

    public void deleteXML()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.wi"))
        {
            File.Delete(Application.persistentDataPath + "/gamesave.wi");
            openXML();
            print("GameSave.Wi is Deleted");
        }
        else
            print("No Such File Exists.");
    }

    public void createID()
    {
        XmlNode getKey = xDoc.SelectSingleNode("Root/idkey");
        gameID = (int.Parse(getKey.InnerText)+1);
        getKey.InnerText = gameID.ToString();
        dateTime();
    }

    public static void dateTime()
    {
        currentDate = DateTime.Now.ToString("MM-dd-yy");
        currentTime = DateTime.Now.ToString("hh:mmtt");
    }

    public void highScore()
    {

        if (getDiff == "0")
            scrTXTDiff.text = "Easy";
        else if (getDiff == "1")
            scrTXTDiff.text = "Medium";
        else if (getDiff == "2")
            scrTXTDiff.text = "Hard";
        if (xDoc != null)
        {
            //print("++++++++++++++++++++++++++++++++++++++++fileManager Start++++++++++++++++++++++++++++++++++++++++++++getID: " + getID);
            //print("++++++++++++++++++++++++++++++++++++++++fileManager Start++++++++++++++++++++++++++++++++++++++++++++gameID: " + gameID);
            XmlNodeList xScore = xDoc.SelectNodes("Root/gamesave[@lives='0' and @diff='" + getDiff + "']");////and @diff='0' '1' '2' //////

            if (xScore.Count > 0)
            {
                /////////////////Make High Score Array/////////////
                scoreArray = new string[xScore.Count, 5];
                int[] idArray = new int[xScore.Count];
                int[] theScores = new int[xScore.Count];
                int[,] sortedArray = new int[xScore.Count, 2];

                for (int i = 0; i < xScore.Count; i++)
                {
                    idArray[i] = int.Parse(xScore[i].Attributes["id"].Value);
                    theScores[i] = int.Parse(xScore[i].Attributes["score"].Value);
                }

                for (int i = 0; i < xScore.Count; i++)
                {
                    scoreArray[i, 0] = xScore[i].Attributes["id"].Value;
                    scoreArray[i, 1] = xScore[i].Attributes["user"].Value;
                    scoreArray[i, 2] = xScore[i].Attributes["score"].Value; ///////////Score [ i, 2 ]//////////
                    scoreArray[i, 3] = xScore[i].Attributes["level"].Value;
                    scoreArray[i, 4] = xScore[i].Attributes["date"].Value;
                    //print("ID: " + scoreArray[i,0] + " Score: " + scoreArray[i,2] + " Tag: " + scoreArray[i,5]);
                }

                Array.Sort(theScores, idArray);

                int yLoop = 0;
                for (int i = theScores.Length - 1; i >= 0; i--)
                {
                    //print(i + ":" + " The ID: " + idArray[i] + " the Score: " + theScores[i]);
                    sortedArray[yLoop, 0] = idArray[i];
                    sortedArray[yLoop, 1] = theScores[i];
                    //print(i + ":" + " The ID: " + sortedArray[i, 0] + " the Score: " + sortedArray[i, 1]);
                    yLoop += 1;
                }
                if (theScores.Length >= 10)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        for (int i = 0; i < xScore.Count; i++)
                        {
                            if (sortedArray[y, 0] == int.Parse(scoreArray[i, 0])) //Finds Top Score in scoredArray
                            {
                                //print("ID: " + scoreArray[i, 0] + " User: " + scoreArray[i, 1] + " Score: " + scoreArray[i, 2]);

                                topTenArray[y, 0] = scoreArray[i, 0];
                                topTenArray[y, 1] = scoreArray[i, 1];
                                topTenArray[y, 2] = scoreArray[i, 2];
                                topTenArray[y, 3] = scoreArray[i, 3];
                                topTenArray[y, 4] = scoreArray[i, 4];
                            }
                        }
                    }
                }
                else
                {
                    for (int y = 0; y < theScores.Length; y++)
                    {
                        for (int i = 0; i < xScore.Count; i++)
                        {
                            if (sortedArray[y, 0] == int.Parse(scoreArray[i, 0])) //Finds Top Score in scoredArray
                            {
                                //print("ID: " + scoreArray[i, 0] + " User: " + scoreArray[i, 1] + " Score: " + scoreArray[i, 2]);

                                topTenArray[y, 0] = scoreArray[i, 0];
                                topTenArray[y, 1] = scoreArray[i, 1];
                                topTenArray[y, 2] = scoreArray[i, 2];
                                topTenArray[y, 3] = scoreArray[i, 3];
                                topTenArray[y, 4] = scoreArray[i, 4];
                            }
                        }
                    }
                    for (int i = xScore.Count; i < 10; i++ )
                    {
                        topTenArray[i, 0] = "";
                        topTenArray[i, 1] = "";
                        topTenArray[i, 2] = "";
                        topTenArray[i, 3] = "";
                        topTenArray[i, 4] = "";
                    }
                }
              }
            }

            int onY = 0;
            int level;
            for (int i = 0; i < 10; i++)
            {
                onY -= 51;
                scrTXTRank.text = (i+1).ToString();
                scrTXTUser.text = topTenArray[i,1];
                try
                {
                    level = int.Parse(topTenArray[i, 3]);
                }
                catch
                {
                    //level = int.Parse(getLevel);
                    level = 0;
                    if(thisID != null)
                    {
                    GameObject stillHere = GameObject.Find("Score# " + thisID);
                    GameObject stillDelete = GameObject.Find(thisID);
                    if (stillHere != null & stillDelete != null)
                        {
                            stillDelete.SetActive(false);
                            stillHere.transform.GetChild(0).gameObject.SetActive(true);
                            stillHere.transform.GetChild(1).gameObject.SetActive(false);
                            stillHere.transform.GetChild(2).gameObject.SetActive(false);
                            stillHere.transform.GetChild(3).gameObject.SetActive(false);
                            stillHere.transform.GetChild(4).gameObject.SetActive(false);
                            TopScoreHightlight.boolMyColor = true;
                        }
                    }
                }
                //scrTXTLevel.text = topTenArray[i, 3];
                if (level != 0)
                {

                    if (level > levelSettings.maxLevel)
                    {
                        scrTXTLevel.text = levelSettings.maxLevel.ToString();
                    }
                    else
                        scrTXTLevel.text = topTenArray[i, 3];
                }
                else
                    scrTXTLevel.text = "";

                scrTXTDate.text = topTenArray[i,4];
                try
                {
                    scrTXTScore.text = (float.Parse(topTenArray[i, 2])).ToString("#,##0");
                }
                catch
                {
                    scrTXTScore.text = (topTenArray[i, 2]);
                }
                scrTXTID.text = topTenArray[i, 0];
                scrTXTID.name = "TXT" + scrTXTID.text;

                GameObject newScore = Instantiate(Score) as GameObject;
                newScore.transform.parent = pinScore.transform;
                newScore.name = "Score# " + scrTXTID.text;
                RectTransform transform = newScore.gameObject.GetComponent<RectTransform>();
                Vector2 position = transform.anchoredPosition;
                transform.anchoredPosition = new Vector2(0,onY);
                if (scrTXTUser.text == getUser)
                {
                    GameObject newDeleteBtn = Instantiate(deleteButton) as GameObject;
                    newDeleteBtn.name = scrTXTID.text;
                    newDeleteBtn.transform.parent = deletePanel.transform;
                    RectTransform transDelete = newDeleteBtn.gameObject.GetComponent<RectTransform>();
                    transDelete.anchoredPosition = new Vector2(5f, onY - 5f);
                }
            }
        }
    


    public void createNode()
    {
        nullData();
        if (assignUser.text == "UNINITIALIZED")
            assignUser.text = "GUEST";
        userName = (assignUser.text).ToUpper();

        if (xDoc != null)
        {
            XmlNodeList xList = xDoc.SelectNodes("Root/gamesave[@user='" + userName + "' and @lives!='0']");
            maxCount = xList.Count;
            //////////////////////////////////
            if (xList.Count > 0)
            {
                gameArray = new string[xList.Count, 9];
                for (int i = 0; i < maxCount; i++)
                {
                    if (xList[i].Attributes["user"].Value != null)
                    {
                        recordMatch = true;

                        if ((xList[i].Attributes["user"].Value).ToString() == userName.ToUpper())
                        {
                            //print(xList[i].Attributes["user"].Value);

                            //Build Dimensional Array with data.
                            gameArray[i, 0] = xList[i].Attributes["id"].Value;
                            gameArray[i, 1] = xList[i].Attributes["user"].Value;
                            gameArray[i, 2] = xList[i].Attributes["score"].Value;
                            gameArray[i, 3] = xList[i].Attributes["level"].Value;
                            gameArray[i, 4] = xList[i].Attributes["lives"].Value;
                            gameArray[i, 5] = xList[i].Attributes["diff"].Value;
                            gameArray[i, 6] = xList[i].Attributes["audio"].Value;
                            gameArray[i, 7] = xList[i].Attributes["date"].Value;
                            gameArray[i, 8] = xList[i].Attributes["time"].Value;
                        }
                    }
                }
                recordMatch = true;
                deactivateSettingsPanel();
                activateGamePanel();
                //print(xList.Count);
                //print(gameArray[8, 8]);
                int myY = 150;
                for (int x = 0; x < xList.Count; x++)
                {
                    txtUsername.text = gameArray[x, 1];
                    txtScore.text = gameArray[x, 2];
                    txtLevel.text = gameArray[x, 3];
                    txtLives.text = gameArray[x, 4];
                    if (gameArray[x, 5] == "0")
                        txtDifficulty.text = "Easy";
                    else if (gameArray[x, 5] == "1")
                        txtDifficulty.text = "Medium";
                    else if (gameArray[x, 5] == "2")
                        txtDifficulty.text = "Hard";
                    txtDate.text = gameArray[x, 7];

                    Button newUser = Instantiate(listButton) as Button;
                    newUser.transform.parent = listPanel.transform;
                    newUser.name = x.ToString();
                    newUser.tag = "ListButton";
                    
                    //RectTransform transform = newUser.gameObject.transform as RectTransform; //Both methods work. GetComponent(); is safer.
                    RectTransform transform = newUser.gameObject.GetComponent<RectTransform>();
                    Vector2 position = transform.anchoredPosition;
                    transform.anchoredPosition = new Vector2(0, myY);
                    myY -= 75;
                }
                txtGameSave.text = xList.Count + "/5 Game Saves";

                if (xList.Count < 5)
                    activateNewGame();
            }
            //////////////////////////////////
            else
            {
                recordMatch = false;
                preMode();
            }

        }

    }
   
    public void preMode()
    {
        recordMatch = false;
        deactivateSettingsPanel();
        deactivateGamePanel();
        activateDiffPanel();
    }

    public void oneMoreNode() ///Define userName before using method.
    {
            //Open up Difficulty slider getDiff value.
            XmlNode userNode = xDoc.CreateElement("gamesave");

            createID();
            XmlAttribute gamID = xDoc.CreateAttribute("id");
            gamID.Value = gameID.ToString();
            userNode.Attributes.Append(gamID);
            getID = gamID.Value;

            XmlAttribute userAtt = xDoc.CreateAttribute("user");
            userAtt.Value = userName.ToUpper();
            userNode.Attributes.Append(userAtt);
            getUser = userAtt.Value;

            XmlAttribute gamScore = xDoc.CreateAttribute("score");
            gamScore.Value = "0";
            userNode.Attributes.Append(gamScore);
            getScore = gamScore.Value;

            XmlAttribute gamLevel = xDoc.CreateAttribute("level");
            gamLevel.Value = "1";
            userNode.Attributes.Append(gamLevel);
            getLevel = gamLevel.Value;

            XmlAttribute gamLives = xDoc.CreateAttribute("lives");
            if (getDiff == "0")
                gamLives.Value = "4";
            else if (getDiff == "1")
                gamLives.Value = "3";
            else if (getDiff == "2")
                gamLives.Value = "2";///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            userNode.Attributes.Append(gamLives);
            getLives = gamLives.Value;

            XmlAttribute gamDiff = xDoc.CreateAttribute("diff");
            gamDiff.Value = getDiff.ToString();
            userNode.Attributes.Append(gamDiff);

            XmlAttribute gamMute = xDoc.CreateAttribute("audio");
            gamMute.Value = audioManager.getAudio;
            userNode.Attributes.Append(gamMute);

            XmlAttribute gamDat = xDoc.CreateAttribute("date");
            gamDat.Value = currentDate;
            userNode.Attributes.Append(gamDat);
            getDate = gamDat.Value;

            XmlAttribute gamTime = xDoc.CreateAttribute("time");
            gamTime.Value = currentTime;
            userNode.Attributes.Append(gamTime);
            getTime = gamTime.Value;

            XmlElement Root = xDoc.DocumentElement;
            Root.AppendChild(userNode);
            saveXML(xDoc);
    }

    public void addNewGame()
    {
        userName = assignUser.text.ToUpper();
        recordMatch = false;
    }

    public void GoButton()
    {
        addNewGame();
        setDiff();
        oneMoreNode();
        loadALevel();
    }

    public void setDiff()
    {
        VHealth.cameFromBegin = true;
        getDiff = difficultySetting.value.ToString();

        if (getDiff == "0")
            getLives = "4";
        else if (getDiff == "1")
            getLives = "3";
        else if (getDiff == "2")
            getLives = "2";///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }

    public void loadALevel()
    {
        SceneManager.LoadScene("Level");////////////////////////////////////////////////////////////////////////Load Level///////////////////////////////////////////////////////////
        
        VHealth.setTheLevel();
    }

    public static void addToXML()
    {
        XmlNode theNode = xDoc.SelectSingleNode("Root/gamesave[@id='" + gameID.ToString() + "']");
        theNode.Attributes["score"].Value = VHealth.baseScore.ToString();
        theNode.Attributes["level"].Value = VHealth.level.ToString();
        theNode.Attributes["lives"].Value = VHealth.lives.ToString();
        theNode.Attributes["audio"].Value = audioManager.getAudio;
        dateTime();
        theNode.Attributes["date"].Value = currentDate;
        theNode.Attributes["time"].Value = currentTime;
        saveXML(xDoc);

    }

    public static void removeFromXML()
    {


        XmlNode removeNode = xDoc.SelectSingleNode(("Root/gamesave[@id='" + thisID + "']"));

        if(removeNode != null)
        {
            removeNode.ParentNode.RemoveChild(removeNode);
            saveXML(xDoc);
            GameObject[] scoreElements = GameObject.FindGameObjectsWithTag("ScoreBoard");
            //print("Game Elements: " + scoreElements.Length);
            for (int i = 0; i < scoreElements.Length; i+=1 )
            {
                scoreElements[i].SetActive(false);
                scoreElements[i].tag = "ScoreBoardOff";
            }
            fromGame = true;
        }
    }
    public void turnOnDelete()
    {        
        rotate += 1;
        if(rotate % 2 == 0)
            deletePanel.SetActive(true);
        else
            deletePanel.SetActive(false);
    }

    public void nullData()
    {
        //assignUser.text = assignUser.text.Replace(" ", "");
        //assignUser.text = assignUser.text.Replace("\'", "");

        if (assignUser.text == null | assignUser.text == "" | assignUser.text == " " | assignUser.text == "  " | assignUser.text == "   " | assignUser.text == "    " | assignUser.text == "     ")
        {
            XmlNode getKey = xDoc.SelectSingleNode("Root/idkey");
            if (Social.localUser.userName == null)
                assignUser.text = "GUEST";
            else
                assignUser.text = Social.localUser.userName.ToUpper();
        }
        else
            assignUser.text = assignUser.text.ToUpper();
    }

    public void activateNewGame()
    {
        newGame.SetActive(true);
        newGame.transform.SetSiblingIndex(4);
        
    }
    public void deactivateNewGame()
    {
        newGame.SetActive(false);
    }
    public void activateSettingsPanel()
    {
        userPanel.SetActive(true);
        userPanel.transform.SetSiblingIndex(4);

    }
    public void deactivateSettingsPanel()
    {
        userPanel.SetActive(false);
        userPanel.transform.SetSiblingIndex(0);
    }
    public void activateDiffPanel()
    {
        setTheDiff.SetActive(true);
        setTheDiff.transform.SetSiblingIndex(4);

    }
    public void deactivateDiffPanel()
    {
        setTheDiff.SetActive(false);
    }
    public void activateGamePanel()
    {
        setTheGame.SetActive(true);
        setTheGame.transform.SetSiblingIndex(4);
    }
    public void deactivateGamePanel()
    {
        setTheGame.SetActive(false);
    }
    public void activateScoreBoard()
    {
        displayScoreBoard.SetActive(true);
        displayScoreBoard.transform.SetSiblingIndex(4);
    }
    public void deactivateScoreBoard()
    {
        displayScoreBoard.SetActive(false);
    }
    public void activateHowToPanel()
    {
        if(setTheDiff.activeInHierarchy)
        {
            openFromDiff = true;
        }
        howToPanel.SetActive(true);
        howToPanel.transform.SetSiblingIndex(4);
    }
    public void deactivateHowToPanel()
    {
        howToPanel.SetActive(false);
        if (openFromDiff == true)
            activateDiffPanel();
        else
            activateSettingsPanel();
    }

    public void exitOut()
    {
        Application.Quit();
    }

}


