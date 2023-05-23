using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the movement speed
    public float initialOffset = -20;

    private Vector3 center;
    private Vector3 targetPosition;

    public static bool centerReached;

    private void Start()
    {
        centerReached = false;
        // Calculate the target position at the center of the screen
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        center = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth / 2f, screenHeight / 2f, 0f));
        center.z = transform.position.z; // Maintain the object's original z position

        // Set the initial position of the object with an offset to the left
        Vector3 initialPosition = new Vector3(center.x + initialOffset, center.y, center.z);
        transform.position = initialPosition;
        SlideIn();
    }

    private void Update()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached the target position
        if (transform.position == targetPosition)
        {
            centerReached = true;
            // Object has reached the center, you can add any additional logic here
            Debug.Log("Object has reached the center!");
        }
        else centerReached = false;
    }

    public void SlideOut()
    {
        Vector3 offset = new Vector3(center.x + -initialOffset, center.y, center.z);
        targetPosition = offset;
    }

    private void SlideIn()
    {
        targetPosition = center;
    }
}
