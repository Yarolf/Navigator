using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Route
{
    public Route(string nameStart = "", string nameFinish = "", string extraInfo = "")
    {
        this.nameStart = nameStart;
        this.nameFinish = nameFinish;
        this.extraInfo = extraInfo;
    }

    public Route(Vector3 startPoint, string nameStart = "", string nameFinish = "", string extraInfo = "")
        : this(nameStart, nameFinish, extraInfo)
    {
        points.Add(startPoint);
    }

    public string nameStart;
    public string nameFinish;
    public string extraInfo;

    public List<Vector3> points = new List<Vector3>();
}
