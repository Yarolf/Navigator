using UnityEngine;
using Vuforia;
public class ImageMarker : MonoBehaviour
{
    private string originalName;
    [SerializeField]
    private string translitedName;

    public string OriginalName
    {
        get
        {
            return originalName;
        }
    }

    public string TranslitedName 
    {
        get
        {
            return translitedName;
        }
    }

    public GameObject GetObject()
    {
        return gameObject;
    }

    private void Awake()
    {
        originalName = gameObject.GetComponent<ImageTargetBehaviour>().TrackableName;
    }

}
