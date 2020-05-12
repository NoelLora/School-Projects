using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    private Animator animator;
    private AnimationState animationState = AnimationState.NONE;
    public PunchState punchState= PunchState.Ready;
    public float punchTimer;
    public float maxDash = 4f;


    //private AnimatationState state = Spawnstate.COUNTTING;
    private int damage = 10;

    private float timebetweenAttack = 0;
    public float startAttack;
    public bool faceingRight = true;



    public Transform attackPos;
    public LayerMask Enemy;

    private float timestamp;
    public GameObject Player;
    public float speed = 12f;
    public float MobDistanceRun = 40f;


    [SerializeField]
    GameObject EnemyFistbox;

    public enum AnimationState
    {
        NONE = 0,
        PUNCH = 1,
        IDLE = 2,
        WALK = 3

    };


    void Start()
    {
        //animationState = AnimationState.IDLE;
        animator = GetComponent<Animator>();
        EnemyFistbox.SetActive(false);
        //StartCoroutine(FishBlub());
        StartCoroutine(FishBlub());
    }
    IEnumerator FishBlub()
    {
        animator.Play("Fish");
        yield return new WaitForSeconds(1f);
        animator.Play("Boss_Idle");
    }
    IEnumerator DoAttack()
    {
        animator.Play("Boss_Punch");
        EnemyFistbox.SetActive(true);
        yield return new WaitForSeconds(.5f);
        EnemyFistbox.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        punchStates();
        animator.Play("Fish");
       // animationState = AnimationState.IDLE;
       /*
        if ( timebetweenAttack < 5)
        {
            animator.Play("Boss_Punch");
            StartCoroutine(DoAttack());
            //animationState = AnimationState.PUNCH;

            timebetweenAttack = startAttack;


        }
        else
        {
            Debug.Log("Value" + timebetweenAttack);
            timebetweenAttack += 1;



        }*/
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance > MobDistanceRun)
        {
            PlayerAnimation();
            animationState = AnimationState.IDLE;
        }

        if (distance < MobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            Vector3 dirToPlayerPunch = transform.position - Player.transform.position;

            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
            animationState = AnimationState.WALK;
            PlayerAnimation();

            if (dirToPlayer.x < 0)
            {
                //Flip();
                // faceingRight = true;
                animationState = AnimationState.WALK;

                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                // Flip();
                //faceingRight = false; 
                animationState = AnimationState.WALK;

                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            //animator.Play("Boss_Walking");
            //animationState = AnimationState.WALK;

        }

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

                // SoundManagerScript.PlaySound("Wally_Dash");
                StartCoroutine(DoAttack());
                Debug.Log("I am punching");


                break;
            case PunchState.Punching:
                punchTimer += Time.deltaTime * 3;
                Debug.Log("I punched");

                if (punchTimer >= maxDash)
                {
                    punchTimer = maxDash;
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

    void PunchAnim()
    {
        animator.Play("Boss_Punch");
    }
    void PlayerAnimation()
    {
        //animator.Play("Boss_Punch");

        switch (animationState)
        {
            case AnimationState.NONE:
                animator.SetBool("Fish", false);
                animator.SetBool("Boss_Idle", false);
                animator.SetBool("Boss_Punch", false);
                animator.SetBool("Boss_Walking", false);

                break;

            case AnimationState.PUNCH:
                animator.SetBool("Fish", false);
                animator.SetBool("Boss_Idle", false);
                animator.SetBool("Boss_Punch", true);
                animator.SetBool("Boss_Walking", false);


                break;

            case AnimationState.IDLE:
                animator.SetBool("Fish", false);
                animator.SetBool("Boss_Idle", true);
                animator.SetBool("Boss_Punch", false);
                animator.SetBool("Boss_Walking", false);

                //Fistbox.SetActive(false);

                break;

            case AnimationState.WALK:
                animator.SetBool("Fish", false);
                animator.SetBool("Boss_Idle", false);
                animator.SetBool("Boss_Punch", false);
                animator.SetBool("Boss_Walking", true);


                break;
            default:
                break;


        }
    }
}