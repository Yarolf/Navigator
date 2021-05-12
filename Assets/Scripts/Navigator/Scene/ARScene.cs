using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ARScene : MonoBehaviour
{
    public static List<ImageMarker> markers = new List<ImageMarker>();

    private void Awake()
    {
        markers = FindObjectsOfType<ImageMarker>().ToList();
    }

    /// <summary>
    /// Подготавливка сцены для корректного перемещения
    /// После сканирования маркера
    /// </summary>
    public void Prepare(Transform target)
    {
        SetRotation(target);
        SetPosition(target);
        TrackableEventHandler.OnTrackingFoundWithObject -= Prepare;
    }

    private void SetRotation(Transform target)
    {
        //var newRot = new Vector3(0, target.eulerAngles.y + 180, 0);
        var newRot = new Vector3(0, target.eulerAngles.y, 0);
        gameObject.transform.eulerAngles = newRot;
    }

    private void SetPosition(Transform target)
    {
        gameObject.transform.position = ARCamera.camera.transform.position;
    }
}
