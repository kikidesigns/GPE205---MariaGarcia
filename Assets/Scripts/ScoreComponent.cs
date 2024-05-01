using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreComponent : MonoBehaviour
{
    public float currentScore;
    public float maxScore;
    public float minScore;
    // Start is called before the first frame update
    void Start()
    {
        //set health to max
        currentScore = minScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore (float scoreAddAmount)
    {
        currentScore = currentScore - scoreAddAmount;
        Debug.Log("+" + scoreAddAmount + "points for" + gameObject.name);

    }



}
