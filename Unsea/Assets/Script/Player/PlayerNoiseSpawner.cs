using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNoiseSpawner : MonoBehaviour
{
    public GameObject NoiseMakerPrefab;
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
        //NumberOfArmor = 0;
        NumberOfArmor = PlayerPrefs.GetInt("hasCrabArmor" + CurrentLevel.ToString());
        CrabArmor.SetActive(false);
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnNoiseMaker();
        }*/
        Powerunlock();
    }
    void Powerunlock()
    {
        if (NumberOfArmor == 1)
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
        }
    }
    public void SaveArmor()
    {
        PlayerPrefs.SetInt("hasCrabArmor" + CurrentLevel.ToString(), NumberOfArmor);
        PlayerPrefs.Save();
    }
}
