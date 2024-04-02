using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Controller : MonoBehaviour
{
    // Variable to hold our Pawn
    public Pawn pawn;

    // Start is called before the first frame update
    public virtual void Start()
    {      
      //if we have a game manager
        if (GameManager.instance != null)
        {
            //and tracks controller
            if (GameManager.instance.controllers != null)
            {
                //register with gamemanager
                GameManager.instance.controllers.Add(this);
            }
        }
    }
    // Update is called once per frame
    public virtual void Update()
    {
    }
    // Our child classes MUST override the way they process inputs
    public abstract void ProcessInputs();

    public void OnDestroy()
    {
        //if we have a  gamemanager
        if(GameManager.instance != null)
        {
            //and it tracks the player
            if(GameManager.instance.controllers != null)
            {
                //deregister with the gamemanager
                GameManager.instance.controllers.Remove(this);
            }
        }
    }
}