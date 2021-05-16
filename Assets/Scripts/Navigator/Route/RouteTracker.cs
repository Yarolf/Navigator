using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RouteTracker : MonoBehaviour
{
    [Header("Скрипты")]
    [SerializeField]
    private ARSceneAdmin arSceneAdmin;
    [SerializeField]
    private SaveDataButton saveDataButton;

    [Header("Вывод уведомлений")]
    [SerializeField]
    private Text _notification;
    


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
        _notification.text = "Отслеживание начато";
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
        _notification.text = "Отсканируйте маркер";
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
        string placeName = marker.OriginalName;

        if (!isTracking) // первое сканирование - начальный пункт
        {
            startLocation = placeName;
        }
        else if (placeName != _route.nameStart) // второе сканирование - конечный пункт
        {
            FillRouteFinishName(placeName);
            StopTracking();
        }
    }

    private void FillRouteStartName(string name)
    {
        _route.nameStart = name;
        //Notification.text = "Start: " + name; --Перенести в отдельное поле
    }

    private void FillRouteFinishName(string name)
    {
        _route.nameFinish = name;
        // Notification.text = "Finish: " + name; --Перенести в отдельное поле
    }

    private void FillRouteExtraInfo(string name)
    {
        _route.extraInfo = name;
        // Notification.text = "ExtraInfo: " + name; --Перенести в отдельное поле
    }

    private void StopTracking()
    {
        WritePoint(ARCamera.GetPositionAfterScaning());
        EventsHolder.MarkerChanged -= OnImageScanned;
        isTracking = false;
        saveDataButton.TurnOn();
        _notification.text = "Отслеживание завершено";
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
        _notification.text = ("Добавлена точка: " + point);
    }

    #endregion
}
