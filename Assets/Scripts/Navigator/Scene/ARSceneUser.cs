using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneUser : ARScene
{
    private void Start()
    {
        TrackableEventHandler.OnTrackingFoundWithObject += Prepare;
    }
}
