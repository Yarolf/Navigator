using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceWindow : MonoBehaviour
{
    [Header("Скрипты")]
    public StartRouteButton startRouteButton;
    public ResetButtonUser resetButton;
    public ExtraInfoDropdown extraInfoDropDown;
    public DropDownDestination destinationDropDown;
    [SerializeField]
    private JSONUser jsonUser;

    private static string _startName;
    public static string StartName {get { return _startName; } }

    private void Start()
    {
        EventsHolder.MarkerChanged += ShowImageName;
        EventsHolder.MarkerChanged += UpdateStartName;
    }

    public void SetIndicatorRoute()
    {
        string destinationName = destinationDropDown.dropDown.captionText.text;
        string extraInfo = extraInfoDropDown.dropDown.captionText.text;
        Route route = jsonUser.data.FindRoute(_startName, destinationName, extraInfo);
        if (route != null)
            Indicator.SetRoute(route);
        else
        {
            resetButton.ResetToDefault();
            Notification.SetText("Путь ещё не создан!");
        }
    }

    public void ShowImageName(ImageMarker marker)
    {
        if (marker.TranslitedName != _startName)
            Notification.SetText(marker.TranslitedName);
    }

    public void ResetStartName()
    {
        _startName = ""; 
    }

    private void UpdateStartName(ImageMarker marker)
    {
        _startName = marker.TranslitedName;
    }
}
