using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayTest : MonoBehaviour
{
    public Text Notification;
    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

        Debug.DrawRay(transform.position, forward, Color.red);
        Notification.text = "Distance " + Vector3.Distance(transform.position, GetMarkerPosition());
    }


    Vector3 GetMarkerPosition()
    {
        RaycastHit hitObject;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        if (Physics.Raycast(transform.position, forward, out hitObject))
            Debug.LogWarning(hitObject.collider.name);
        return hitObject.point;
    }
}
