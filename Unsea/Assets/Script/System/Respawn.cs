using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[SerializeField]
public class Respawn : MonoBehaviour
{
    SlowTime slowTime;
    public GameObject gameoverScreen;
    private void Start()
    {
        gameoverScreen.SetActive(false);
        slowTime = GameObject.Find("TimeManager").GetComponent<SlowTime>();
    }
    public void RespawnPlayer()
    {//reload current scene
        
        gameoverScreen.SetActive(true);
        slowTime.Endlevel = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameoverScreen.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            slowTime.TimeSpeedReset();
        }
    }
}
