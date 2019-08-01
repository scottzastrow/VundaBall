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

public class WallColor : MonoBehaviour {

    private Color green = new Color(.5f, .65f, .5f, 1f);
    private Color red = new Color(.85f, .39f, .39f);
    private Color purple = new Color(.77f, .56f, .9f);
    private Color blue = new Color(.62f, .64f, 1f);
    private Color orange = new Color(.9f, .56f, .56f);
    private Color pink = new Color(.9f, .56f, .81f); //For 10 20 30 40 50

	void Start () 
    {
        if (VHealth.level == 10 | VHealth.level == 20 | VHealth.level == 30 | VHealth.level == 40 | VHealth.level == 50 | VHealth.level == 60 | VHealth.level == 70 | VHealth.level == 80 | VHealth.level == 90 | VHealth.level == 100)
        {
            gameObject.GetComponent<Renderer>().material.color = pink;
        }
        else if (VHealth.level == 1 | VHealth.level == 6 | VHealth.level == 11 | VHealth.level == 16 | VHealth.level == 21 | VHealth.level == 26 | VHealth.level == 31 | VHealth.level == 36 | VHealth.level == 41 | VHealth.level == 46 | VHealth.level == 51 | VHealth.level == 56 | VHealth.level == 61 | VHealth.level == 66 | VHealth.level == 71 | VHealth.level == 76 | VHealth.level == 81 | VHealth.level == 86 | VHealth.level == 91 | VHealth.level == 96)
        {
            gameObject.GetComponent<Renderer>().material.color = green;
        }
        else if (VHealth.level == 2 | VHealth.level == 7 | VHealth.level == 12 | VHealth.level == 17 | VHealth.level == 22 | VHealth.level == 27 | VHealth.level == 32 | VHealth.level == 37 | VHealth.level == 42 | VHealth.level == 47 | VHealth.level == 52 | VHealth.level == 57 | VHealth.level == 62 | VHealth.level == 67 | VHealth.level == 72 | VHealth.level == 77 | VHealth.level == 82 | VHealth.level == 87 | VHealth.level == 92 | VHealth.level == 97)
        {
            gameObject.GetComponent<Renderer>().material.color = purple;
        }
        else if (VHealth.level == 3 | VHealth.level == 8 | VHealth.level == 13 | VHealth.level == 18 | VHealth.level == 23 | VHealth.level == 28 | VHealth.level == 33 | VHealth.level == 38 | VHealth.level == 43 | VHealth.level == 48 | VHealth.level == 53 | VHealth.level == 58 | VHealth.level == 63 | VHealth.level == 68 | VHealth.level == 73 | VHealth.level == 78 | VHealth.level == 83 | VHealth.level == 88 | VHealth.level == 93 | VHealth.level == 98)
        {
            gameObject.GetComponent<Renderer>().material.color = orange;
        }
        else if (VHealth.level == 4 | VHealth.level == 9 | VHealth.level == 14 | VHealth.level == 19 | VHealth.level == 24 | VHealth.level == 29 | VHealth.level == 34 | VHealth.level == 39 | VHealth.level == 44 | VHealth.level == 49 | VHealth.level == 54 | VHealth.level == 59 | VHealth.level == 64 | VHealth.level == 69 | VHealth.level == 74 | VHealth.level == 79 | VHealth.level == 84 | VHealth.level == 89 | VHealth.level == 94 | VHealth.level == 99)
        {
            gameObject.GetComponent<Renderer>().material.color = blue;
        }
        else if (VHealth.level == 5 | VHealth.level == 15 | VHealth.level == 25 | VHealth.level == 35 | VHealth.level == 45 | VHealth.level == 55 | VHealth.level == 65 | VHealth.level == 75 | VHealth.level == 85 | VHealth.level == 95)
        {
            gameObject.GetComponent<Renderer>().material.color = red;
        }

	}
	

}
