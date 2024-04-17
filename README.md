# GPE205 - MariaGarcia

# Simple Tank Game Documentation

This project is building a tank game as a programming class assignment. At the moment, the documentation entails the Finite State Machines (FSM) of the four planned AIControllers namely: Shai Hulud, Harkonnen, Sardaukar, and Smuggler.

## Shai Hulud AIController 

Shai Hulud AIController operates in a loose sand environment with restricted navigation only in one direction. It consumes everything along its path and alternates between three different states:

**Asleep:** This is the initial state where Shai Hulud is invisible (utilizes idle functions), appearing as if not present in the game.
**Attack:** Triggered by the presence of sound which implies a potential target. Shai Hulud will proceed towards the sound direction (move forward function), consuming everything along the path (eat function) and becomes visible.
**Rest:** Shai Hulud reverts to being invisible (invisible function) after interacting with any loose sand's rim edge. After a preset time elapsed, it transitions back to the Asleep state.

## Harkonnen AIController 

The Harkonnen AIController is primarily tasked with mining spice from a stationary post. Its sluggishness tells in its steady reaction to events. The seven states of the Harkonnen are:

**Guard:** This is the initial state of a Harkonnen while mining spice (MineSpice function).
**LazyAttack:** This state is triggered upon sighting smugglers where Harkonnen reacts by shooting (Shoot function).
**Chase:** If there are Fremen around, Harkonnen moves to this state and attempts to pursue them (SeekFremen function).
**Attack:** Within a certain proximity to the Fremen, Harkonnen enters the Attack state combining increased velocity( double speed function) to seek the Fremen{ SeekFremen function) and increased rate of shooting (ShootALot function).
**Flee:** The sight of Shai Hulud causes Harkonnen to quickly pack up the mining rig (PackUpMiningRig function) and fly away (FlyAway function).
**Back2Post:** After Shai Hulud is gone or the Fremen is at a safe distance, Harkonnen gets back to the post to continue with the initial task of mining (SeekPost function).

## Smuggler AIController 

## Sardaukar AIController 

## Diagrams 



## Planned AIControllers

The project is in progress and the FSM for Sardaukar and Smuggler AIControllers will be updated soon in the future versions.
