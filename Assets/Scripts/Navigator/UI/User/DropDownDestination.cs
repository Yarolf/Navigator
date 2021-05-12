using UnityEngine;
using UnityEngine.UI;

public class DropDownDestination : MonoBehaviour
{
    [HideInInspector]
    public Dropdown destinationDropDown;
    void Start()
    {
        destinationDropDown = gameObject.GetComponent<Dropdown>();
        TrackableEventHandler.OnTrackingFoundWithName += UpdateDestinationDropDown;
    }

    public void UpdateDestinationDropDown(string CurentPlace)
    {
        destinationDropDown.options.Clear();
        foreach (var marker in ARScene.markers)
        {
            if (marker.OriginalName != CurentPlace)
                destinationDropDown.options.Add(new Dropdown.OptionData(marker.TranslitedName));
        }
        destinationDropDown.captionText.text = destinationDropDown.options[0].text;
    }
}
