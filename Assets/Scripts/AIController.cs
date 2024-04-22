using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIController : Controller
{
    //variable to normalize fleedistance
    public float runAwayDistance;
    //variable to hold target
    public GameObject target;
    //variable to hold state changes
    private float lastStateChangeTime;

    //define enum
    public enum AIState { Seek, GuardDesert, WormAttack, WormRest, GuardSpice, Defend, Scan, Chase, Attack, Flee, BackToPost, Steal, Mine};

    //create a variable of this enum type
    public AIState currentState;

    // Start is called before the first frame update
    public override void Start()
    {      
        //run parent start
        base.Start();
        ChangeState(AIState.GuardDesert);
    }

    // Update is called once per frame
    public override void Update()
    {
        //make decisions
        MakeDecisions();
        //check transitions
        // CheckTransitions();
        //run parent update
        base.Update();
    }

    public override void ProcessInputs()
    {
        Debug.Log("Processing Inputs?");
    }


    //
    public void MakeDecisions()
    {
        Debug.Log("Making Decisions");

        // switch/case decision structure
        switch (currentState) 
        {
            //Seek
            case AIState.Seek:
            Debug.Log("Seeking");
            DoSeekState();
            //check for transition
            break;
            //GuardDesert
            case AIState.GuardDesert:
            Debug.Log("A Sandworm is out there listening");
            DoGuardDesertState();
            //check for transition
            if (isDistanceLessThan(target, 5))
            {
                ChangeState(AIState.WormAttack);
            }
            break;
            //WormAttack
            case AIState.WormAttack:
            Debug.Log("A Sandworm is coming");
            DoWormAttackState();
            //check for transition
            if(!isDistanceLessThan(target,5))
            {
                ChangeState(AIState.GuardDesert);
            }
            break;
            //WormRest
            case AIState.WormRest:
            Debug.Log("The Sandworm has left");
            break;
            //GuardSpice 
            case AIState.GuardSpice:
            Debug.Log("Guarding spice");
            break;
            //Defend
            case AIState.Defend:
            Debug.Log("Self defense");
            break;
            //Scan
            case AIState.Scan:
            Debug.Log("Scanning perimeter");
            break;
            //Chase
            case AIState.Chase:
            Debug.Log("Chasing Fremen");
            break;
            //Attack
            case AIState.Attack:
            Debug.Log("Attacking Fremen");
            break;
            //Flee
            case AIState.Flee:
            Debug.Log("Fly away from Sandworm");
            break;
            //BackToPost
            case AIState.BackToPost:
            Debug.Log("Going back to base");
            break;
            //Steal
            case AIState.Steal:
            Debug.Log("Stealing spice");
            break;
            //Mine
            // case AIState.MineSpice:
            // Debug.Log("Mining spice");
            // break;

        }
    }

   
    public virtual void ChangeState (AIState newState)
    {
        //change the current state
        currentState = newState;
        //save the time we changed states
        lastStateChangeTime = Time.time;
    }


    //States: Idle, GuardDesert, WormAttack, WormRest, GuardSpice, Defend, Scan, Chase, Attack, Flee, BackToPost, Steal, Mine
    
    protected void DoSeekState()
    {
        //Seek Test
        Seek(target);
    }

    protected virtual void DoGuardDesertState()
    {
        //invisible
        Debug.Log("A worm is listening...");
    }

    protected virtual void DoWormAttackState()
    {
        //rotate in direction of loudest spice mining
        //move forward
        Seek (target);
        //eat any tank/spice on collision
        Shoot();
    }
    
    protected virtual void DoFleeState()
    {
        //run away
        RunAway();
    }


    //Action Methods: Nothing, Invisible, RotateToEnemy, MoveForward, Eat, Visible...

    public void Invisible()
    {
        //set visibility to negative
    }

    public void RotateToEnemy()
    {
        //rotate to enemy
    }

    public void Seek (GameObject target)
    {
        //rotate towards
        pawn.RotateTowards(target.transform.position);
        //move froward
        pawn.MoveForward();
    }
    //overloading "seek"
    public void Seek (Vector3 targetPosition)
    {
        //rotate towards
        pawn.RotateTowards(targetPosition);
        //move froward
        pawn.MoveForward();
    }
    public void Seek(Transform targetTransform)
    {
        //seek position of target transform
        Seek (targetTransform.position);
    }
    public void Seek(Pawn targetPawn)
    {
        //seeek pawn's transform
        Seek(targetPawn.transform);
    }

    public void Seek(Controller targetController)
    {
        //seek controllers pawn
        Seek(targetController.pawn);
    }

    public void Shoot()
    {
        //tell pawn to shoot
        pawn.Shoot();
    }

    public void RunAway()
    {
        //find vector that points to our target
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        //reverse the direction
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        //normalize it
        Vector3 runAwayVector = vectorAwayFromTarget.normalized * runAwayDistance;
        //seek the point that is "runawayvector" away from our current position
        Seek(pawn.transform.position + runAwayVector);
    }


    //Transition Methods: isDistanceLessThan...

    protected bool isDistanceLessThan(GameObject target, float distance)
    {
        if(Vector3.Distance (pawn.transform.position,target.transform.position) < distance )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // protected bool canHear ()
    // {

    // }


    //Check Transitions
    // protected void CheckTransitions()
    // {
    //     switch(currentState)
    //     {
    //         case AIState.Idle:
    //             //check consdition to transition form idle state
    //             if (isDistanceLessThan)
    //             {
    //                 ChangeState(AIState.GuardDesert);
    //             }
    //             break;
    //         case AIState.GuardDesert:
    //             //check consdition to transition form guard state
    //             if(canHear)
    //             {
    //                 ChangeState(AIState.WormAttack);
    //             }
    //             break;

    //     }
    // }
}