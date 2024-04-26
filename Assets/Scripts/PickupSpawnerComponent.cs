using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnerComponent : MonoBehaviour
{
    //variables to hold pickup prefab
    public GameObject pickUpPrefab;
    //varible to gold delay between spawns
    public float spawnDelay;
    //variable fornext spawn
    public float nextSpawnTime;
    //variable for our transofrm
    private Transform tf;
    //store pickup gameobject we are instantiating
    private GameObject spawnedPickup;



    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time +spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //if it is there nothing spanws
        if (spawnedPickup == null)
        {
            //if its time to spawn a pickup
            if (Time.time > nextSpawnTime)
            {
                //spawn and set next tiem
                Instantiate (pickUpPrefab, Transform.position, Quaternion.identity);
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            //otherwise object still exists so postpone spawn
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
