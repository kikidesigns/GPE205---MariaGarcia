using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{

    //variable for shell prefab
    public GameObject shellPrefab;
    //variable for firing force
    public float fireForce;
    //variable for damage done
    public float damageDone;
    // variable fro how long bullets survive if they dont collide
    public float shellLifespan;
    //variable for rate of fire
    public float shotsPerSecond;
    //variable for countdown current
    private float timeUntilNextShot;
    //variable for countdown amount
    private float secondsBetweenShots;
    

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        //convert shotsPerSecond to time between shots
        secondsBetweenShots = 1F /shotsPerSecond;
        timeUntilNextShot = Time.time + secondsBetweenShots;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void MoveForward()
    {
        mover.Move(transform.forward, moveSpeed);
    }

    public override void MoveBackward()
    {
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate (-turnSpeed);
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        Debug.Log("Rotate Towards Target");
        //find the vector to our target
        Vector3 vectorToTarget = targetPosition - transform.position;
        //find the rotation to look down tht vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget,Vector3.up);
        //rotate towards vector as fast as turn speed allows in one frame
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    public override void Shoot()
    {

        if (Time.time >= timeUntilNextShot)
        {
            //shoot
            Debug.Log("Shooted");
            shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);

            //calculate next time you can shoot
            timeUntilNextShot = Time.time + secondsBetweenShots;
        }
        else
        {
            Debug.Log("Not ready yet");
        }

       
        

        
    }

}