using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPickUp : MonoBehaviour
{
    //variable to hold data for the powerup that our tabks will get
    public HealthPowerUp powerUp;

    //audioclip variable
    public AudioClip powerupSound;

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
            // Play the powerup sound using the SFX group
            AudioManager.Instance.PlaySFX(powerupSound);

            //destroy this pickup
           Destroy(gameObject);
        }
    }
}
