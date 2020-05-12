using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelEnemyMove : MonoBehaviour
{
    public GameObject Player;
    public float speed = 12f;
    public float MobDistanceRun = 40f;
    private Animator animator;
    public bool faceingRight = true;


    void Start()
    {
        animator = GetComponent<Animator>();

    }

     void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < MobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
            
            if (dirToPlayer.x < 0)
            {
                //Flip();
                // faceingRight = true;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                // Flip();
                //faceingRight = false; 
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
        }
        //animator.Play("Boss_Idle");

        //cout << "Hello World" << endl;

}





void Flip()
    {
        faceingRight = !faceingRight;
        Vector3 scale = transform.localScale;
        scale.x *= 1;
        transform.localScale = scale;
    }







}
