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

public class Tank : MonoBehaviour {

    public Transform VBall;

    private Quaternion theRotation;
    private Vector3 theDirection;
    private Vector3 localDirection;
    private float RotationSpeed = 20f;

    public GameObject tank;
    public GameObject tankBase;
    public GameObject tankMark;
    public GameObject tankPanel;
    public Transform tankBlow;
    public GameObject grenade;
    public GameObject map;
    public AudioSource explodingTank;

    void Update()
    {

        theDirection = (VBall.position - transform.position).normalized;
        theRotation = Quaternion.LookRotation(transform.position - VBall.position, theDirection);
        theRotation.y = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, theRotation, Time.deltaTime * RotationSpeed);

    }

    private void OnCollisionEnter(Collision Bump)
    {
        if (Bump.gameObject.name == "VBall")
        {
            float checkTemp = VHealth.coreTemp;
            VHealth.PrivaTank();
            if (VHealth.coreTemp < 100)
            {
                TankPoints.tankBoom = true;
                explodingTank.Play();
                tankPanel.SetActive(true);
                TankPoints scriptTankBlowPts;
                scriptTankBlowPts = tankPanel.GetComponent<TankPoints>();
                scriptTankBlowPts.enabled = true;
                Destroy(tank);
                Destroy(tankBase);
                Handheld.Vibrate();
                VHealth.tankBuster();
                Transform newTankBlow = Instantiate(tankBlow, new Vector3(tankMark.transform.position.x, tankMark.transform.position.y, tankMark.transform.position.z), Quaternion.identity) as Transform;
                for (int x = 0; x < 10; x++)
                {
                    GameObject newGrenade = Instantiate(grenade, new Vector3(tankMark.transform.position.x, tankMark.transform.position.y, tankMark.transform.position.z), Quaternion.identity) as GameObject;
                    Rigidbody rigidbody = newGrenade.gameObject.GetComponent<Rigidbody>();
                    rigidbody.AddExplosionForce(1f, this.transform.position, 1f, 1f);
                    rigidbody.velocity = this.transform.position * -1;
                }
                newTankBlow.transform.parent = map.transform;
                tankMark.GetComponent<ParticleSystem>();
                tankMark.GetComponent<ParticleSystem>().Play();

                StartCoroutine(fewSeconds());
            }

        }
    }

    IEnumerator fewSeconds()
    {
        yield return new WaitForSeconds(5f);
        tankMark.GetComponent<ParticleSystem>().Stop();
    }
}
