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
    public override void Move(Vector3 direction, float moveSpeed)
    {
        Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);
    }
    public override void Rotate(float rotateSpeed)
    {
        float modifiedSpeed = rotateSpeed * Time.deltaTime;
        transform.Rotate(0, modifiedSpeed, 0);
    }
}
