using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPowerUp : PowerUp
{
    public float speedBoost;
    public float expirationTime; // Time in seconds after which the power-up will expire

    private TankPawn targetTankPawn;
    private float startTime;

    public override void Apply(PowerUpManager target)
    {
        targetTankPawn = target.GetComponent<TankPawn>();
        if (targetTankPawn != null)
        {
            targetTankPawn.BoostSpeed(speedBoost, targetTankPawn);
            Debug.Log("Zoom Zoom");

            startTime = Time.time;
            targetPowerUpManager = target; // Assign the PowerUpManager instance here

            if (expirationTime > 0f)
            {
                target.StartCoroutine(ExpirationTimer());
            }
        }
    }

    public override void Remove(PowerUpManager target)
    {
        if (targetTankPawn != null)
        {
            targetTankPawn.ResetSpeed(); // Assuming you've implemented the ResetSpeed method in the TankPawn class
            targetTankPawn = null;
        }
    }

    private IEnumerator ExpirationTimer()
    {
        yield return new WaitForSeconds(expirationTime);
        Remove(targetPowerUpManager); // Use the targetPowerUpManager variable here
    }
}
