using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class JSON : MonoBehaviour
{
    [Header("Вывод уведомлений")]
    public Text Notification;

    [HideInInspector]
    public Data data = new Data();

    private string fileName = "RoutesData.json";
    protected string path;

    private void Awake()
    {

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, fileName);
#else
        path = Path.Combine(Application.dataPath, fileName);
#endif
    }

    public Data ReadData()
    {
        if (File.Exists(path))
        {
            Data data = JsonUtility.FromJson<Data>(File.ReadAllText(path));
            //Notification.text = ("Загружено " + data.routes.Count + "путей"); // Убрать!
            return data;
        }
        Notification.text = ("Файл не найден!"); //Убрать
        return null;
    }
}
