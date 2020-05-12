using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerLoadLevel : MonoBehaviour
{
   // public GameObject guiObject;
    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        //guiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           // guiObject.SetActive(true);
           // if(guiObject.activeInHierarchy == true && Input.GetButtonDown("r"))
           // {
                Application.LoadLevel(levelToLoad);
            //}

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //guiObject.SetActive(false);
    }
}
