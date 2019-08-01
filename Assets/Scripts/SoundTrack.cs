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

public class SoundTrack : MonoBehaviour {

    public AudioSource opener;
    public AudioSource soundTrack;

    void Start()
    {
        opener.Play();
        soundTrack.loop = false;
        soundTrack.mute = true;
        soundTrack.Play();
        StartCoroutine(delayMusic());
    }

    IEnumerator delayMusic()
    {
        yield return new WaitForSeconds(2.5f);
        soundTrack.loop = true;
        soundTrack.mute = false;
        soundTrack.Play();
    }
}
