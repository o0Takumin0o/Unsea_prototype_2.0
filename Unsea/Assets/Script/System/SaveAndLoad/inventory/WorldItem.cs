using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    private ItemDatabase database;
    private CollectibleItemSet collectibleItemSet;
    private UniqueID uniqueID;
    [SerializeField]
    float height = 1f;

    [SerializeField]
    float period = 1;

    private Vector3 initialPosition;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        uniqueID = GetComponent<UniqueID>();
        database = FindObjectOfType<ItemDatabase>();
        collectibleItemSet = FindObjectOfType<CollectibleItemSet>();
        if (collectibleItemSet.CollectedItems.Contains(uniqueID.ID))
        {
            Destroy(this.gameObject);
            return;
        }
        initialPosition = transform.position;

        offset = 1 - (Random.value * 2);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectibleItemSet.CollectedItems.Add(uniqueID.ID);
            other.GetComponent<Inventory>().AddItem(itemName);
            
            //Destroy(gameObject);
        }
    }

    public GameObject DestroyParticle;
    float speed = 2.0f;

    void Update()
    {//transform.Rotate(speed, speed, speed);
        transform.Rotate(0, speed, 0);
        transform.position = initialPosition - Vector3.up * Mathf.Sin((Time.time + offset) * period) * height;
    }

    public void OnDestroy()
    {
        GameObject DestroyEffect = (GameObject)Instantiate(DestroyParticle, transform.position, Quaternion.identity);
        Destroy(DestroyEffect, 3f);
    }
}
