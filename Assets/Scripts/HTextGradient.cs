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
using System.Collections.Generic;
[AddComponentMenu("UI/Effects/Horizontal Gradient Effect")]


public partial class HTextGradient : BaseMeshEffect
{

    [SerializeField]
    private Color32 topColor = Color.white;
    [SerializeField]
    private Color32 bottomColor = Color.black;

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!this.IsActive())
            return;

        List<UIVertex> vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);

        ModifyVertices(vertexList);

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertexList);
    }


    public void ModifyVertices(List<UIVertex> vertexList)
    {
        if (!IsActive())
        {
            return;
        }

        int count = vertexList.Count;
        float bottomX = vertexList[0].position.x;
        float topX = vertexList[0].position.x;

        for (int i = 1; i < count; i++)
        {
            float x = vertexList[i].position.x;
            if (x > topX)
            {
                topX = x;
            }
            else if (x < bottomX)
            {
                bottomX = x;
            }
        }

        float uiElementHeight = topX - bottomX;

        for (int i = 0; i < count; i++)
        {
            UIVertex uiVertex = vertexList[i];
            uiVertex.color = Color32.Lerp(bottomColor, topColor, (uiVertex.position.x - bottomX) / uiElementHeight);
            vertexList[i] = uiVertex;
        }
    }

}
