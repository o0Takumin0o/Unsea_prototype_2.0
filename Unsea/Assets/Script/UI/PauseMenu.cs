using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    
    public GameObject pauseMenuUI;
    SlowTime slowTime;
    // Update is called once per frame
    private void Start()
    {
        slowTime = GameObject.Find("TimeManager").GetComponent<SlowTime>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        slowTime.TimeStart();
        //Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        slowTime.TimeStop();
        //Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void end ()
    {
        slowTime.TimeStop();
        //Time.timeScale = 0f;
        GameIsPause = true;
    }

}
