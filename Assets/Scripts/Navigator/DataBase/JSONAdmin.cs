using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class JSONAdmin : JSON
{
    public RouteTracker routeTracker;
    public void WriteData()
    {
        // Для проверки!!! УДАЛИТЬ
        data.routes.Clear();


        data.AddRoute(routeTracker.GetRoute());
        Notification.text = ("Путь добавлен!");
    }

    public void SaveData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(data));
        Notification.text = ("Данные сохранены!");
    }
}
