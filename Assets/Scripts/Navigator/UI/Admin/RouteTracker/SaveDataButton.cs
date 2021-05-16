using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataButton : MonoBehaviour
{
    [SerializeField]
    private JSONAdmin jsonAdmin;

    private Button saveDataBtn;

    void Start()
    {
        saveDataBtn = gameObject.GetComponent<Button>();
        saveDataBtn.onClick.AddListener(jsonAdmin.SaveData);
        saveDataBtn.onClick.AddListener(TurnOff);
    }

    # region PUBLIC_METHODS

    public void TurnOn()
    {
        saveDataBtn.interactable = true;
    }

    #endregion

    #region PRIVATE_METHODS

    private void TurnOff()
    {
        saveDataBtn.interactable = false;
    }

    #endregion
}
