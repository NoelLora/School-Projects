using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPow : MonoBehaviour
{
    public AudioClip boom;

    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Pow()
    {
        audioS.PlayOneShot(boom);
    }
}
