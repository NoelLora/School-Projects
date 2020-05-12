using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private bool state=true;
    public bool isPaused;
    public GameObject pauseMenu;
    public AudioMixer audioBG;
    //public string levelToLoad = MainMenu;

    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }
    public GameObject stop,set,group;
    //public KeyCode Pause = KeyCode.Escape;

    /*
    public void pa()
    {
        if (state)
        {
            if (Input.GetKey(Pause) && state)
            {
               
                stop.SetActive(true);
                Time.timeScale = 0f;
                state = false;

            }
        }
        else
        {
            if (Input.GetKey(Pause))
            {
                stop.SetActive(false);
                Time.timeScale = 1f;
                state = true;
            }

        }
        //return i;
    }
    */

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void quit()
    {
        Application.Quit();

    }
    public void OnGUI()
    {
        GameObject.Find("Canvas/Menu/UI").SetActive(true);

    }
    public void pauses()
    {
        stop.SetActive(true);
        Time.timeScale = 0f;
    }
    public void pausest()
    {
        stop.SetActive(false);
        Time.timeScale = 1f;
    }
    public void backmain()
    {
        Application.LoadLevel("MainMenu");
        Time.timeScale = 1f;

    }
    public void regame()
    {
        SceneManager.LoadScene("World");
        Time.timeScale = 1f;
    }
    public void regameboss()
    {
        SceneManager.LoadScene("BossLevel");
        Time.timeScale = 1f;
    }
    public void sets()
    {
        set.SetActive(true);
        
    }
    public void setback()
    {
        set.SetActive(false);
        
    }
    public void groups()
    {
        group.SetActive(true);

    }
    public void groupback()
    {
        group.SetActive(false);

    }
    public void setvalue(float value)
    {
        audioBG.SetFloat("BG",value);
    }
}
