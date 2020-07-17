using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    public void ResetAll()
    {//Resetevery every thing that playerPrefs saved
        PlayerPrefs.DeleteAll();
    }

    public void ResetHightScore()
    {//ResetHightScore
        PlayerPrefs.DeleteKey("HightScore");
    }

}
