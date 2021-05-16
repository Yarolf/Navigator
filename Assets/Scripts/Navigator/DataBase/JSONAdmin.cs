using UnityEngine;
using System.IO;

public class JSONAdmin : JSON
{
    [Header("Скрипты")]
    public RouteTracker routeTracker;

    # region PUBLIC_METHODS

    public void SaveData()
    {
        WriteData();
        File.WriteAllText(path, JsonUtility.ToJson(data));
        Notification.text = ("Данные сохранены!");
    }

    #endregion

    #region PRIVATE_METHODS

    private void WriteData()
    {
        data.AddRoute(routeTracker.Route);
        Notification.text = ("Путь добавлен!");
    }

    #endregion
}
