using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class JSON : MonoBehaviour
{
    public Text Notification;
    public Data data = new Data();

    protected string path;

    string fileName = "RoutesData.json";

    private void Awake()
    {

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, name);
#else
        path = Path.Combine(Application.dataPath, fileName);
#endif
    }
}
