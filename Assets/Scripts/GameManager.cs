using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //spawn transform
    public Transform playerSpawnTransform;

    //prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    
    //list that holds players
    public List<PlayerController> players;
    public List<Controller> controllers;
    public List<Pawn> pawns;


    // awake is called before start can run
    private void Awake()
    {
       //if the instance doesnt exist yet
       if(instance == null)
       {
        //this is the instance
        instance = this;
        //dont destroy it if we load a new scene
        DontDestroyOnLoad (gameObject);
       }
       else 
       {
            //otherwise there is already an instance so destroy this gameobject
            Destroy(gameObject);
       }
    }



    public void SpawnPlayer()
    {
        //spawn player at 000 no rotation
        
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //spawn pawn and connect to controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        //get player component and pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //hook them up
        newController.pawn = newPawn;
    }
        public void Start()
    {
        //temp code
        SpawnPlayer();


    }


}
