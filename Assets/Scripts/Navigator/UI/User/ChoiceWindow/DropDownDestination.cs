using UnityEngine;
using UnityEngine.UI;

public class DropDownDestination : MonoBehaviour
{
    [HideInInspector]
    public Dropdown destinationDropDown;
    void Start()
    {
        destinationDropDown = gameObject.GetComponent<Dropdown>();
        EventsHolder.MarkerChanged += UpdateDestinationDropDown;
        EventsHolder.TrackingLost += Hide;
    }

    #region PRIVATE_METHODS

    private void UpdateDestinationDropDown(ImageMarker marker)
    {
        destinationDropDown.options.Clear();
        foreach (var _marker in ARScene.Markers)
        {
            if (_marker != marker)
                destinationDropDown.options.Add(new Dropdown.OptionData(_marker.TranslitedName));
        }
        destinationDropDown.captionText.text = destinationDropDown.options[0].text;
        Show();
    }

    private void Show()
    {
        destinationDropDown.interactable = true;
        destinationDropDown.Show();
    }

    private void Hide()
    {
        destinationDropDown.Hide();
        destinationDropDown.interactable = false;
    }

    #endregion
}
