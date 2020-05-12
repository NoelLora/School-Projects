using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOuchie : MonoBehaviour
{
    public AudioClip ouch;

    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Ouchie()
    {
        audioS.PlayOneShot(ouch);
    }
}
