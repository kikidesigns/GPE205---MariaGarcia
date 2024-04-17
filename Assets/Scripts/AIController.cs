using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIController : Controller
{
    //variable to hold target
    public GameObject target;
    //variable to hold state changes
    private float lastStateChangeTime;

    //define enum
    public enum AIState { Idle, GuardDesert, WormAttack, WormRest, GuardSpice, Defend, Scan, Chase, Attack, Flee, BackToPost, Steal, Mine};

    //create a variable of this enum type
    public AIState currentState;

    // Start is called before the first frame update
    public override void Start()
    {      
        //run parent start
        base.Start();
        ChangeState(AIState.Idle);
    }

    // Update is called once per frame
    public override void Update()
    {
        //make decisions
        MakeDecisions();
        //check transitions
        CheckTransitions();
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
            //Idle
            case AIState.Idle:
            Debug.Log("Idling");
            DoIdleState();
            break;
            //GuardDesert
            case AIState.GuardDesert:
            Debug.Log("A Sandworm is out there listening");
            DoGuardDesertState();
            break;
            //WormAttack
            case AIState.WormAttack:
            Debug.Log("A Sandworm is coming");
            DoWormAttackState();
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
            case AIState.MineSpice:
            Debug.Log("Mining spice");
            break;

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
    
    protected void DoIdleState()
    {
        //Do Nothing
    }

    protected void DoGuardDesertState()
    {
        //invisible
    }

    protected void DoWormAttackState()
    {
        //rotate in direction of loudest spice mining
        //move forward
        //eat any tank/spice on collision
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

    protected bool canHear ()
    {

    }


    //Check Transitions
    protected void CheckTransitions()
    {
        switch(currentState)
        {
            case AIState.Idle:
                //check consdition to transition form idle state
                if (isDistanceLessThan)
                {
                    ChangeState(AIState.GuardDesert);
                }
                break;
            case AIState.GuardDesert:
                //check consdition to transition form guard state
                if(canHear)
                {
                    ChangeState(AIState.WormAttack);
                }
                break;

        }
    }
}