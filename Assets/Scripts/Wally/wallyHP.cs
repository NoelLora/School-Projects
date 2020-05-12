using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wallyHP : MonoBehaviour
{
    private Animator animator;
    public Scrollbar hpbar;
    private float HP = 100;
    //private float damage = 10;
    public static float health;
    public float rnhp;
    public float lives;

    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = 100;
        rnhp = health / HP;
        lives = 3;
        numOfHearts = 3;
    }

    // Update is called once per frame
    void Update()
    {
        rnhp = health/HP;
        hpbar.size = rnhp;
        lifeSystem();
    }
    IEnumerator WallyDeath()
    {
        animator.Play("Wally_Death");
        yield return new WaitForSeconds(1f);



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "EnemyFist")
        {
            animator.Play("Wally_Damaged");
            health -= 3;
            // wallyHP.health = nhp;

        }

        if (collision.collider.gameObject.tag == "BossFist")
        {
            animator.Play("Wally_Damaged");
            health -= 20f;
            // wallyHP.health = nhp;

        }
        if (collision.collider.gameObject.tag == "EnemyRanged")
        {
            animator.Play("Wally_Damaged");
            health -= 5;
            // wallyHP.health = nhp;

        }

        if (health <= 0 && lives >= 2)
        {
            StartCoroutine(WallyDeath());
            lives = --lives;
            health = 100;
            //animator.Play("Wally_Idle");


        }

        if (health <= 0 && lives <= 1 )
        {
            StartCoroutine(WallyDeath());
            Destroy(this.gameObject);
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void lifeSystem()
    {
       
        if (lives > numOfHearts)
        {
            lives = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}

