using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RouteTracker : MonoBehaviour
{
    [Header("Скрипты")]
    [SerializeField]
    private ARSceneAdmin arSceneAdmin;
    [SerializeField]
    private SaveRouteSettingsPanel saveRouteSettings;
    


    public static float distanseToSavePoint = 1;

    private bool isTracking = false;
    private string startLocation;

    private Route _route;
    public Route Route {get { return _route; } }

    # region UNITY_MONOBEHAVIOUR_METHODS

    private void Update()
    {
        if (isTracking)
            Track();
    }

    private void Start()
    {
        ResetToDefault();
    }

    #endregion

    #region PUBLIC_METHODS

    /// <summary>
    /// Вызывается первым, для начала работы с построением пути
    /// </summary>
    public void StartTracking()
    {
        Prepare();
        isTracking = true;
        Notification.SetText("Отслеживание начато");
    }

    /// <summary>
    /// Обнуляет все изменения, кроме дистанции до записи очередной точки
    /// </summary>
    public void ResetToDefault()
    {
        isTracking = false;
        startLocation = null;
        _route = null;
        EventsHolder.TargetChanged += arSceneAdmin.Prepare;
        EventsHolder.MarkerChanged += OnImageScanned;
        Notification.SetText("Отсканируйте маркер");
    }

    #endregion

    #region PRIVATE_METHODS

    private void Prepare()
    {
        arSceneAdmin.Begin();
        EventsHolder.TargetChanged -= arSceneAdmin.Prepare;
        _route = new Route(Vector3.zero);
        FillRouteStartName(startLocation);
    }

    private void OnImageScanned(ImageMarker marker)
    {
        string placeName = marker.TranslitedName;

        if (!isTracking) // первое сканирование - начальный пункт
        {
            startLocation = placeName;
        }
        else if (placeName != _route.startName) // второе сканирование - конечный пункт
        {
            FillRouteFinishName(placeName);
            StopTracking();
        }
    }

    private void FillRouteStartName(string name)
    {
        _route.startName = name;
        //Notification.text = "Start: " + name; --Перенести в отдельное поле
    }

    private void FillRouteFinishName(string name)
    {
        _route.finishName = name;
        // Notification.text = "Finish: " + name; --Перенести в отдельное поле
    }

    public void FillRouteExtraInfo(string name)
    {
        _route.extraInfo = name;
        // Notification.text = "ExtraInfo: " + name; --Перенести в отдельное поле
    }

    private void StopTracking()
    {
        WritePoint(ARCamera.GetPositionAfterScaning());
        EventsHolder.MarkerChanged -= OnImageScanned;
        isTracking = false;
        Notification.SetText("Отслеживание завершено");
        ShowSaveSettings();
    }

    private void ShowSaveSettings()
    {
        saveRouteSettings.gameObject.SetActive(true);
        saveRouteSettings.startPoint.text = _route.startName;
        saveRouteSettings.endPoint.text = _route.finishName;
        gameObject.SetActive(false);
    }

    private void Track()
    {
        if (ARCamera.GetDistanseFrom(_route.points.Last()) > distanseToSavePoint)
        {
            WritePoint(ARCamera.GetPositionAfterScaning());
        }
    }

    private void WritePoint(Vector3 point)
    {
        _route.points.Add(point);
        Notification.SetText("Добавлена точка: " + point);
    }

    #endregion
}
