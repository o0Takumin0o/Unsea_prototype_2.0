using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkScenes : MonoBehaviour
{
    private float cooldown = 0;
    public void LoadScene(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
    }
   
    public void ExitApp()
    {
        Application.Quit();
    }
    
}
