using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarkonnenAIController : AIController
{
    public float detectFremenRange = 10f; // Range to detect Fremen
    public float attackFremenRange = 5f; // Range to attack Fremen
    public float fleeRange = 20f; // Range to flee from Shai Hulud

    private Transform postTransform; // Reference to the spice mining post
    private GameObject closestFremen; // Closest Fremen detected
    private GameObject shaiHulud; // Reference to Shai Hulud

    public override void Start()
    {
        base.Start();
        ChangeState(AIState.GuardSpice); // Start in the GuardSpice state
    }

    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AIState.GuardSpice:
                DoGuardSpiceState();
                if (canHear())
                {
                    ChangeState(AIState.Scan);
                }
                else if (DetectShaiHulud())
                {
                    ChangeState(AIState.Flee);
                }
                break;

            case AIState.Defend:
                DoDefendState();

                break;
            
            case AIState.Scan:
                DoScanState();

                break;

            case AIState.Chase:
                DoChaseState();
                if (IsFremenInAttackRange())
                {
                    ChangeState(AIState.Attack);
                }
                else if (DetectShaiHulud())
                {
                    ChangeState(AIState.Flee);
                }
                break;

            case AIState.Attack:
                DoAttackState();
                if (!IsFremenInAttackRange())
                {
                    ChangeState(AIState.Chase);
                }
                else if (DetectShaiHulud())
                {
                    ChangeState(AIState.Flee);
                }
                break;

            case AIState.Flee:
                DoFleeState();
                if (!DetectShaiHulud())
                {
                    ChangeState(AIState.BackToPost);
                }
                break;

            case AIState.BackToPost:
                DoBackToPostState();
                if (IsAtPost())
                {
                    ChangeState(AIState.GuardSpice);
                }
                break;
        }
    }


    //state methods

    protected void DoGuardSpiceState()
    {
        MineSpice(); // Implement the MineSpice function
    }

    protected void DoDefendState()
    {
        Shoot(closestFremen); // Implement the Shoot function
    }

    protected void DoChaseState()
    {
        Seek(target); // Implement the SeekFremen function
    }

    protected void DoAttackState()
    {
        DoubleSpeed(); // Implement the DoubleSpeed function
        SeekFremen(target); // Implement the SeekFremen function
        ShootALot(target); // Implement the ShootALot function
    }

    protected override void DoFleeState()
    {
        PackUpMiningRig(); // Implement the PackUpMiningRig function
        FlyAway(shaiHulud); // Implement the FlyAway function
    }

    protected void DoBackToPostState()
    {
        SeekPost(postTransform); // Implement the SeekPost function
    }

    protected override void DoScanState()
    {
        rotateClockwise();
    }
    // Placeholder action methods

    private void MineSpice() 
    {
        
    }
    private void Shoot(GameObject target)
    { 

    }
    private void SeekFremen(GameObject target) 
    { 

    }
    private void DoubleSpeed() 
    { 

    }
    private void ShootALot(GameObject target) 
    { 

    }
    private void PackUpMiningRig() 
    { 

    }
    private void FlyAway(GameObject target) 
    { 

    }
    private void SeekPost(Transform postTransform) 
    { 

    }


    //transition methods

    private bool DetectFremen()
    {
        // Implement logic to detect Fremen within detectFremenRange
        // Update closestFremen variable
        return false; // Placeholder
    }

    private bool IsFremenInAttackRange()
    {
        // Implement logic to check if closestFremen is within attackFremenRange
        return false; // Placeholder
    }

    private bool DetectShaiHulud()
    {
        // Implement logic to detect Shai Hulud within fleeRange
        // Update shaiHulud variable
        return false; // Placeholder
    }

    private bool IsAtPost()
    {
        // Implement logic to check if Harkonnen is at the spice mining post
        return false; // Placeholder
    }

    //     public bool canHear()
    // {
    //     //logic to see if hsia hulud can hear a loud spice mine
    //     return false; //placeholder
    // }

}
