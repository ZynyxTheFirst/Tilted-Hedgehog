using System;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Transform startPoint;   // Start point of movement
    public Transform endPoint;     // End point of movement
    public float movementSpeed = 5f;    // Speed of movement

    private Vector3 targetPosition; // Target position of the object
    public GameObject shadowObject; // Reference to the shadow object

    void Start()
    {
        // Check if start and end points are assigned
        if (startPoint == null || endPoint == null)
        {
            Debug.LogError("Please assign start and end points to the ObjectMovement script.");
            return;
        }

        // Set the initial target position to the start point
        targetPosition = startPoint.position;
    }

    void Update()
    {
        // Move the object towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Update the position of the shadow object to match the object's position
        shadowObject.transform.position =  new Vector3(transform.position.x + 0.02f, transform.position.y + -0.4f);

        // Check if the object has reached the target position
        if (transform.position == targetPosition)
        {
            // Toggle the target position between start and end points
            targetPosition = (targetPosition == startPoint.position) ? endPoint.position : startPoint.position;

            // Rotate the object by 180 degrees
            transform.Rotate(Vector3.forward, 180f, Space.Self);
            shadowObject.transform.Rotate(Vector3.forward, 180f, Space.Self);
        }
    }
}
