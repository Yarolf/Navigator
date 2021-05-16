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
}
