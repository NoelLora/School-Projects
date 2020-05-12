using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallyPunch : MonoBehaviour
{
    public AudioClip punch;

    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Punch()
    {
        audioS.PlayOneShot(punch);
    }

}
