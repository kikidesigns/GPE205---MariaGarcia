using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp
{
    //variable to controler how long itt lasts
    public float duration;
    //variable for permanence
    public bool isPermanent;

    public abstract void Apply(PowerUpManager target);
    public abstract void Remove(PowerUpManager target);
}
