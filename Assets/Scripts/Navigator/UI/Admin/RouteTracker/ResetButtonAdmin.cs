using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButtonAdmin : MonoBehaviour
{
    [Header("Скрипты")]
    [SerializeField]
    RouteTracker routeTracker;

    Button resetBtn;

    # region UNITY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        resetBtn = gameObject.GetComponent<Button>();
        resetBtn.onClick.AddListener(routeTracker.ResetToDefault);
        resetBtn.onClick.AddListener(TurnOff);
    }

    #endregion

    # region PUBLIC_METHODS

    public void TurnOn()
    {
        resetBtn.interactable = true;
    }

    #endregion

    #region PRIVATE_METHODS

    private void TurnOff()
    {
        resetBtn.interactable = false;
    }

    #endregion
}
