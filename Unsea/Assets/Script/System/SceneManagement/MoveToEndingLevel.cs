using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToEndingLevel : MonoBehaviour
{
    //public int nextSceneLoad;
    int nextSceneLoad;
    EndGameButton endGameButton;

    // Start is called before the first frame update
    void Start()
    {
        endGameButton = GameObject.Find("EndingButton").GetComponent<EndGameButton>();
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if(endGameButton.GoodEnd == true)
            nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        else
            nextSceneLoad = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Setting Int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
            Debug.Log(nextSceneLoad);
        }
    }
}
