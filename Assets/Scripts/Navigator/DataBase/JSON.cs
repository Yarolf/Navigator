using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class JSON : MonoBehaviour
{
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

    private void Start()
    {
        data = ReadData();
    }

    public Data ReadData()
    {
        if (File.Exists(path))
        {
            Data data = JsonUtility.FromJson<Data>(File.ReadAllText(path));
            //Notification.text = ("Загружено " + data.routes.Count + "путей"); // Убрать!
            return data;
        }
        Notification.SetText("Файл не найден!"); //Убрать
        return new Data();
    }
}
