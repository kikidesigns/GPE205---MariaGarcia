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
        //TODO apply SCORE changes
        ScoreComponent targetScore = target.GetComponent<ScoreComponent>();
        if (targetScore != null)
        {
            Debug.Log("Here");
            
            targetScore.AddToScore(scoreToAdd);
            Debug.Log("score powerup");
        }
        else
        {
            Debug.Log("no targetscore");
        }
    }


    //function
    public override void Remove(PowerUpManager target)
    {
        //TODO remove SCORE changes
    }
}
