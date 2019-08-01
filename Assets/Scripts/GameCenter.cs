using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Runtime.InteropServices;

public class GameCenter : MonoBehaviour {

    [DllImport("__Internal")]
    public static extern void checkStatus();

    [DllImport("__Internal")]
    public static extern bool getStatus(bool theStatus);

    public Button gameCenterBtn;
    public bool theStatus;
    public GameObject landScapePanel;
    private Color color1 = new Color(0f, 0f, 0f, 0f);
    private Color color2 = new Color(0f, 0f, 0f, .9f);
    private Color color3 = new Color(0f, 0f, 0f, 0f);
    private int tankProgress;

    void Start()
    {
        StartCoroutine(getGCStatus());

        landScapePanel.SetActive(false);
        if (fileManager.fromGame == true)
        {
            tankProgress = (PlayerPrefs.GetInt("BustedTanks")) * 4;

            if (fileManager.getDiff == "0")
            {
                ReportTheScore(VHealth.baseScore, "VB0");
                if (PlayerPrefs.GetInt("BustedTanks") < 25)
                {
                    ReportAchievement("FAL4", tankProgress);
                }
                else
                    ReportAchievement("FAL4", 100);
            }
            else if (fileManager.getDiff == "1")
            {
                ReportTheScore(VHealth.baseScore, "VB1");
                if (PlayerPrefs.GetInt("BustedTanks") < 25)
                    ReportAchievement("FAL5", tankProgress);
                else
                    ReportAchievement("FAL5", 100);
            }
            else if (fileManager.getDiff == "2")
            {
                ReportTheScore(VHealth.baseScore, "VB2");
                if (PlayerPrefs.GetInt("BustedTanks") < 25)
                    ReportAchievement("FAL6", tankProgress);
                else
                    ReportAchievement("FAL6", 100);
            }

            if (VHealth.level > levelSettings.maxLevel)
            {
                if (fileManager.getDiff == "0")
                    ReportAchievement("FAL1", 100);

                else if (fileManager.getDiff == "1")
                    ReportAchievement("FAL2", 100);

                else if (fileManager.getDiff == "2")
                    ReportAchievement("FAL3", 100);
            }
            else if (VHealth.level < 25)
            {
                if (fileManager.getDiff == "0")
                    ReportAchievement("FAL1", VHealth.level * 4);

                else if (fileManager.getDiff == "1")
                    ReportAchievement("FAL2", VHealth.level * 4);

                else if (fileManager.getDiff == "2")
                    ReportAchievement("FAL3", VHealth.level * 4);
            }
            else if (VHealth.level == 25)
            {
                if (PlayerPrefs.GetString("Level") == "Complete")
                {
                    if (fileManager.getDiff == "0")
                        ReportAchievement("FAL1", VHealth.level * 4);

                    else if (fileManager.getDiff == "1")
                        ReportAchievement("FAL2", VHealth.level * 4);

                    else if (fileManager.getDiff == "2")
                        ReportAchievement("FAL3", VHealth.level * 4);
                }
                else if (PlayerPrefs.GetString("Level") == "Incomplete")
                {
                    if (fileManager.getDiff == "0")
                        ReportAchievement("FAL1", 99);

                    else if (fileManager.getDiff == "1")
                        ReportAchievement("FAL2", 99);

                    else if (fileManager.getDiff == "2")
                        ReportAchievement("FAL3", 99);
                }
            }
        }
    }

    IEnumerator getGCStatus()
    {
        checkStatus();
        yield return new WaitForSeconds(5f);
        theStatus = getStatus(theStatus);

        if(theStatus == true)
            Social.localUser.Authenticate(ProcessAuthentication);
    }

    // This function gets called when Authenticate completes
    // Note that if the operation is successful, Social.localUser will contain data from the server. 
    void ProcessAuthentication(bool success)
    {
		if (success)
        {
            gameCenterBtn.gameObject.SetActive(true);
            Debug.Log("Authenticated, checking achievements");

            // Request loaded achievements, and register a callback for processing them
            Social.LoadAchievements(ProcessLoadedAchievements);
        }
        else
        {
            gameCenterBtn.gameObject.SetActive(false);
            Debug.Log("Failed to authenticate");
        }
    }

    // This function gets called when the LoadAchievement call completes
    void ProcessLoadedAchievements(IAchievement[] achievements)
    {
        if (achievements.Length == 0)
            Debug.Log("Error: no achievements found");
        else
            Debug.Log("Got " + achievements.Length + " achievements");

        // You can also call into the functions like this
        Social.ReportProgress("Achievement01", 100.0, result => {
            if (result)
                Debug.Log("Successfully reported achievement progress");
            else
                Debug.Log("Failed to report achievement");
        });
    }

    public void LeaderBoard()
    {
        //if (theStatus == true & Input.deviceOrientation == DeviceOrientation.LandscapeLeft | Input.deviceOrientation == DeviceOrientation.LandscapeRight)
            Social.ShowLeaderboardUI();
        //else
            //StartCoroutine(landscapeWarning());  
    }

    IEnumerator landscapeWarning()
    {
        landScapePanel.SetActive(true);
        landScapePanel.transform.SetAsLastSibling();
        yield return new WaitForSeconds(4f);
        landScapePanel.transform.SetAsFirstSibling();
        landScapePanel.SetActive(false);
    }

    void ReportTheScore(long score, string leaderboardID)
    {
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success => {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }

    void ReportAchievement(string AchievID, int Percent)
    {
        Social.ReportProgress(AchievID, Percent, success => {
            Debug.Log(success ? "Reported Achievement successfully" : "Failed to report Achievement");
        });
    }

}
