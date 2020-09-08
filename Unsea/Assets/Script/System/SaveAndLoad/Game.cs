using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    int CurrentLevel;

    private void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ResetAll()
    {//Resetevery every thing that playerPrefs saved
        PlayerPrefs.DeleteAll();
    }

    public void ResetHightScore()
    {//ResetHightScore
        PlayerPrefs.DeleteKey("HightScore" + CurrentLevel.ToString());
    }
    public void ResetCheckpoint()
    {
        PlayerPrefs.DeleteKey("saveMainPoint" + CurrentLevel.ToString());
        PlayerPrefs.DeleteKey("SavedScore" + CurrentLevel.ToString());
        PlayerPrefs.DeleteKey("TimeWhenHitCheckpoint" + CurrentLevel.ToString());
        DeleteAllProgress();
    }
    public void ResetBestTimer()
    {
        PlayerPrefs.DeleteKey("BestTime" + CurrentLevel.ToString());

    }
    public void Save()
    {
        GameEvents.OnSaveInitiated();
    }

    public void DeleteAllProgress()
    {
        SaveLoad.SeriouslyDeleteAllSaveFiles();
    }
}
