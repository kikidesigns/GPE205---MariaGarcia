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
    public GameObject aiControllerPrefab;
    
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

        public void Start()
    {
        FindPawnSpawnPoints();

        SpawnPlayer();

        SpawnAIUnits(2);
    }


        private void FindPawnSpawnPoints()
    {
        pawnSpawnPoints.Clear(); // Clear the list first

        // Find all PawnSpawnPoint components in the scene
        PawnSpawnPoint[] spawnPoints = FindObjectsOfType<PawnSpawnPoint>();

        // Add each PawnSpawnPoint to the list
        foreach (PawnSpawnPoint spawnPoint in spawnPoints)
        {
            pawnSpawnPoints.Add(spawnPoint);
        }
    }



    private PawnSpawnPoint GetRandomSpawnPoint()
    {
        if (pawnSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, pawnSpawnPoints.Count);
            return pawnSpawnPoints[randomIndex];
        }
        else
        {
            Debug.LogWarning("No spawn points found for pawns.");
            return null;
        }
    }


    public void SpawnPlayer()
    {

        //spawn player at 000 no rotation
        
        GameObject playerControllerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //claude added this line
        PlayerController playerController = playerControllerObj.GetComponent<PlayerController>();

        //get a random spawn point
        PawnSpawnPoint spawnPoint = GetRandomSpawnPoint();

        //spawn pawn and connect to controller
        GameObject playerPawnObj = Instantiate(tankPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        Pawn playerPawn = playerPawnObj.GetComponent<Pawn>();

        //associate pawn w controller

        playerController.pawn = playerPawn;


        // Get the CameraFollow component from the main camera
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();

        // Assign the player's tankpawn transform to the CameraFollow target
        cameraFollow.target = playerPawnObj.transform;


        // Claude's idea
        // Get the tankShooter component from the instantiated TankPawn
        TankShooter tankShooter = playerPawnObj.GetComponent<TankShooter>();
        // Create a new game object for the firepoint
        GameObject firePoint = new GameObject("FirePoint");
        // Set the position of firepoint relative to the tankpawn
        firePoint.transform.position = playerPawnObj.transform.position + new Vector3(0, .6f, 1.35f);
        // Make the firepoint a child of tankpawn
        firePoint.transform.parent = playerPawnObj.transform;
        // Assign the firepoint's transform to the firepoint transform variable
        tankShooter.firepointTransform = firePoint.transform;


    }

    public void SpawnAIUnits(int count)
    {
        for (int i = 0; i < count; i++)
        {
            //instantiate AI controller
            GameObject aiControllerObj = Instantiate(aiControllerPrefab, Vector3.zero,Quaternion.identity);
            AIController aiController = aiControllerObj.GetComponent<AIController>();
            //get random spawn point
            PawnSpawnPoint spawnPoint = GetRandomSpawnPoint();
            //instantiate the AI pawn
            GameObject aiPawnObj = Instantiate (tankPawnPrefab, spawnPoint.transform.position,spawnPoint.transform.rotation);
            Pawn aiPawn = aiPawnObj.GetComponent<Pawn>();

            //associate pawn w controller
            aiController.pawn = aiPawn;

            //Pass any additional data from the soawn opint  to the ai controlelr
            aiController.SetupFromSpawnPoint(spawnPoint);
        }
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
