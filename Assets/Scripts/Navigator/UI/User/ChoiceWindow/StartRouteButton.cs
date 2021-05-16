using UnityEngine;
using UnityEngine.UI;

public class StartRouteButton : MonoBehaviour
{
    [Header("Скрипты")]
    [SerializeField]
    ARSceneUser arSceneUser;
    [SerializeField]
    ChoiceWindow choiceWindow;
    [SerializeField]
    Indicator indicator;
    [SerializeField]
    ResetButtonUser resetButton;

    private Button _button;
    public Button button { get { return _button; } }

    #region UNITY_MONOBEHAVIOUR_METHODS

    void Start()
    {
        _button = gameObject.GetComponent<Button>();
        SetTasks();
    }

    #endregion

    #region PRIVATE_METHODS

    private void SetTasks()
    {
        _button.onClick.AddListener(arSceneUser.Begin);
        _button.onClick.AddListener(TurnOff);
        _button.onClick.AddListener(indicator.StartRoute);
        _button.onClick.AddListener(choiceWindow.SetIndicatorRoute);
        _button.onClick.AddListener(() => EventsHolder.TargetChanged
                                            -= arSceneUser.Prepare);
        _button.onClick.AddListener(resetButton.TurnOn);
        EventsHolder.TrackingFound += TurnOn;
        EventsHolder.TrackingLost += TurnOff;
    }

    private void TurnOn()
    {
        _button.interactable = true;
    }

    private void TurnOff()
    {
        _button.interactable = false;
    }

    #endregion
}
