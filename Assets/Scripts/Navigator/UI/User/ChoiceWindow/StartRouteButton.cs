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


    private Button _button;
    public Button button { get { return _button; } }

    #region UNITY_MONOBEHAVIOUR_METHODS

    void Start()
    {
        _button = gameObject.GetComponent<Button>();
        SetTasks();
    }

    #endregion

    #region PUBLIC_METHODS
    public void TurnOn()
    {
        _button.interactable = true;
    }

    public void TurnOff()
    {
        _button.interactable = false;
    }

    #endregion

    #region PRIVATE_METHODS

    private void SetTasks()
    {
        _button.onClick.AddListener(arSceneUser.Begin);
        _button.onClick.AddListener(TurnOff);
        _button.onClick.AddListener(indicator.StartRoute);
        _button.onClick.AddListener(() => EventsHolder.TargetChanged
                                            -= arSceneUser.Prepare);
        _button.onClick.AddListener(choiceWindow.resetButton.TurnOn);
        EventsHolder.TrackingFound += TurnOn;
        EventsHolder.TrackingLost += TurnOff;
        _button.onClick.AddListener(choiceWindow.SetIndicatorRoute);
    }

    #endregion
}
