using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Route
{
    [HideInInspector]
    public string nameStart;
    [HideInInspector]
    public string nameFinish;
    [HideInInspector]
    public string extraInfo;

    public List<Vector3> points = new List<Vector3>();

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
}

class RouteComparer : IEqualityComparer<Route>
{
    public bool Equals(Route x, Route y)
    {
        if (x.nameStart == y.nameStart && x.nameFinish == y.nameFinish && x.extraInfo == y.extraInfo)
            return true;
        return false;
    }

    public int GetHashCode(Route obj)
    {
        return obj.GetHashCode();
    }
}
