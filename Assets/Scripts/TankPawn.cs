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
    public float fireRate;
    

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void MoveForward()
    {
        Debug.Log("Move Forward");
        mover.Move(transform.forward, moveSpeed);
    }

    public override void MoveBackward()
    {
        Debug.Log("Move Backward");
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void RotateClockwise()
    {
        Debug.Log("Rotate Clockwise");
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        Debug.Log("Rotate Counter-Clockwise");
        mover.Rotate (-turnSpeed);
    }

    public override void Shoot()
    {
        Debug.Log("Shooted");
        shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);

        
    }

}