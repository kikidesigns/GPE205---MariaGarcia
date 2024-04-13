using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    //store amount of damage it does
    public float damageDone;
    //store pawnw that is responsible for damage done
    public Pawn owner;

    //calledd by rigidbody component when our collider overlaps another collider
    public void OnTriggerEnter(Collider other)
    {
        //get health component frmo game object  that has the collider we are overlapping
        Health otherHealth = other.gameObject.GetComponent<Health>();

        //only damage if it has health component
        if (otherHealth != null) 
        {
            //do damage
            otherHealth.TakeDamage(damageDone, owner);
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
