using UnityEngine.UI;
using UnityEngine;
public class ARSceneUser : ARScene
{
    #region UNITY_MONOBEHAVIOUR_METHODS

    private void Start()
    {
       EventsHolder.TargetChanged += Prepare;
        Notification.SetText("Отсканируйте изображение");
    }

    #endregion
}
