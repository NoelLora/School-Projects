using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Camera : MonoBehaviour
{ 
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;

private void LateUpdate()
{
    Vector3 playerPosition = target.position + offset;
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed * Time.deltaTime);
    transform.position = smoothedPosition;

    }
    /*
     void FixedUpdate()
    {
        LateUpdate();
    }*/
}
//smoothSpeed* Time.deltaTime