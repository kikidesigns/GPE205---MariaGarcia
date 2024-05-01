using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign the player's tankpawn transform here
    public float smoothSpeed = 0.125f; // Adjust this value to control the smoothness of the camera movement
    public Vector3 offset = new Vector3(0,5,-10); // Adjust this vector to set the camera offset from the target

     private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired camera position
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate the camera's position to the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
        else
        {
            Debug.Log("Camera target not assigned");
        }
    }
}