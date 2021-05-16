using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Indicator: MonoBehaviour
{
    #region PUBLIC_MEMBER_VARIABLES

    public static float moovingSpeed = 1;
    public static float distanceToMoveNext = 1;
    
    #endregion

    #region PIVATE_MEMBER_VARIABLES

    [SerializeField]
    private Text _notification;
    [SerializeField]
    private ARSceneUser arSceneUser;

    private static Route _route;
    private static GameObject _prephab;
    private static int _curentPositionIndex = 0;

    private static bool _isMooving = false;

    #endregion

    #region PUBLIC_PROPERTIES

    public static bool IsMooving
    {
        get { return _isMooving; }
    }

    #endregion

    #region UNITY_MONOBEHAVIOUR_METHODS

    void Awake()
    {
        _prephab = gameObject;
        _prephab.SetActive(false);
    }

    void Update()
    {
        var distanse = Vector3.Distance(ARCamera.GetPositionAfterScaning(), _prephab.transform.localPosition);
        if (distanse < distanceToMoveNext && !_isMooving && _route != null)
        {
            if (LastPointReached())
                FinishRoute();
            MoveNext();
        }
    }

    #endregion

    #region PUBLIC_METHODS

    public void StartRoute()
    {
        _prephab.SetActive(true);
        _curentPositionIndex = 0;
    }

    public void ResetToDefault()
    {
        transform.localPosition = Vector3.zero;
        _curentPositionIndex = 0;
        _route = null;
        _notification.text = "Отсканируйте изображение";
        _prephab.SetActive(false);
    }

    public static void SetRoute(Route route)
    {
        _route = route;
    }

    #endregion

    #region PRIVATE_METHODS

    private void FinishRoute()
    {
        EventsHolder.TargetChanged += arSceneUser.Prepare;
        _notification.text = "Вы пришли!";
        ResetToDefault();
    }

    private void MoveNext()
    {
        if (_prephab != null && _route != null)
        {
            if (_route.points.Count > _curentPositionIndex)
            {
                StartCoroutine(MoveNextCouratine());
                _notification.text = "Пройдено точек: " + _curentPositionIndex
                + " из " + _route.points.Count;
            }
        }
    }

    private static IEnumerator MoveNextCouratine()
    {
        _isMooving = true;
        float i = 0;
        Vector3 start = _prephab.transform.localPosition;

        while (i < 1)
        {
            i += moovingSpeed * Time.deltaTime;
            _prephab.transform.localPosition = Vector3.Lerp(start, _route.points[_curentPositionIndex], i);
            yield return null;
        }
        _curentPositionIndex++;
        _isMooving = false;
    }

    private bool LastPointReached()
    {
        if (_curentPositionIndex == _route.points.Count)
            return true;
        return false;
    }

    #endregion
}
