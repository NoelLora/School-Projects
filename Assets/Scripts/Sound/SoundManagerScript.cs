using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip wallyPunch, enemyHit, wallyRanged, enemyHitSound, wallyWalk, dash ;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        wallyPunch = Resources.Load<AudioClip>("PunchWhoosh");
        enemyHit = Resources.Load<AudioClip>("PunchHit");
        wallyRanged = Resources.Load<AudioClip>("WallyProjectile");
        enemyHitSound = Resources.Load<AudioClip>("GutPunch");
        wallyWalk = Resources.Load<AudioClip>("WallyProjectile");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "PunchWhoosh":
                audioSrc.PlayOneShot(wallyPunch);
                break;
            case "PunchHit":
                audioSrc.PlayOneShot(enemyHit);
                break;
            case "WallyProjectile":
                audioSrc.PlayOneShot(wallyRanged);
                break; 
 
            case "GutPunch":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
            case "Footsteps":
                audioSrc.PlayOneShot(wallyWalk);
                break;
            case "Wally_Dash":
                audioSrc.PlayOneShot(dash);
                break;


        }
    }
}
