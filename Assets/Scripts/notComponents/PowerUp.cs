using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp
{
    public abstract void Apply(PowerUpManager target);
    public abstract void Remove(PowerUpManager target);
}
