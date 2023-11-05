using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;  // The object the camera will follow
    public Vector3 offset = new Vector3(0f, 10f, 0f);  // Offset from the target
    public float smoothSpeed = 0.125f;  // Smoothing factor for camera movement

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }
}
