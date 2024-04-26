using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public List<PowerUp> powerUps;
    private List<PowerUp> removedPowerUpQueue;

    // Start is called before the first frame update
    void Start()
    {
        //initialize lists
        powerUps = new List<PowerUp>();
        removedPowerUpQueue = new List<PowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerUpTimers();
    }

    public void DecrementPowerUpTimers()
    {
        //one at a time put eachc obj in powerups into the variebl powerup and the loop body on it
        foreach(PowerUp powerUp in powerUps)
            {
                //subtract time it took to draw frame from the duration
                powerUp.duration -= Time.deltaTime;
                //if time is up remove powerup
                if (powerUp.duration <= 0)
                {
                    Remove(powerUp);
                }
            }
        }
    
    //the add function will eventually add a powerup
    public void Add(PowerUp powerUpToAdd)
    {
        //TODO create the add method
        powerUpToAdd.Apply(this);
        //save it to the list
        powerUps.Add(powerUpToAdd);
    }

    //the remove function will eventually remove a powerup
    private void Remove(PowerUp powerUpToRemove)
    {
        powerUpToRemove.Remove(this);
        removedPowerUpQueue.Add(powerUpToRemove);
    }



    private void ApplyRemovePowerUpsQueue()
    {
        // Now that we are sure we are not iterating through "powerups", remove the powerups that are in our temporary list
        foreach (PowerUp powerUp in removedPowerUpQueue) 
        {
            powerUps.Remove(powerUp);
        }
        // And reset our temporary list
        removedPowerUpQueue.Clear();
    }

    private void LateUpdate()
    {
        ApplyRemovePowerUpsQueue();
    }

}
