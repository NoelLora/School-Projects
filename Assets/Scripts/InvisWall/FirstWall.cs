using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWall : MonoBehaviour
{
    public GameObject enemy;
    public GameObject wall;
    public GameObject wave;

    void Update()
    {
        
        if(enemy == null)
        {
            wall.SetActive(false);
        }

        if (wall != null)
        {
            wave.SetActive(true);
        }
    }
}
