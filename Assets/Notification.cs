using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    static Text textField;
    
    void Awake()
    {
        textField = gameObject.GetComponent<Text>();
    }

    public static void SetText(string text)
    {
        textField.text = text;
    }
}
