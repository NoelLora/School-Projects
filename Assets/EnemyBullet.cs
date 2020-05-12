using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Bullet Movement Settings:")]
    public float speedMultiplier;
    public bool useHorizontalPhysicsMovement = true;
    private bool isMovingRight = true;
    private Rigidbody rb;
    public GameObject bullet;
    [Header("Bullet Damage Settings:")]
    [Range(1, 100)] public float bulletDamage = 20.0f;

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Enemy");

        if (player.transform.localScale.x > 0)
        {
            isMovingRight = true;
        }
        else if (player.transform.localScale.x < 0)
        {
            isMovingRight = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);

        if (useHorizontalPhysicsMovement)
        {
            rb = GetComponent<Rigidbody>();

            if (isMovingRight)
            {

                rb.AddForce(transform.right * speedMultiplier, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(-transform.right * speedMultiplier, ForceMode.Impulse);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!useHorizontalPhysicsMovement)
        {
            if (isMovingRight)
            {
                transform.Translate(Vector2.zero * Time.deltaTime * speedMultiplier);
            }
            else
            {
                transform.Translate(Vector2.zero * Time.deltaTime * speedMultiplier);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            DestroySelf();
        }



    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
