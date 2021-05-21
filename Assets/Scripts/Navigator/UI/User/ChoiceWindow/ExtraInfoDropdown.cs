using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraInfoDropdown : MonoBehaviour
{
    [Header("Скрипты")]
    [SerializeField]
    private JSONUser jsonUser;
    [SerializeField]
    private ChoiceWindow choiceWindow;
    [HideInInspector]
    public Dropdown dropDown;

    private void Start()
    {
        dropDown = gameObject.GetComponent<Dropdown>();
        DropDownDestination.DropDownUpdated += UpdateInfo;
        choiceWindow.destinationDropDown.dropDown.onValueChanged.AddListener((int i) => UpdateInfo());
        EventsHolder.TrackingLost += Hide;
    }

    public void UpdateInfo()
    {
        dropDown.options.Clear();
        string destinationName = choiceWindow.destinationDropDown.dropDown.captionText.text;
        List<Route> routes = jsonUser.data.FindRoutes(ChoiceWindow.StartName, destinationName);
        if (routes.Count > 1)
        {
            FillExtraInfoDropDown(routes);
            Show();
        }
    }

    private void FillExtraInfoDropDown(List<Route> routes)
    {
        dropDown.options.Clear();
        foreach (var route in routes)
        {
            dropDown.options.Add(new Dropdown.OptionData(route.extraInfo));
        }
        dropDown.captionText.text = dropDown.options[0].text;
    }
    private void Show()
    {
        dropDown.gameObject.SetActive(true);
        dropDown.Show();
    }

    private void Hide()
    {
        dropDown.Hide();
        dropDown.gameObject.SetActive(false);
    }
}
