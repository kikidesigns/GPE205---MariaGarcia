using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerScript : MonoBehaviour
{
    //variable to hold pawn
    public Pawn pawn;
    // Start is called before the first frame update
    ublic virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    //child classes must override input processing
    public abstract void ProcessInputs();
}
