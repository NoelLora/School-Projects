using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip wallyPunch, enemyHit, wallyRanged ;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        wallyPunch = Resources.Load<AudioClip>("PunchWhoosh");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip){
        case "PunchWhoosh":
                audioSrc.PlayOneShot(wallyPunch);
                break;

            
        }
    }
}
