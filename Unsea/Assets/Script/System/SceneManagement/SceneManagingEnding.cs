using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagingEnding : MonoBehaviour
{
    EndGameButton endGameButton;
    public int sceneIndex;
    int LoadThisLevel;
    // Start is called before the first frame update
    void Start()
    {
        endGameButton = GameObject.Find("EndingButton").GetComponent<EndGameButton>();
    }
    private void Update()
    {
        if (endGameButton.GoodEnd == true)
        {
            LoadThisLevel = sceneIndex + 1;
        }
        else
        {
            LoadThisLevel = sceneIndex;
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(LoadThisLevel);
    }
    /*public void ChangeScene(int sceneIndex)
    {
        if (endGameButton.GoodEnd == true)
        {
            SceneManager.LoadScene(sceneIndex+1);
        }
        else
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }*/
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
