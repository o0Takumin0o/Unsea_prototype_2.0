using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{//  last check point position
    public Vector3 lastCheckPointPos;
    public static GameManager Instance
    {
        get;
        private set;
    }
    private void Awake()
    {
        if (Instance == null)
        {// gameobject will destroy itself between scenes and dont reset infomation;
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {//if alrady have gameobject so it donhave multiple game object
            Destroy(gameObject);
        }

    }
}
