using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Pawn : MonoBehaviour
{
    // Variable for move speed
    public float moveSpeed;
    // Variable for turn speed
    public float turnSpeed;
    //variable for mover
    public Mover mover;
    //variable to hold our shooter
    public Shooter shooter;
    

    // Start is called before the first frame update
    public virtual void Start()
    {        
        
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();

     //if we have a game manager
        if (GameManager.instance != null)
        {
            //and tracks controller
            if (GameManager.instance.pawns != null)
            {
                //register with gamemanager
                GameManager.instance.pawns.Add(this);
            }
        }
    }

    public void OnDestroy()
    {
        //if we have a  gamemanager
        if(GameManager.instance != null)
        {
            //and it tracks the player
            if(GameManager.instance.pawns != null)
            {
                //deregister with the gamemanager
                GameManager.instance.pawns.Remove(this);
            }
        }
    }
    // Update is called once per frame
    public virtual void Update()
    {       
    }

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void RotateTowards();
    
    //functions to shoot
    public abstract void Shoot();
}