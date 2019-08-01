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
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{

    public GameObject settingsPanel;
    public GameObject quickSettingPanel;
    public GameObject theSettingsButton;
    public GameObject theDiffSettings;
    public GameObject howToPanel;
    public GameObject IAPPanel;
    public GameObject disablePanel;
    public Slider theAudio;
    public Text diffLevel;
    public Button playPause;
    public Button audioMute;
    public Sprite playSprite;
    public Sprite pauseSprite;
    public Sprite audioOnSprite;
    public Sprite audioOffSprite;
    public Toggle defaultToggle;
    public Toggle secondToggle;
    private int thecount;

    //private bool noMoreLives;

    private void Start()
    {
        thecount = 0;
        //noMoreLives = false;
        defaultToggle.isOn = true;
        secondToggle.isOn = false;
        Time.timeScale = 1;
        IAPPanel.transform.SetAsFirstSibling();
        IAPPanel.SetActive(false);
        settingsPanel.SetActive(false);
        quickSettingPanel.SetActive(true);
        howToPanel.SetActive(false);
        howToPanel.transform.SetSiblingIndex(0);
        settingsPanel.transform.SetSiblingIndex(1);
        disablePanel.transform.SetAsFirstSibling();

        if (audioManager.getAudio != null)
        {
            theAudio.value = float.Parse(audioManager.getAudio);
            AudioListener.volume = theAudio.value;
        }
        else
        {
            theAudio.value = 1;
            AudioListener.volume = 1;
        }

        if (fileManager.getDiff == "0")
            diffLevel.text = "Easy";
        else if (fileManager.getDiff == "1")
            diffLevel.text = "Medium";
        else if (fileManager.getDiff == "2")
            diffLevel.text = "Hard";
    }

    public void Update()
    {


        if (VHealth.lives == 1 & PlayerPrefs.GetString("IAP") == "YesIAP" & thecount < 1)
        {
            thecount = 0;
            OpenIAP();
        }

        if (Time.timeScale == 1.0f)
        {

            playPause.image.sprite = playSprite;
        }
        else if (Time.timeScale == 0f)
        {

            playPause.image.sprite = pauseSprite;
        }
        if (theAudio.value == 0f)
        {
            audioMute.image.sprite = audioOffSprite;
            theAudio.value = 0f;
        }
        else if (theAudio.value != 0f)
        {
            audioMute.image.sprite = audioOnSprite;
        }
    }
    
    public void setAudio()
    {
        AudioListener.volume = theAudio.value;

        audioManager.getAudio = (theAudio.value).ToString();
        fileManager.addToXML();
    }

    public void toggleAudioOnOff()
    {
        if (theAudio.value == 0f)
        {
            audioMute.image.sprite = audioOnSprite;
            theAudio.value = 1f; 
        }
        else if (theAudio.value != 0f)
        {
            audioMute.image.sprite = audioOffSprite;
            theAudio.value = 0f;
        }    
    }

    public void togglePausePlay()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0f;
            playPause.image.sprite = pauseSprite;
        }
        else if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            playPause.image.sprite = playSprite;
        }
    }
    
    public void exitOut()
    {
        Application.Quit();
    }

    public void openMenu()
    {
        settingsPanel.SetActive(true);
        settingsPanel.transform.SetSiblingIndex(13);
        quickSettingPanel.transform.SetSiblingIndex(12);

        Time.timeScale = 0;
    }

    public void closeMenu()
    {
        settingsPanel.SetActive(false);
        quickSettingPanel.transform.SetSiblingIndex(13);
        settingsPanel.transform.SetSiblingIndex(12);

        Time.timeScale = 1;
    }
    public void openHowTo()
    {
        howToPanel.SetActive(true);
        howToPanel.transform.SetSiblingIndex(15);
        settingsPanel.transform.SetSiblingIndex(13);
    }
    public void closeHowTo()
    {
        howToPanel.SetActive(false);
        settingsPanel.SetActive(true);
        IAPPanel.transform.SetAsFirstSibling();
    }

    public void LoadGame()
    {
        fileManager.fromGame = false;
        SceneManager.LoadScene("Begin");
    }

    public void OpenIAP()
    {
        Time.timeScale = 0;
        disablePanel.transform.SetAsFirstSibling();
        IAPPanel.transform.SetAsLastSibling();
        IAPPanel.SetActive(true);
    }

    public void CloseIAP()
    {
        disablePanel.transform.SetAsLastSibling();
        IAPPanel.transform.SetAsFirstSibling();
        IAPPanel.SetActive(false);
        //noMoreLives = false;
    }

    public void ExitIAP()
    {
        disablePanel.transform.SetAsFirstSibling();
        IAPPanel.transform.SetAsFirstSibling();
        IAPPanel.SetActive(false);
        //noMoreLives = true;
        if (settingsPanel.activeInHierarchy)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

}
