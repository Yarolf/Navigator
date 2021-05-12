using System;
using System.Collections.Generic;

[Serializable]
public class Data
{
    public List<Route> routes = new List<Route>();

    public void AddRoute(Route route)
    {
        //проверка, был ли уже этот путь
        routes.Add(route);
    }
}
