using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataButton : MonoBehaviour
{
    [Header("Скрипты")]
    [SerializeField]
    private JSONAdmin jsonAdmin;
    [SerializeField]
    private RouteTracker routeTracker;
    [SerializeField]
    private SaveRouteSettingsPanel saveRouteSettings;
    [Header("Поле ввода доп информации")]
    [SerializeField]
    private InputField extraInfoInputField;


    private Button saveDataBtn;

    void Start()
    {
        saveDataBtn = gameObject.GetComponent<Button>();
        saveDataBtn.onClick.AddListener(FillExtraInfo);
        saveDataBtn.onClick.AddListener(jsonAdmin.SaveData);
        saveDataBtn.onClick.AddListener(Close);
    }

    #region PRIVATE_METHODS

    private void FillExtraInfo()
    {
        routeTracker.FillRouteExtraInfo(extraInfoInputField.text);
    }

    private void Close()
    {
        routeTracker.ResetToDefault();
        routeTracker.gameObject.SetActive(true);
        saveRouteSettings.gameObject.SetActive(false);
    }


    #endregion
}
