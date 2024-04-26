using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthPowerUp : PowerUp
{
    //variable
    public float healthToAdd;
    //variable to hold data for the powerup that our tabks will get
    public HealthPowerUp powerUp;

    //function
    public override void Apply (PowerUpManager target)
    {
        //TODO apply health changes
    }

    //function
    public override void Remove (PowerUpManager target)
    {
        //TODO remove health changes
    }

    //on collision
    public void OnTriggerEnter(Collider other)
    {
        //variable to store objects powerrup controller
        PowerUpManager powerUpManager = other.GetComponent<PowerUpManager>();

        //if it has one
        if(powerUpManager != null) 
        {
            //add the powerup
            powerUpManager.add(powerUp);

            //destroy this pickup
           powerUpManager.Destroy(gameObject);
        }
    }
}
