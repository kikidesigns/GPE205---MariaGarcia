using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIController : Controller
{

    // Start is called before the first frame update
    public override void Start()
    {      
        //run parent start
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //make decisions
        MakeDecisions();
        //run parent update
        base.Update();
    }

    public override void ProcessInputs()
    {
        Debug.Log("Processing Inputs?");
    }

    public void MakeDecisions()
    {
        Debug.Log("Making Decisions");
    }
}