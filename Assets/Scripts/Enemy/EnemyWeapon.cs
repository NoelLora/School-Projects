using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    private RaycastHit hit;


    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
        {
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
