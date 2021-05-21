using System;
using UnityEngine;
using UnityEngine.UI;

public class DropDownDestination : MonoBehaviour
{
    [SerializeField]
    private ChoiceWindow choiceWindow;

    [HideInInspector]
    public Dropdown dropDown;

    public static Action DropDownUpdated;

    private void Awake()
    {
        dropDown = gameObject.GetComponent<Dropdown>();
    }

    void Start()
    {
        EventsHolder.MarkerChanged += UpdateDestinationDropDown;
        EventsHolder.TrackingLost += Hide;
    }

    #region PRIVATE_METHODS

    private void UpdateDestinationDropDown(ImageMarker marker)
    {
        dropDown.options.Clear();
        foreach (var _marker in ARScene.Markers)
        {
            if (_marker != marker)
                dropDown.options.Add(new Dropdown.OptionData(_marker.TranslitedName));
        }
        dropDown.captionText.text = dropDown.options[0].text;
        Show();
        DropDownUpdated?.Invoke();
    }

    private void Show()
    {
        dropDown.interactable = true;
        dropDown.Show();
    }

    private void Hide()
    {
        dropDown.Hide();
        dropDown.interactable = false;
    }

    #endregion
}
