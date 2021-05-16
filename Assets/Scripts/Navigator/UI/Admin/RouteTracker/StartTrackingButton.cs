using UnityEngine;
using UnityEngine.UI;

public class StartTrackingButton : MonoBehaviour
{
    [Header("Скрипты")]
    [SerializeField]
    RouteTracker routeTracker;
    [SerializeField]
    ResetButtonAdmin resetButtonAdmin;

    Button startTrackingBtn;

    # region UNITY_MONOBEHAVIOUR_METHODS

    private void Start()
    {
        startTrackingBtn = gameObject.GetComponent<Button>();
        startTrackingBtn.onClick.AddListener(routeTracker.StartTracking);
        startTrackingBtn.onClick.AddListener(resetButtonAdmin.TurnOn);
        EventsHolder.TrackingFound += TurnOn;
        EventsHolder.TrackingLost += TurnOff;
    }

    #endregion

    #region PRIVATE_METHODS

    private void TurnOn()
    {
        startTrackingBtn.interactable = true;
    }

    private void TurnOff()
    {
        startTrackingBtn.interactable = false;
    }

    #endregion
}
