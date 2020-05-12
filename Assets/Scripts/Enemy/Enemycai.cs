using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycai : MonoBehaviour
{
    public GameManager gameManager;
    float startPos;
    float endPos;
    public int unitsToMove = 5; //speed
    public int moveSpeed = 2;
    bool moveRight = true;
    private void Awake()
    {
        startPos = transform.position.x;
        endPos = startPos + unitsToMove;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        {
            GetComponent<Rigidbody>().position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if(GetComponent<Rigidbody>().position.x >= endPos)
        {
            moveRight = false;
        }
        if(moveRight == false)
        {
            GetComponent<Rigidbody>().position -= Vector3.right * moveSpeed * Time.deltaTime;
        }
        if(GetComponent<Rigidbody>().position.x <= startPos)
        {
            moveRight = true;
        }
    }
    int damageValue = 1;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            gameManager.SendMessage("PlayerDamag", damageValue, SendMessageOptions.DontRequireReceiver);

            gameManager.SendMessage("Taken Damage", SendMessageOptions.DontRequireReceiver);
        }
    }

}
