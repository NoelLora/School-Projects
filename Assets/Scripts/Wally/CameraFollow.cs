using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 3f;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 playerPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, offset.z);
        }
    }
    /*
     void FixedUpdate()
    {
        LateUpdate();
    }*/
}
//smoothSpeed* Time.deltaTime