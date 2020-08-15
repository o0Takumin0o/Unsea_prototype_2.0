using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingSystem : MonoBehaviour
{
    public int ForSceneHightScore;
    public int ForScenebesttime;
    public int HightScore;
    public int SecenID;
    // Start is called before the first frame update
    void Start()
    {
        SecenID = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
