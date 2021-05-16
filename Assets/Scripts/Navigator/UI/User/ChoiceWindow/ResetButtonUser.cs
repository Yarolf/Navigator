using UnityEngine;
using UnityEngine.UI;

public class ResetButtonUser : MonoBehaviour
{
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

    #endregion

    #region PRIVATE_METHODS

    private void ResetToDefault()
    {
        EventsHolder.TargetChanged += arSceneUser.Prepare;
        indicator.ResetToDefault();
        TurnOff();
    }

    private void TurnOff()
    {
        _button.interactable = false;
    }

    #endregion
}
