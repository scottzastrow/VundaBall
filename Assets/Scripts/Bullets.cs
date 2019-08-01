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

public class Bullets : MonoBehaviour {


    public Transform liveGrenade;
    public GameObject baseMap;
    public Transform mySpawnPoint;
    public GameObject vBall;
    
    void OnTriggerEnter(Collider fire) 
    {
        if (fire.gameObject.name == "VBall" && vBall.GetComponent<Rigidbody>().isKinematic == false)
        {
            Transform cloneGrenade;
            GetComponent<AudioSource>().Play();
            cloneGrenade = Instantiate(liveGrenade, mySpawnPoint.transform.position, mySpawnPoint.transform.rotation) as Transform;
            cloneGrenade.parent = baseMap.transform;
            cloneGrenade.GetComponent<Rigidbody>().velocity = transform.right * -5;
            StartCoroutine(waitFirst());

        }
    }

    IEnumerator waitFirst()
    {
        yield return new WaitForSeconds(1f);
    }
}
