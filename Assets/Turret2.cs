using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2 : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public PunchState punchState = PunchState.Ready;

    public float punchTimer;
    public float maxDash1 = 4f;
    void Update()
    {
        punchStates();
    }
    public enum PunchState
    {
        Ready,
        Punching,
        Cooldown
    }
    void punchStates()
    {
        switch (punchState)
        {
            case PunchState.Ready:
                punchState = PunchState.Punching;
                Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);


                // SoundManagerScript.PlaySound("Wally_Dash");
                Debug.Log("I am punching");


                break;
            case PunchState.Punching:
                punchTimer += Time.deltaTime * 3;
                Debug.Log("I punched");

                if (punchTimer >= maxDash1)
                {
                    punchTimer = maxDash1;
                    punchState = PunchState.Cooldown;
                }
                break;
            case PunchState.Cooldown:
                Debug.Log("Iam waiting to punch");

                punchTimer -= Time.deltaTime;
                if (punchTimer <= 0)
                {
                    punchTimer = 0;
                    punchState = PunchState.Ready;
                }
                break;
        }
    }
}
