using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNoiseSpawner : MonoBehaviour
{
    public GameObject NoiseMakerPrefab;
    public SoundFx soundFX;
    // Start is called before the first frame update
    public Transform spawnPoint;
    public GameObject CrabArmor;
    GameObject NoiseMaker;
    public int DestroyAfter;
    int hasCrabArmor;
    int NumberOfArmor;
    int CurrentLevel;

    private void Start()
    {
        CrabArmor.SetActive(false);
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        NumberOfArmor = PlayerPrefs.GetInt("hasCrabArmor" + CurrentLevel.ToString());
        soundFX = GameObject.Find("SoundCtrl").GetComponent<SoundFx>();
    }

    // Update is called once per frame
    void Update()
    {
        hasCrabArmor = PlayerPrefs.GetInt("hasCrabArmor" + CurrentLevel.ToString());
        Powerunlock();
        Debug.Log("hasClabArmor=" + hasCrabArmor);
        Debug.Log("numberofarmor=" + NumberOfArmor);
        //hasCrabArmor = PlayerPrefs.GetInt("hasCrabArmor" + CurrentLevel.ToString());
    }
    void Powerunlock()
    {
        if (NumberOfArmor >= 1)
        {
            CrabArmor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spawnNoiseMaker();
            }
        }
    }
    public void spawnNoiseMaker()
    {
        Vector3 spawnPosition = spawnPoint.position;
        Vector3 offset = new Vector3(0, 2, 0);

        NoiseMaker = (GameObject)Instantiate(NoiseMakerPrefab, spawnPosition+ offset, Quaternion.identity);
        Destroy(NoiseMaker, DestroyAfter);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CrabArmor")
        {
            NumberOfArmor += 1;
            Destroy(other.gameObject);
            soundFX.Pickup();
        }
    }
    public void SaveArmor()
    {
        if(hasCrabArmor< NumberOfArmor)
        {
            PlayerPrefs.SetInt("hasCrabArmor" + CurrentLevel.ToString(), NumberOfArmor);
            PlayerPrefs.Save();
        }
        
    }
}
