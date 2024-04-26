using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthPowerUp : PowerUp
{
    //variable
    public float healthToAdd;


    //function
    public override void Apply (PowerUpManager target)
    {
        //TODO apply health changes
        Health targetHealth = target.GetComponent<Health>();
        if(targetHealth != null)
        {
            //the second parameterr is ht eoawn who caused the healing, in this case it is themselves
            targetHealth.Heal(healthToAdd, target.GetComponent<Pawn>());
            
            Debug.Log("Healed");
        }
    }

    //function
    public override void Remove (PowerUpManager target)
    {
        //TODO remove health changes
    }

}
