using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOuchie2 : MonoBehaviour
{
    public AudioClip ouch2;

    public AudioSource audioS2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Ouchie2()
    {
        audioS2.PlayOneShot(ouch2);
    }
}
