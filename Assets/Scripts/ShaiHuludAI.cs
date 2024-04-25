using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaiHuludAI : AIController
{


    private float restTimer = 0f;

    public float restTime = 13f;

    public bool hasInteractedWithSandRim = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        ChangeState(AIState.GuardDesert);
    }
    
    // switch case for states
    public override void MakeDecisions()
    {
        switch (currentState)
        {
            //wormrest
            case AIState.WormRest:
            DoWormRestState();

            //add timer transition
            if (hasInteractedWithSandRim)
            {
                if (restTimer>=restTime)
                {
                    ChangeState(AIState.GuardDesert);
                    restTimer=0f;
                    hasInteractedWithSandRim=false;
                }
                else{
                    restTimer+= Time.deltaTime;
                }
            }

            break;

            //guard desert
            case AIState.GuardDesert:
            DoGuardDesertState();

            //add has target transition
            if (canHear())
            {
                ChangeState(AIState.WormAttack);
            }

            break;

            //worm attack
            case AIState.WormAttack:
            DoWormAttackState();
            if (hasInteractedWithSandRim)
            {
                ChangeState(AIState.WormRest);
            }
           

            break;

        }
    }

    // state methods

    //perform Worm Rest Actions
    protected override void DoWormRestState()
    {
    Debug.Log("The Sandworm has left... for now...");
    }
    //perform Guard Desert Actions
    protected override void DoGuardDesertState()
    {
    Debug.Log("A sandworm is listening");
    }

    //perform Worm Attack Actions
    protected override void DoWormAttackState()
    {
    Debug.Log("A sandworm is moving toward the loudest spice mine and consuming all in its path");
    }

    //action mathods

    //invisible
    //idle
    //move forward
    //consumeEverything
    //visible
    //interactWithSandRim


    //transition methods


    // public bool canHear()
    // {
    //     //logic to see if hsia hulud can hear a loud spice mine
    //     return false; //placeholder
    // }
}
