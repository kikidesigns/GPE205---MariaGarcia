using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Game States
    public GameObject TitleGameStateObject;
    public GameObject MainMenuGameStateObject;
    public GameObject SettingsGameStateObject;
    public GameObject PlayGameStateObject;
    public GameObject GameOverGameStateObject;
    public GameObject CreditsGameStateObject;

    //audiomanagervariaeble
    private AudioManager audioManager;

    //mapgenerator
    private MapGenerator mapGenerator;

    //spawn transform
    public Transform playerSpawnTransform;

    //prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject aiControllerPrefab;
    public GameObject cameraPrefab;
    public GameObject canvasPrefab;

    
    //list that holds players, controllers pawns
    public List<PlayerController> players;
    public List<Controller> controllers;
    public List<Pawn> pawns;

    //list to store pawnspawn point
    public List<PawnSpawnPoint> pawnSpawnPoints;


    //helper function:
    private void DeactivateAllStates()
    {
        TitleGameStateObject.SetActive(false);
        MainMenuGameStateObject.SetActive(false);
        SettingsGameStateObject.SetActive(false);
        PlayGameStateObject.SetActive(false);
        GameOverGameStateObject.SetActive(false);
        CreditsGameStateObject.SetActive(false);
    }

public void ActivateTitleScreen()
{
    // Deactivate all states
    DeactivateAllStates();
    // Activate the title screen
    TitleGameStateObject.SetActive(true);
    // Do title screen stuff (if any)
}

public void ActivateMainMenuScreen()
{
    // Deactivate all states
    DeactivateAllStates();
    // Activate the main menu screen
    MainMenuGameStateObject.SetActive(true);
    // Do main menu screen stuff (if any)
}

public void ActivateSettingsScreen()
{
    // Deactivate all states
    DeactivateAllStates();
    // Activate the settings screen
    SettingsGameStateObject.SetActive(true);
    // Do settings screen stuff (if any)
}

public void ActivatePlayScreen()
{
    // Deactivate all states
    DeactivateAllStates();
    // Activate the play screen
    PlayGameStateObject.SetActive(true);
    // Do play screen stuff (if any)

    // Clean up existing map and game objects
    CleanupMap();
    
    // Call the GenerateMap function before spawning players
    
    mapGenerator = GetComponent<MapGenerator>();
    mapGenerator.GenerateMap();

    // Reset any game-related values (score, health, lives, etc.)
    ResetGameState();
    //Spawn player and AI
    FindPawnSpawnPoints();

    SpawnPlayer();

    SpawnAIUnits(8);



    // Any additional setup required for the gameplay state
}

public void ActivateGameOverScreen()
{
    // Deactivate all states
    DeactivateAllStates();
    // Activate the game over screen
    GameOverGameStateObject.SetActive(true);
    // Do game over screen stuff (if any)
}

public void ActivateCreditsScreen()
{
    // Deactivate all states
    DeactivateAllStates();
    // Activate the credits screen
    CreditsGameStateObject.SetActive(true);
    // Do credits screen stuff (if any)
}

private void CleanupMap()
{
    // Destroy all existing room game objects
    foreach (Transform child in this.transform)
    {
        Destroy(child.gameObject);
    }

    // Clear the pawnSpawnPoints list
    pawnSpawnPoints.Clear();
}

private void ResetGameState()
{
    // Reset score, health, lives, or any other game state variables
    Debug.Log("Scores RESET");
}

public void QuitGame()
{
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
        Debug.Log("QuitGame");
}



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
        // Initialize the audioManager instance
        audioManager = AudioManager.Instance;
       }
       else 
       {
            //otherwise there is already an instance so destroy this gameobject
            Destroy(gameObject);
       }
    }

        public void Start()
    {
        //start game in correct state
        ActivateTitleScreen();

        // mapGenerator = GetComponent<MapGenerator>();
        // Call the GenerateMap function before spawning players
        // mapGenerator.GenerateMap();

        // FindPawnSpawnPoints();

        // SpawnPlayer();

        // SpawnAIUnits(1);
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

        // Get the PlayerController component from the instantiated game object
        PlayerController playerController = playerControllerObj.GetComponent<PlayerController>();

        // Get the LivesComponent from the PlayerController
        LivesComponent playerLivesComponent = playerController.GetComponent<LivesComponent>();

        //check lives
        if(playerLivesComponent.currentLives > 0 )
        {
            //get a random spawn point
            PawnSpawnPoint spawnPoint = GetRandomSpawnPoint();

            //instantiate the player pawn and connect to controller
            GameObject playerPawnObj = Instantiate(tankPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

            Pawn playerPawn = playerPawnObj.GetComponent<Pawn>();

            //play sound effect
            audioManager.PlaySFX(audioManager.spawnClip);

            Debug.Log("play clip here");

            // Instantiate the camera prefab as a child of the player's pawn
            GameObject cameraObj = Instantiate(cameraPrefab, playerPawnObj.transform.position, playerPawnObj.transform.rotation, playerPawnObj.transform);
            // Set the camera's position relative to the player pawn
            cameraObj.transform.localPosition = new Vector3(0, 2, -5);

            // Instantiate the Canvas prefab as a child of the player's pawn
            GameObject canvasObj = Instantiate(canvasPrefab, playerPawnObj.transform.position, playerPawnObj.transform.rotation, playerPawnObj.transform);

            // Get the Canvas component from the instantiated Canvas prefab
            Canvas canvas = canvasObj.GetComponent<Canvas>();

            // Set the render mode to ScreenSpaceCamera
            canvas.renderMode = RenderMode.ScreenSpaceCamera;

            // Get the Camera component from the instantiated camera object
            Camera playerCamera = cameraObj.GetComponent<Camera>();

            // Assign the player camera to the worldCamera property of the Canvas
            canvas.worldCamera = playerCamera;

            //associate pawn w controller

            playerController.pawn = playerPawn;
            playerPawn.controller = playerController; // Assign the controller to the pawn



            ScoreComponent scoreComponent = playerController.GetComponent<ScoreComponent>();

            // Set the currentScore to zero
            scoreComponent.currentScore = 0;


            // Get all AIController components in the scene
            AIController[] aiControllers = FindObjectsOfType<AIController>();

            // Update the target of each AIController to the newly spawned player's tank pawn
            foreach (AIController aiController in aiControllers)
            {
                aiController.target = playerPawnObj;
            }


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
        else
        {
            // No lives left, handle game over
            //ActivateGameOverScreen();

            Debug.Log("no lives left");
        
            // Destroy the spawned PlayerController since there are no lives left
            Destroy(playerControllerObj);
        }

       




        
        




    }

    public void SpawnAIUnits(int count)
    {
        //get players pawn
        Pawn playerPawn = FindObjectOfType<PlayerController>().pawn;

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

            aiPawn.controller = aiController; // Assign the controller to the pawn

            //set the target for AIcontroller to be playerpawn
            aiController.target = playerPawn.gameObject;

            //testFirepointstuff
            // Set the target for the AI controller to the player's pawn
            aiController.target = playerPawn.gameObject;

            // Create a new game object for the firepoint
            GameObject firePoint = new GameObject("FirePoint");
            // Set the position of firepoint relative to the AI pawn
            firePoint.transform.position = aiPawnObj.transform.position + new Vector3(0, .6f, 1.35f);
            // Make the firepoint a child of the AI pawn
            firePoint.transform.parent = aiPawnObj.transform;
            // Assign the firepoint's transform to the firepoint transform variable
            TankShooter tankShooter = aiPawnObj.GetComponent<TankShooter>();
            tankShooter.firepointTransform = firePoint.transform;



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

        public void PlayerDied()
    {
        // Get the PlayerController component
        PlayerController playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            // Get the LivesComponent from the PlayerController
            LivesComponent livesComponent = playerController.GetComponent<LivesComponent>();

            if (livesComponent != null)
            {
                // Call the loseLife method
                livesComponent.loseLife();

                // Check if the player has any lives remaining
                if (livesComponent.currentLives <= 0)
                {
                    // Player has no lives left, trigger game over
                    ActivateGameOverScreen();
                }
                else
                {
                    // Player still has lives, respawn the player
                    SpawnPlayer();
                }
            }
        }
    }

}
