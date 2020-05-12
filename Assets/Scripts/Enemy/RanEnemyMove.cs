using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanEnemyMove : MonoBehaviour
{
    public GameObject Player;
    public float speed = 12f;
    public float MobDistanceRun = 15f;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance > MobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
            animator.Play("Enemy");
        }
    }
}