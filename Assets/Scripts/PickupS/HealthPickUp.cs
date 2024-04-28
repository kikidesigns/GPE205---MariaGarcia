using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPickUp : MonoBehaviour
{
    //variable to hold data for the powerup that our tabks will get
    public HealthPowerUp powerUp;

    //on collision
    public void OnTriggerEnter(Collider other)
    {
        //variable to store objects powerrup controller
        PowerUpManager powerUpManager = other.GetComponent<PowerUpManager>();

        //if it has one
        if(powerUpManager != null) 
        {
            //add the powerup
            powerUpManager.Add(powerUp);

            //destroy this pickup
           Destroy(gameObject);
        }
    }
}