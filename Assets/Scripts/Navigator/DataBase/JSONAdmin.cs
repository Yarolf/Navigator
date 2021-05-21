using UnityEngine;
using System.IO;

public class JSONAdmin : JSON
{
    [Header("Скрипты")]
    public RouteTracker routeTracker;

    # region PUBLIC_METHODS

    public void SaveData()
    {
        if (WriteData())
        {
            File.WriteAllText(path, JsonUtility.ToJson(data));
            Notification.SetText("Данные сохранены!");
        }
    }

    #endregion

    #region PRIVATE_METHODS

    private bool WriteData()
    {
        if (data.AddRoute(routeTracker.Route))
        {
            Notification.SetText("Путь добавлен!");
            return true;
        }
        else
        {
            Notification.SetText("Путь существует!");
            return false;
        }
    }

    #endregion
}
