using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallyAttack : MonoBehaviour
{
    private Animator animator;
    private AnimationState animationState = AnimationState.NONE;
    //private AnimatationState state = Spawnstate.COUNTTING;
    private int damage = 20;

    private float timebetweenAttack;
    public float startAttack;


    public Transform attackPos;
    public LayerMask Enemy;
    public float attackRangex;
    public float attackRangey;
    public float attackRangez;
    public bool isWalking;
    public bool isPunching;


    [SerializeField]
    GameObject Fistbox;
    private PlayerController playerController;

    public enum AnimationState
    {
        NONE = 0,

        //MOVING = 2,
        PUNCH = 1,
        IDLE = 2,
        WALKING = 3

    };
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

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
        animationState = AnimationState.IDLE;
        animator = GetComponent<Animator>();
        Fistbox.SetActive(false);
        StartCoroutine(DoAttack());
        isWalking = false;

    }

    IEnumerator DoAttack()
    {
        Fistbox.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Fistbox.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimation();
    }

    void PlayerAnimation()
    {
       // animationState = AnimationState.IDLE;
        //animator.SetBool("Wally_Idle", true);
        //Fistbox.SetActive(false);
        //MyCoroutine();
        

        if (Input.GetKey(KeyCode.Mouse0)) //&& !isWalking)
        {


            animationState = AnimationState.PUNCH;
            animator.Play("Wally Punch");
            StartCoroutine(DoAttack());
            // yield WaitForSeconds(animation["Wally Punch"].length);
            isPunching = true;
            return;



            //BoxCollider[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangex, attackRangey), 0);
            //    for (int i = 0; i < enemiesToDamage.Length; i++)
            //{
            //    enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage);
            //}


            //animationState = AnimationState.IDLE;
            //  MyCoroutine();

        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            animationState = AnimationState.WALKING;
            animator.Play("Wally_Walking");
            SoundManagerScript.PlaySound("FootSteps");
            //isWalking = true;
        }
        if(isPunching == true)
        {
            animationState = AnimationState.WALKING;

        }
        //animationState = AnimationState.IDLE;
        //isWalking = false;


        switch (animationState)
        {
            case AnimationState.NONE:
                animator.SetBool("Wally_Idle", false);
                animator.SetBool("Wally Punch", false);
                animator.SetBool("Wally_Walking", false);

                break;

            case AnimationState.PUNCH:
                animator.SetBool("Wally_Idle", false);
                animator.SetBool("Wally Punch", true);
                animator.SetBool("Wally_Walking", false);

                break;

            case AnimationState.IDLE:
                animator.SetBool("Wally_Idle", true);
                animator.SetBool("Wally Punch", false);
                animator.SetBool("Wally_Walking", false);

                break;

            case AnimationState.WALKING:
                animator.SetBool("Wally_Idle", false);
                animator.SetBool("Wally Punch", false);
                animator.SetBool("Wally_Walking", true);
                break;

            default:
                break;


        }
    }

}
