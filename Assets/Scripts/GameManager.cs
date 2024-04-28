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
    
    //list that holds players, controllers pawns
    public List<PlayerController> players;
    public List<Controller> controllers;
    public List<Pawn> pawns;
    //list to store pawnspawn point
    public List<PawnSpawnPoint> pawnSpawnPoints;


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

        // Get the CameraFollow component from the main camera
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();

        // Assign the player's tankpawn transform to the CameraFollow target
        cameraFollow.target = newPawnObj.transform;


        //claude's idea 
        //get the tankShooter ocmponent from the instatiated TankPawn
        TankShooter tankShooter = newPawnObj.GetComponent<TankShooter>();
        //create a new game object for the firepoint
        GameObject firePoint = new GameObject("FirePoint");
        //set the position of firepoint relative to the tankpawn
        firePoint.transform.position = newPawnObj.transform.position + new Vector3(0,.6f,1.35f);
        //make the firepoint a child of tankpawn
        firePoint.transform.parent = newPawnObj.transform;
        //assign the firepoints transform to the friepoint transform variable
        tankShooter.firepointTransform = firePoint.transform;


    }
        public void Start()
    {
        //temp code
        SpawnPlayer();


    }


    public void SpawnPawn(GameObject pawnPrefab)
    {
        if (pawnSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, pawnSpawnPoints.Count);
            PawnSpawnPoint randomSpawnPoint = pawnSpawnPoints[randomIndex];

            GameObject newPawn = Instantiate(pawnPrefab, randomSpawnPoint.transform.position, randomSpawnPoint.transform.rotation);
            // Additional setup for the spawned pawn, if needed
        }
        else
        {
            Debug.LogWarning("No spawn points found for pawns.");
        }
    }


}
