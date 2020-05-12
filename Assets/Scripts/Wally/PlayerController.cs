using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Vector3 lastMoveDir;
    public float speed = 16.9f;
    public float dashDistance = 10f;
    public bool faceingRight = true;
    public float dashTimer;
    public float maxDash = 2f;
    public DashState dashState;

    [SerializeField]
    GameObject Fistbox;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Fistbox.SetActive(false);
    }
    private void Update()
    {
        HandleMovement();
      //  HandleDash();
        dashStates();
        //aanimator.Play("Wally Punch");

    }

    private void HandleMovement()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            Flip();
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        bool isIdle = moveX == 0 && moveY == 0;
        if (isIdle)
        {
           // animator.Play("Wally_Idle");
            return;
        }
        else
        {
            Vector3 moveDir = new Vector3(moveX, 0, moveY).normalized;

            Vector3 targetMovePosition = transform.position + moveDir * speed * Time.deltaTime;
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, speed * Time.deltaTime);
            if (moveDir.x < 0)
            {
                //faceingRight = false;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
               // faceingRight = true;
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
                if (raycastHit.collider == null)
            {
                lastMoveDir = moveDir;
                transform.position = targetMovePosition;
            }
            else
            {
                Vector3 testMoveDir = new Vector3(moveDir.x, 0f).normalized;
                targetMovePosition = transform.position + testMoveDir * speed * Time.deltaTime;
                raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed * Time.deltaTime);

                if (testMoveDir.x != 0f && raycastHit.collider == null)
                {
                    lastMoveDir = testMoveDir;
                    transform.position = targetMovePosition;
                }
                else
                {
                    testMoveDir = new Vector3(0f, moveDir.y).normalized;
                    targetMovePosition = transform.position + testMoveDir * speed * Time.deltaTime;
                    raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed * Time.deltaTime);
                    if (testMoveDir.y != 0f && raycastHit.collider == null)
                    {
                        lastMoveDir = testMoveDir;
                        transform.position = targetMovePosition;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
    /*
    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += lastMoveDir * dashDistance;
        }
    }
    */

    void dashStates()
    {
        switch (dashState)
        {
            case DashState.Ready:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                   // SoundManagerScript.PlaySound("Wally_Dash");
                    animator.Play("Wally_Dash");

                    transform.position += lastMoveDir * dashDistance;
                    dashState = DashState.Dashing;
                   
                }
                    break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }

    void Flip()
    {
        faceingRight = !faceingRight;
        Vector3 scale = transform.localScale;
        scale.x *= 1;
        transform.localScale = scale;
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}