using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesComponent : MonoBehaviour
{
    public float currentLives;
    public float maxLives;
    public float minLives;


    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loseLife()
    {
        //remove life
        currentLives--;
        if (currentLives < minLives)
        {
            Debug.Log("You Died");
        }
    }

    public void gainLife()
    {
        //add life
        currentLives++;
        if (currentLives > maxLives)
        {
            currentLives=maxLives;
            Debug.Log("Max Lives Achieved");
        }
    }
}
