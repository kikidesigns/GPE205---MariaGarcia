using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTester : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        CheckKeyPresses();
    }

    private void CheckKeyPresses()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameManager.ActivateTitleScreen();
            Debug.Log("Activated TitleScreen state");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameManager.ActivateMainMenuScreen();
            Debug.Log("Activated MainMenuScreen state");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameManager.ActivateSettingsScreen();
            Debug.Log("Activated SettingsScreen state");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gameManager.ActivatePlayScreen();
            Debug.Log("Activated PlayScreen state");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            gameManager.ActivateGameOverScreen();
            Debug.Log("Activated GameOverScreen state");
        }
        
    }
}

