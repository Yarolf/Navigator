using UnityEngine;

public class ARCamera : MonoBehaviour
{
    public static Camera camera;

    private static float angleAfterScaning;
    private static Vector3 positionAfterScaning;

    public static float GetDistanseFrom(Vector3 target)
    {
        return Vector3.Distance(GetPositionAfterScaning(), target);
    }

    public static Vector3 GetPositionAfterScaning()
    {
        return CoordinatesRelativeToRotation - positionAfterScaning;
    }

    private void Awake()
    {
        camera = gameObject.GetComponent<Camera>();
    }

    private void Start()
    {
        TrackableEventHandler.OnTrackingFoundWithName += Prepare;
    }

    private void Prepare(string name)
    {
        SetAngleAfterScaning();
        SetPositionAfterScaning();
    }

    /// <summary>
    /// Нужен для рассчёта координат относительно поворота осей после сканирования
    /// </summary>
    private static void SetAngleAfterScaning()
    {
        float eulerAngle = camera.transform.eulerAngles.y;
        angleAfterScaning = eulerAngle.ToRadians();
    }

    private static Vector3 CoordinatesRelativeToRotation
    {
        // афинное преобразование для получения координат в соответствии с поворотом осей
        get
        {
            Vector3 position = camera.transform.position;
            float x = position.x * Mathf.Cos(angleAfterScaning) - position.z * Mathf.Sin(angleAfterScaning);
            float z = position.x * Mathf.Sin(angleAfterScaning) + position.z * Mathf.Cos(angleAfterScaning);
            position.x = x;
            position.z = z;
            return position;
        }
    }

    private static void SetPositionAfterScaning()
    {
        positionAfterScaning = CoordinatesRelativeToRotation;
    }
}

public static class FloatExtension
{
    public static float ToRadians(this float degree)
    {
        return Mathf.PI * degree / 180;
    }
}


