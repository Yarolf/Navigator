using UnityEngine;

public class ARCamera : MonoBehaviour
{
    private static Camera camera;

    # region UNITY_MONOBEHAVIOUR_METHODS
    
    private void Awake()
    {
        camera = gameObject.GetComponent<Camera>();
    }

    #endregion

    #region PUBLIC_METHODS

    public static float GetDistanseFrom(Vector3 target)
    {
        return Vector3.Distance(GetPositionAfterScaning(), target);
    }

    public static Vector3 GetPositionAfterScaning()
    {
        Vector3 localPoint = camera.transform.position - ARScene.Scene.transform.position;
        return ARScene.GetCoordinatesRelativeToRotation(localPoint);
    }

    #endregion
}


