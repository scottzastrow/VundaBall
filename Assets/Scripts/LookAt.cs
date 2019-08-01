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

public class LookAt : MonoBehaviour {

	public Transform myTransform;
	public Transform myTarget;
	private float xTop = .75f;
	private float yAxis = -.1f;
	private float zAxis = 0f;
	private float rotationSpeed = .1f;
	Vector3 zoomResult;

	void Start()
	{
		zoomResult = new Vector3(xTop, yAxis, -zAxis);
	}

	void Update ()
	{
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(myTarget.position - myTransform.position), rotationSpeed*Time.deltaTime*100f);
		myTransform.position = Vector3.Lerp(myTransform.position, myTarget.position + zoomResult, rotationSpeed*Time.deltaTime*100f);
	}
}