using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Image healthBarImage;



    // Start is called before the first frame update
    void Start()
    {
        //set health to max
        currentHealth = maxHealth;
        UpdateHealthBar();
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
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die(source);
        }
    }

    public void Die (Pawn source)
    {
        Debug.Log("Dead");

        // Notify the GameManager that the player's pawn has died
        GameManager.instance.PlayerDied();

        Destroy (gameObject);
    }

    public void Heal (float healAmount, Pawn source)
    {
        currentHealth = currentHealth + healAmount;
        currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
        Debug.Log ("+" + healAmount + "Health");
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            float fillAmount = currentHealth / maxHealth;
            healthBarImage.fillAmount = fillAmount;
        }
    }
}
