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

public class ScaleList : MonoBehaviour {

    public GameObject itemPrefab;
    public int itemCount = 5, columnCount = 1;

	void Start () 
    {
	    RectTransform rowRectTransform = itemPrefab.GetComponent<RectTransform>();
        RectTransform containerRectTransform = gameObject.GetComponent<RectTransform>();

        //Calculate the width and height of each child item.
        float width = containerRectTransform.rect.width / columnCount;
        float ratio = width / rowRectTransform.rect.width;
        float height = rowRectTransform.rect.height * ratio;
        int rowCount = itemCount / columnCount;
        if (itemCount % rowCount > 0)
            rowCount++;

        //Adjust the height of the container so that it will fit all its children.
        float scrollHeight = height * rowCount;
        containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight / 2);
        containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight / 2);

        //Loop for number of items
        int j = 0;
        for (int i = 0; i < itemCount; i++)
        {
            //Use this for loop because itemCount may not fit perfectly
            if (i % columnCount == 0)
                j++;

            //Create a new item, name it, and set the parent;
            GameObject newItem = Instantiate(itemPrefab) as GameObject;
            newItem.name = gameObject.name + "(X:" + i + ", Y:" + j + ")";
            newItem.transform.parent = gameObject.transform;

            //Move and size the new item
            RectTransform rectTransform = newItem.GetComponent<RectTransform>();

            float x = -containerRectTransform.rect.width / 2 + width * (i % columnCount);
            float y = containerRectTransform.rect.height / 2 - height * j;
            rectTransform.offsetMin = new Vector2(x, y);

            x = rectTransform.offsetMin.x + width;
            y = rectTransform.offsetMin.y + height;
            rectTransform.offsetMax = new Vector2(x, y);
        }
	}
	

	void Update () {
	
	}
}
