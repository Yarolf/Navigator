using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Route
{
    [HideInInspector]
    public string startName;
    [HideInInspector]
    public string finishName;
    [HideInInspector]
    public string extraInfo;

    public List<Vector3> points = new List<Vector3>();

    public Route(string nameStart = "", string nameFinish = "", string extraInfo = "")
    {
        this.startName = nameStart;
        this.finishName = nameFinish;
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
        if (x.startName == y.startName && x.finishName == y.finishName && x.extraInfo == y.extraInfo)
            return true;
        return false;
    }

    public int GetHashCode(Route obj)
    {
        return obj.GetHashCode();
    }
}
