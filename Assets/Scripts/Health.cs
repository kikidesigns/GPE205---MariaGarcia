using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        //set health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float damageAmount, Pawn source)
    {
        currentHealth = currentHealth - damageAmount;
        currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
        Debug.Log(source.name + "did" + damageAmount + "damage to" + gameObject.name);
        if (currentHealth <= 0)
        {
            Die(source);
        }
    }

    public void Die (Pawn source)
    {
        Debug.Log("Dead");
        Destroy (gameObject);
    }

    public void Heal (float healAmount, Pawn source)
    {
        currentHealth = currentHealth + healAmount;
        currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
        Debug.Log ("+" + healAmount + "Health");
    }
}
