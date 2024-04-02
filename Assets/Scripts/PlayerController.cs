using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;

    // Start is called before the first frame update
    public override void Start()
    {
        // Run the Start() function from the parent (base) class
        base.Start();

                //if we have a game manager
        if (GameManager.instance != null)
        {
            //and tracks players
            if (GameManager.instance.players != null)
            {
                //register with gamemanager
                GameManager.instance.players.Add(this);
            }
        }

    }

    // Update is called once per frame
    public override void Update()
    {   
        // Process our Keyboard Inputs
        ProcessInputs();

        // Run the Update() function from the parent (base) class
        base.Update();        
    }

    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey)) 
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey)) 
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey)) 
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey)) 
        {
            pawn.RotateCounterClockwise();
        }
    }
        public void OnDestroy()
    {
        //if we have a  gamemanager
        if(GameManager.instance != null)
        {
            //and it tracks the player
            if(GameManager.instance.players != null)
            {
                //deregister with the gamemanager
                GameManager.instance.players.Remove(this);
            }
        }
    }
}