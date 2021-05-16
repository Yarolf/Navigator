using UnityEngine;
using System;

public static class EventsHolder
{
    public static event Action TrackingFound;
    public static event Action TrackingLost;

    public static event Action<ImageMarker> MarkerChanged;
    public static event Action<GameObject> TargetChanged;

    #region PUBLIC_METHODS

    public static void RaiseTrackingFound() => TrackingFound?.Invoke();
    public static void RaiseTrackingLost() => TrackingLost?.Invoke();
    public static void RaiseMarkerChanged(ImageMarker marker) => MarkerChanged?.Invoke(marker);
    public static void RaiseTargetChanged(GameObject target) => TargetChanged?.Invoke(target);

    #endregion
}
