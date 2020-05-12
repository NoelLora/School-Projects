/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai : MonoBehaviour
{
    // Start is called before the first frame update
    public float patrolspeed = 2f;
    public float chasespeed = 5f;
    public float chasewaittime = 5f;
    public float patrolwaittime = 1f;
    public Transform[] patrolWaypoint;
    private EnemySight enemyslight;
    private Transform player;
    private wallyHP playerHP;
    private NavMeshAgent nav;
    private float chasetime;
    private float patroltime;
    private int waypointindex;

    void Start()
    {
        enemyslight = this.GetComponent<EnemySight>();
        nav = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        playerHP = this.GetComponent<wallyHP>();
    }
     void Update()
    {
      if(enemyslight.playerinsight && wallyHP.health>0)
        {
            att();
        }
      else if(enemyslight.player.position != enemyslight.reserposition && wallyHP.health > 0)
        {
            chasing();
        }
      else
        {
            patrolling();

        }
    }
    private void att()
    {
        nav.SetDestination(transform.position);
    }
    private void chasing()
    {
        Vector3 sightingDeltaPos = enemyslight.playerposition - transform.position;
        if(sightingDeltaPos.sqrMagnitude > 4f)
        {
            nav.speed = chasespeed;
            if(nav.remainingDistance < nav.stoppingDistance)
            {
                chasetime += Time.deltaTime;
                if(chasetime >= chasewaittime)
                {
                    enemyslight.playerposition = enemyslight.resetposition;
                    chasetime = 0f;
                }
            }
            else { chasetime = 0; }

        }
    }

    private void patrolling()
    {
        nav.speed = patrolspeed;
        if(nav.destination == enemyslight.resetposition||nav.remainingDistance<nav.stoppingDistance)
        {
            patroltime += Time.deltaTime;
            if(patroltime >= patrolwaittime)
            {
                if(waypointindex == patrolWaypoint.Length-1)
                {
                    waypointindex = 0;
                }
                else { waypointindex++; }
                patroltime = 0;
            }

        }
        else
        {
            patroltime = 0;
        }

        nav.destination = patrolWaypoint[waypointindex].position;
    }
}
*/