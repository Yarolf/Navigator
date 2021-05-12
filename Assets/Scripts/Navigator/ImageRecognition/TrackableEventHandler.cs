using UnityEngine;
public class TrackableEventHandler : DefaultTrackableEventHandler
{
    public delegate void TrackableNameHandler(string name);
    public static event TrackableNameHandler OnTrackingFoundWithName;

    public delegate void TrackableHandler();
    public static event TrackableHandler OnTrackingFoundEvent;
    public static event TrackableHandler OnTrackingLostEvent;

    public delegate void TrackableObjectHandler(Transform obj);
    public static event TrackableObjectHandler OnTrackingFoundWithObject;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        OnTrackingFoundWithName?.Invoke(mTrackableBehaviour.TrackableName);
        OnTrackingFoundEvent?.Invoke();
        OnTrackingFoundWithObject?.Invoke(mTrackableBehaviour.gameObject.transform);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        OnTrackingLostEvent?.Invoke();
    }
}
