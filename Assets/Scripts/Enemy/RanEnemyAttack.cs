using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanEnemyAttack : MonoBehaviour
{
    private Animator animator;
    private AnimationState animationState = AnimationState.NONE;
    //private AnimatationState state = Spawnstate.COUNTTING;
    private int damage = 10;

    private float timebetweenAttack;
    public float startAttack;


    public Transform attackPos;
    public LayerMask Enemy;
    public float attackRangex;
    public float attackRangey;
    public float attackRangez;

    private float timestamp;


    [SerializeField]
    GameObject EnemyFistbox;

    public enum AnimationState
    {
        NONE = 0,

        //MOVING = 2,
        PUNCH = 1,
        IDLE = 2
        //SHOOT = 4

    };


    /*
    void OnTriggerEnter(CapsuleCollider other)
    {
        if (other.gameObject.name.Equals("Enemy"))
        {
            new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        //animationState = AnimationState.IDLE;
        animator = GetComponent<Animator>();
        EnemyFistbox.SetActive(false);
        StartCoroutine(DoAttack());
    }

    IEnumerator DoAttack()
    {
        EnemyFistbox.SetActive(true);
        yield return new WaitForSeconds(.8f);
        EnemyFistbox.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

        //if (timebetweenAttack <= 0)
        //{
        // if (Input.GetKey(KeyCode.Mouse0))
        //{
        //Collider enemiesToDamage = gameObject.name.Equals("Enemy");
        /*
        Collider[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Enemy);
        //BoxCollider[] enemiesToDamage = Physics2D.OverlapBox(attackPos.position,
            for(int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage);
        }*/
        if (timebetweenAttack <= 0)
        {
            PlayerAnimation();
            timebetweenAttack = startAttack;

        }
        else
        {
            timebetweenAttack -= Time.deltaTime;

        }

        //}

        //   timebetweenAttack = startAttack;
        //  PlayerAnimation();
        //}
        /*
        else
        {
            timebetweenAttack -= Time.deltaTime;
        }
        if (Input.GetKey("r"))
        {
            PlayerAnimation();
        }
    }
    */
    }

    void PlayerAnimation()
    {
        //animationState = AnimationState.IDLE;
        //animator.SetBool("Wally_Idle", true);
        //Fistbox.SetActive(false);
        //MyCoroutine();
        // if (Input.GetKey(KeyCode.Mouse0))
        //{
        // Debug.Log("Punch");

        //Fistbox.SetActive(true);
        //MyCoroutine();
        
        //animationState = AnimationState.PUNCH;
        //animator.Play("EnemyPunch");
        //StartCoroutine(DoAttack());



        //BoxCollider[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangex, attackRangey), 0);
        //    for (int i = 0; i < enemiesToDamage.Length; i++)
        //{
        //    enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage);
        //}
        //animationState = AnimationState.IDLE;
        //  MyCoroutine();
        //}
        animationState = AnimationState.IDLE;


        switch (animationState)
        {
            case AnimationState.NONE:
                animator.SetBool("Enemy", false);
                animator.SetBool("EnemyPunch", false);
                break;

            case AnimationState.PUNCH:
                animator.SetBool("Enemy", false);
                animator.SetBool("EnemyPunch", true);

                break;

            case AnimationState.IDLE:
                animator.SetBool("Enemy", true);
                animator.SetBool("EnemyPunch", false);
                //Fistbox.SetActive(false);

                break;
            default:
                break;


        }
    }
}
