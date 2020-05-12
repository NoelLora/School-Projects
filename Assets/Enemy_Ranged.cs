using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            // PlayerAnimation();
        }
    }
}
