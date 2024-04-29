using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LandMinePowerUp : PowerUp
{
    //variable
    public float damageToTake;


    //function
    public override void Apply (PowerUpManager target)
    {
        //TODO apply health changes
        Health targetHealth = target.GetComponent<Health>();
        if(targetHealth != null)
        {
            //the second parameterr is ht eoawn who caused the damage, in this case it is themselves
            targetHealth.TakeDamage(damageToTake, target.GetComponent<Pawn>());
            
            Debug.Log("LandMine");
        }
    }

        //function
    public override void Remove (PowerUpManager target)
    {
        //TODO remove damage changes
    }
}
