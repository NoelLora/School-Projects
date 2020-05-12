using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float distance;
    public int health;

    Rigidbody rigidbody;

    private bool patrolingRight = true;
    public float patrolTime;
    float timer;
    int direction = 1;

    public Transform groundDetection;


    /*
     * Patrol stuff
     */
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        timer = patrolTime;
        //health;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            direction = -direction;
            timer = patrolTime;
        }
        Vector3 position = rigidbody.position;
        position.x += Time.deltaTime * speed;
        position.z += Time.deltaTime * speed;

        rigidbody.MovePosition(position);
        /*
        Debug.Log(patrolCounter);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        patrolCounter = patrolCounter - Time.deltaTime;
        //if((groundInfo.collider == false) || patrolCounter == 0)
        //{
            if((patrolingRight == true) && patrolCounter == 0) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                patrolingRight = false;
            }else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            patrolCounter = 10f;
            }

       }
    }
    */
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage taken");
    }
}
