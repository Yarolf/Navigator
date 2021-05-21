using UnityEngine;
using UnityEngine.UI;

public class ResetButtonUser : MonoBehaviour
{
    [Header("Скрипты")]
    [SerializeField]
    ChoiceWindow choiceWindow;
    [SerializeField]
    Indicator indicator;
    [SerializeField]
    ARSceneUser arSceneUser;
    Button _button;
    public Button button { get { return _button; } }

    #region UNITY_MONOBEHAVIOUR_METHODS

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(ResetToDefault);
    }

    #endregion

    #region PUBLIC_METHODS

    public void TurnOn()
    {
        _button.interactable = true;
    }

    public void ResetToDefault()
    {
        EventsHolder.TargetChanged += arSceneUser.Prepare;
        indicator.ResetToDefault();
        choiceWindow.ResetStartName();
        choiceWindow.startRouteButton.TurnOn();
        Notification.SetText("Отсканируйте изображение");
        TurnOff();
    }

    #endregion

    #region PRIVATE_METHODS

    private void TurnOff()
    {
        _button.interactable = false;
    }

    #endregion
}
