using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class JSONUser : JSON
{
    private void Start()
    {
        data = ReadData();
    }

    public Data ReadData()
    {
        if (File.Exists(path))
        {
            Data data = JsonUtility.FromJson<Data>(File.ReadAllText(path));
            Indicator.SetRoute(data.routes[0]); // убрать, т.к. путь должен будет выбираться сам в классе индикатор
            Notification.text = ("Загружено " + data.routes.Count + "путей");
            return data;
        }
        Notification.text = ("Файл не найден!");
        return null;
    }


    //private void Update()
    //{
    //    Notification.text = ARCamera.arCamera.transform.rotation.ToString();
    //}
}

