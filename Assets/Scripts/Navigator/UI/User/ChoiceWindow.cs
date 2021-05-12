using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceWindow : MonoBehaviour
{

    public Button startRouteBtn;

    private void Start()
    {
        TrackableEventHandler.OnTrackingFoundEvent += TurnOnRouteBtn;
    }

    public void TurnOffRouteBtn()
    {
        startRouteBtn.interactable = false;
    }

    public void TurnOnRouteBtn()
    {
        startRouteBtn.interactable = true;
    }
}
