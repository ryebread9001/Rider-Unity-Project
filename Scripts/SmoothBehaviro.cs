using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothBehaviro : MonoBehaviour
{
    public Transform trans;
    public float smooth = 0.00001f;
    private Vector3 offset = new Vector3(0, 2f, -6f);


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = trans.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
        transform.position = smoothedPosition;
    }
}
