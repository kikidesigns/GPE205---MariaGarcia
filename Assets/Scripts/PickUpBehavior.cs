using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupBehavior : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 100f;
    // Amplitude of hovering motion
    public float hoverAmplitude = 0.5f;
    // Frequency of hovering motion
    public float hoverFrequency = 1f;

    // Initial position of the pickup
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the pickup
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the pickup in global space
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // Calculate the hovering offset
        float hoverOffset = Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;

        // Set the new position of the pickup
        transform.position = initialPosition + Vector3.up * hoverOffset;
    }
}
