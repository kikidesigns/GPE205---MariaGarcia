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
    public enum AIState { ChooseTarget, Seek, GuardDesert, WormAttack, WormRest, GuardSpice, Defend, Scan, Chase, Attack, Flee, BackToPost, Steal, Mine};

    //create a variable of this enum type
    public AIState currentState;

    // Start is called before the first frame update
    public override void Start()
    {      
         if (GameManager.instance != null)
        {
            //and tracks players
            if (GameManager.instance.controllers != null)
            {
                //register with gamemanager
                GameManager.instance.controllers.Add(this);
            }
        }
        //run parent start
        base.Start();

        ChangeState(AIState.Seek);
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

    //finds the first players pawn as target
    public void TargetPlayerOne()
    {
        //if game manager exists
        if (GameManager.instance != null)
        {
            //and the array of players exists
            if(GameManager.instance.players != null)
            {
                //and there are players in it
                if(GameManager.instance.players.Count > 0 )
                {
                    //then target the gameobject of the pawn of the first player controller on the list
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }
    
    protected bool isHasTarget()
    {
        //return true if we have a target
        return(target != null);
    }


    public virtual void MakeDecisions()
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
            DoFleeState();
            break;
            //BackToPost
            case AIState.BackToPost:
            Debug.Log("Going back to base");
            break;
            //Steal
            case AIState.Steal:
            Debug.Log("Stealing spice");
            break;
            //choose target
            case AIState.ChooseTarget:
            Debug.Log("Choosing target");
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

    protected virtual void DoWormRestState()
    {
        Debug.Log("the worm has left... for now...");
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

    protected virtual void DoScanState()
    {
        //rotate clockwise
        rotateClockwise();
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

    public void rotateClockwise()
    {
        Debug.Log("rotating clockwise");
    }

    public void RunAway()
    {
        //find vector that points to our target
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        //reverse the direction
        Vector3 vectorAwayFromTarget = -vectorToTarget;

        //find distance the target is from player
        float targetDistance = Vector3.Distance (target.transform.position, pawn.transform.position);
        //find percent of runAwayDistance
        float percentOfRunAwayDistance = targetDistance / runAwayDistance;
        //clmap between 0 and 1
        percentOfRunAwayDistance = Mathf.Clamp01(percentOfRunAwayDistance);
        //invert
        float flippedPercentOfRunAwayDistance = 1-percentOfRunAwayDistance;

        //clculate flee magnitude based on inverted percentage
        float runAwayVectorMagnitude= flippedPercentOfRunAwayDistance * runAwayDistance;
        //ai flees at least 1 unit away
        runAwayVectorMagnitude = Mathf.Max(runAwayVectorMagnitude,1f);

        //final flee vector
        Vector3 runAwayVector = vectorAwayFromTarget.normalized * runAwayVectorMagnitude;
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

    public bool canHear ()
    {
       //get the targets noisemaker
       NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
       
       //if they dont have one they cant make noise return false
       if (noiseMaker ==null)
       {
        return false;
       }
       //if they are making  noise they cant be heard
       if (noiseMaker.volumeDistance <=0)
       {
        return false;
       }
       //if they are making noise add the volumedistance to thehearing distance
       float totalDistance = noiseMaker.volumeDistance + hearingDistance;
       //if the distance between pawn and target is colser than this
       if (Vector3.Distance(pawn.transform.position,target.transform.position)<=totalDistance)
       {
        //then we can hear the target
        return true;
       }
       else{
        //otherwise were too far
        return false;
       }
    }


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