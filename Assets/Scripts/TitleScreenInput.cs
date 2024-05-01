using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    private void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Activate the main menu screen
            GameManager.instance.ActivateMainMenuScreen();
        }
    }
}
