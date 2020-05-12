using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOuchie1 : MonoBehaviour
{
    public AudioClip ouch1;

    public AudioSource audioS1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Ouchie1()
    {
        audioS1.PlayOneShot(ouch1);
    }
}
