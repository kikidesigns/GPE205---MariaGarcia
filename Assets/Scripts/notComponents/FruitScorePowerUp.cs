using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FruitScorePowerUp : PowerUp
{
    //variable
    public float scoreToAdd;

    //function
    public override void Apply(PowerUpManager target)
    {
        Debug.Log("FRUITPOWERAPPLY");

        // Get the associated controller from the PowerUpManager
        Controller controller = target.GetComponent<Pawn>().controller;
        
        if (controller != null)
        {
            // Get the ScoreComponent from the associated controller
            ScoreComponent scoreComponent = controller.GetComponent<ScoreComponent>();
            if (scoreComponent != null)
            {
                Debug.Log("Here");
                
                scoreComponent.AddToScore(scoreToAdd);
                Debug.Log("Score power-up applied.");
            }
            else
            {
                Debug.Log("no targetscore");
            }
        }

    }


    //function
    public override void Remove(PowerUpManager target)
    {
        //TODO remove SCORE changes
    }
}
