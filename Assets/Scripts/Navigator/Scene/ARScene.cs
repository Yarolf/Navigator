using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ARScene : MonoBehaviour
{
    [SerializeField]
    [Header("Вывод уведомления")]
    protected Text notification;

    public delegate void PreparationFinishedEventHandler();
    public static event PreparationFinishedEventHandler PreparationFinished;

    #region PRIVATE_MEMBER_VARIABLES

    private static List<ImageMarker> markers = new List<ImageMarker>();
    private static GameObject scene;

    #endregion

    #region PUBLIC_PROPERTIES 

    public static List<ImageMarker> Markers { get { return markers; } }
    public static GameObject Scene { get { return scene; } }

    #endregion

    #region UNITY_MONOBEHAVIOUR_METHODS

    private void Awake()
    {
        markers = FindObjectsOfType<ImageMarker>().ToList();
        scene = gameObject;
        EventsHolder.MarkerChanged += ShowImageName;
    }

    #endregion

    #region PUBLIC_METHODS

    /// <summary>
    /// Прикрепляет сцену к маркеру
    /// </summary>
    public void Prepare(GameObject marker)
    {
        MoveToCenterOf(marker.transform);
        PreparationFinished?.Invoke();
    }

    /// <summary>
    /// Помещает сцену в мировое пространство
    /// </summary>
    public void Begin()
    {
        gameObject.transform.parent = null;
    }

    /// <summary>
    /// Возвращает координаты относительно поворота осей сцены
    /// </summary>
    public static Vector3 GetCoordinatesRelativeToRotation(Vector3 position)
    {
        float eulerAngle = scene.transform.eulerAngles.y;
        float arSceneAngle = eulerAngle.ToRadians();

        // афинное преобразование для получения координат в соответствии с поворотом осей
        float x = position.x * Mathf.Cos(arSceneAngle) - position.z * Mathf.Sin(arSceneAngle);
        float z = position.x * Mathf.Sin(arSceneAngle) + position.z * Mathf.Cos(arSceneAngle);

        position.x = x;
        position.z = z;

        return position;
    }

    #endregion

    #region PRIVATE_METHODS

    private void MoveToCenterOf(Transform marker)
    {
        gameObject.transform.parent = marker;
        ResetLocalTransform();
    }

    private void ResetLocalTransform()
    {
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localEulerAngles = CorrectionAngle.WALL;
    }

    private void ShowImageName(ImageMarker marker)
    {
        notification.text = marker.TranslitedName;
    }

    private static class CorrectionAngle
    {
        public static Vector3 WALL { get { return new Vector3(90, 0, 0); } }
        public static Vector3 FLOOR { get { return new Vector3(0, 0, 0); } }
    }
    #endregion
}

public static class FloatExtension
{
    public static float ToRadians(this float degree)
    {
        return Mathf.PI * degree / 180;
    }
}


