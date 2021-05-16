using UnityEngine;
using System;
public class TrackableEventHandler : DefaultTrackableEventHandler
{
    #region PROTECTED_METHODS

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        TrackingFound();
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        TrackingLost();
    }

    #endregion

    #region PRIVATE_METHODS

    private void TrackingFound()
    {
        EventsHolder.RaiseTrackingFound();
        EventsHolder.RaiseMarkerChanged(mTrackableBehaviour.gameObject.GetComponent<ImageMarker>());
        EventsHolder.RaiseTargetChanged(mTrackableBehaviour.gameObject);
    }

    private void TrackingLost()
    {
        EventsHolder.RaiseTrackingLost();
    }

    #endregion
}
