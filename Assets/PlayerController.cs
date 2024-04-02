using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
   

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
    public override void ProcessInputs()
    {
        if (Input.GetKey(moveforwardKey))
        {
            pawn.MoveForward();
        }
        if(Input.GetKey(moveBackwardKey)
        {
            pawn.MoveBackward();
        })
        if(Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }
        If(Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
    }
}
