using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallyRanged : MonoBehaviour
{
    public AudioClip range;

    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ranged()
    {
        audioS.PlayOneShot(range);
    }

}
