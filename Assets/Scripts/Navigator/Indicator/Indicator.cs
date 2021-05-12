using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Indicator: MonoBehaviour
{
    [SerializeField]
    private Text notification;
    public static float moovingSpeed = 1;

    private static Route _route;
    private static GameObject _prephab;
    private static int _curentPositionIndex = 0;
    private static bool isMooving = false;

    private void Awake()
    {
        _prephab = gameObject;
        _prephab.SetActive(false);
    }

    public void Update()
    {
        var distanse = Vector3.Distance(ARCamera.camera.transform.position, _prephab.transform.position);
        if (distanse < 1 && !IsMoving && _route != null)
        {
            MoveNext();
        }
    }

    public static bool IsMoving
    {
        get { return isMooving; }
    }

    public static Route GetRoute()
    {
        return _route;
    }

    public void Place()
    {
        _prephab.SetActive(true);
        _curentPositionIndex = 0;
    }

    public static void SetRoute(Route route)
    {
        _route = route;
    }

    public void MoveNext()
    {
        if (_prephab != null && _route != null)
        {
            if (_route.points.Count >= _curentPositionIndex)
                notification.text = "Пройдено точек: " + _curentPositionIndex + " из " + (_route.points.Count);
            if (_route.points.Count > _curentPositionIndex)
                StartCoroutine(MoveNextCouratine());
        }
    }
    private static IEnumerator MoveNextCouratine()
    {
        isMooving = true;
        float i = 0;
        Vector3 start = _prephab.transform.localPosition;

        while (i < 1)
        {
            i += moovingSpeed * Time.deltaTime;
            _prephab.transform.localPosition = Vector3.Lerp(start, _route.points[_curentPositionIndex], i);
            yield return null;
        }
        _curentPositionIndex++;
        isMooving = false;
    }
}
