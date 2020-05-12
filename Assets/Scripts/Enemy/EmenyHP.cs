using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyHP : MonoBehaviour
{
    private MelEnemyMove melEnemyMove;
    private Animator animator;
    public int HP = 40;
    public float nhp = 100;
    private int damage = 10;
    private int rangedDamage = 5;
    private float dazeTimer;
    public float startDazedTime;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Awake()
    {
        melEnemyMove = GetComponent<MelEnemyMove>();    
    }

    // Update is called once per frame
    IEnumerator EnemyDeath()
    {
        animator.Play("Death");
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);


    }

    void Update()
    {
        if(dazeTimer <= 0)
        {
            melEnemyMove.speed =  0f;
        }
        // Debug.Log("Enemy HP: " + HP);
        if (HP <= 0)
        {
            StartCoroutine(EnemyDeath());
 
        }
       melEnemyMove.speed = 12;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Fistbox")
        {
           // SoundManagerScript.PlaySound("PunchHit");
           // SoundManagerScript.PlaySound("GutPunch");
            dazeTimer = startDazedTime;
            animator.Play("EnemySuDamaged");
            HP -= damage;
            // wallyHP.health = nhp;
        }
        if (collision.collider.tag == "PlayerRanged")
        {
            //SoundManagerScript.PlaySound("PunchHit");
           // SoundManagerScript.PlaySound("GutPunch");
            dazeTimer = startDazedTime;

            // DestroyObject(WallyBullet);
            animator.Play("EnemySuDamaged");
            HP -= rangedDamage;
            // wallyHP.health = nhp;
        }



    }
}
