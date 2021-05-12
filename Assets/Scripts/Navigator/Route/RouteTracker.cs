using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RouteTracker : MonoBehaviour
{
    public ARSceneAdmin arSceneAdmin;
    public Text Notification;
    public float distanseToSavePoint = 1;
    
    private bool isTracking = false;
    private Route route = new Route();

    private void Start()
    {
        TrackableEventHandler.OnTrackingFoundWithName += FillNames;
    }

    void Update()
    {
        if (isTracking)
            Track();
    }

    private void Track()
    {
        if (ARCamera.GetDistanseFrom(route.points.Last()) > distanseToSavePoint)
        {
            WritePoint(ARCamera.GetPositionAfterScaning());
        }
    }

    public Route GetRoute()
    {
  // создавать и возвращать новый объект
        return route;
    }

    private void WritePoint(Vector3 point)
    {
        route.points.Add(point);
        Notification.text = ("Добавлена точка: " + point);
    }

    private void FillNames(string name)
    {
        if (!isTracking) // сканирую начальный пункт
        {
            route = new Route(Vector3.zero);
            route.nameStart = name;
            Notification.text = "Start: " + name;
        }
        else // второе сканирование - конечный пункт
        {
            isTracking = false;
            route.nameFinish = name;
            Notification.text = "Finish: " + name;
            // отписаться от переноса осей сцены
        }

        //if (route.extraInfo == "") перенести в поле "Сохранить"
        //    route.extraInfo = Text;
    }

    public void StartTracking()
    {
        //arSceneAdmin.Prepare();
        isTracking = true;
        Notification.text = "Начал отслеживание";
    }
}
