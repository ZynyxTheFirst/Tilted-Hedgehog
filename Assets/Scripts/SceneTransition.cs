using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the movement speed
    public float initialOffset = -20;

    private Vector3 center;
    private Vector3 targetPosition;
    private Vector3 offsetPosition;

    public static bool centerReached;
    public static bool transitioning;

    private void Awake()
    {
        transitioning = false;
        centerReached = false;
    }

    private void Start()
    {
        // Calculate the target position at the center of the screen
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        center = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth / 2f, screenHeight / 2f, 0f));
        center.z = transform.position.z; // Maintain the object's original z position

        offsetPosition = new Vector3(center.x + -initialOffset, center.y, center.z);

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
        if (transform.position == center)
        {
            centerReached = true;
        }
        else centerReached = false;

        if(transform.position == offsetPosition)
        {
            GoToNextLevel.LoadNextLevel();
        }
    }

    public void SlideOut()
    {
        transitioning = true;
        centerReached = false;
        targetPosition = offsetPosition;
    }

    private void SlideIn()
    {
        targetPosition = center;
    }
}