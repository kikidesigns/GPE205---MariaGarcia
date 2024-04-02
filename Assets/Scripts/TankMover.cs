using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    //Variable for rigidbody component
    private Rigidbody rb;
    //start called before first frame update
    public override void Start()
    {
        //get rigidbody component
        rb = GetComponent<Rigidbody>();
    }
    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);
    }
    public override void Rotate(float rSpeed)
    {
        float modifiedSpeed = rSpeed * Time.deltaTime;
        transform.Rotate(0, modifiedSpeed, 0);
    }
}
