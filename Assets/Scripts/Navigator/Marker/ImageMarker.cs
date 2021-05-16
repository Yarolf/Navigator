using UnityEngine;
using Vuforia;
public class ImageMarker : MonoBehaviour
{
    [Header("Имя для выпадающего меню")]
    [SerializeField]
    private string translitedName;
    private string originalName;

    public string OriginalName { get { return originalName; } }
    public string TranslitedName { get { return translitedName; } }

    private void Awake()
    {
        originalName = gameObject.GetComponent<ImageTargetBehaviour>().TrackableName;
    }
}
