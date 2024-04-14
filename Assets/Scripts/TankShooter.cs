using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    //declare firepointTransform variable
    public Transform firepointTransform;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    //shoot function
    public override void Shoot (GameObject shellPrefab, float fireForce, float damageDone, float lifespan)
    {
        //instantiate projectile
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;

        //get DamageOnHit component
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();
        //if it has one
        if(doh != null)
        {
            //set the damageDone in DamageOnHit component to the value passed in
            doh.damageDone = damageDone;
            //set the owner to th epawn that shot this shell, if there is one
            doh.owner = GetComponent<Pawn>();

        }
        //get the rigidbody component
        Rigidbody rb= newShell.GetComponent<Rigidbody>();
        //if it has one
        if (rb != null)
        {
            //addforce to make it move forward
            rb.AddForce(firepointTransform.forward * fireForce);
        }
        //destroy it after a set time
        Destroy(newShell, lifespan);
    }
}
