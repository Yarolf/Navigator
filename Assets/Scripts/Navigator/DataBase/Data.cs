using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Data
{
    public List<Route> routes = new List<Route>();

    RouteComparer routeComparer = new RouteComparer();

    /// <summary>
    /// Добавляет новый путь, если путь с таким же описанием ещё не содержится в списке
    /// </summary>
    /// <returns>true, если путь был добавлен </returns>
    public bool AddRoute(Route route)
    {
        if (routes.Contains(route, routeComparer))
            return false;

        routes.Add(route);
        return true;
    }

    public List<Route> FindRoutes(string startName, string finishName)
    {
        List<Route> routeList = new List<Route>();

        foreach (var route in routes)
        {
            if (route.startName == startName
                && route.finishName == finishName)
                routeList.Add(route);
        }
        return routeList;
    }

    public Route FindRoute(string startName, string finishName, string extraInfo)
    {
        foreach (var route in routes)
        {
            if (route.startName == startName && 
                route.finishName == finishName && 
                route.extraInfo == extraInfo)
                return route;
        }
        return null;
    }
}
