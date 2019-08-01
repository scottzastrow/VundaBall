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

public class audioManager : MonoBehaviour {

    public Sprite audioOn;
    public Sprite audioOff;
    public Button audioButton;
    public static string getAudio;
    public AudioSource opener;
    public AudioSource soundTrack;

    void Awake()
    { 
    soundTrack.GetComponent<AudioSource>();
    opener.GetComponent<AudioSource>();
    }

    public void Start()
    {

        getAudio = AudioListener.volume.ToString();
        if (getAudio == null)
        {
            AudioListener.volume = 1;
            audioButton.image.sprite = audioOn;
        }
        else if (float.Parse(getAudio) == 0)
        {
            AudioListener.volume = 0;
            audioButton.image.sprite = audioOff;
        }
        else
        {
            AudioListener.volume = float.Parse(getAudio);
            audioButton.image.sprite = audioOn;
        }
        //print("GetAudio: " + getAudio + " AudioListener: " + AudioListener.volume);
    }

    public void toggleAudio()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            audioManager.getAudio = "1";
            audioButton.image.sprite = audioOn;
        }
        else if (AudioListener.volume != 0)
        {
            AudioListener.volume = 0;
            audioManager.getAudio = "0";
            audioButton.image.sprite = audioOff;
        }
    }

   
}
