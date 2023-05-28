using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    private float speed = 15f; // Adjust this value to control the movement speed
    private float initialOffset = -20;

    private AudioSource audioSource;

    private Vector3 center;
    private Vector3 targetPosition;
    private Vector3 offsetPosition;

    public static bool centerReached;
    public static bool startSlideOut;
    public static bool endReached;

    private void Awake()
    {
        endReached = false;
        centerReached = false;
        startSlideOut = false;
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

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
            // Object has reached the center, you can add any additional logic here
            //Debug.Log("Object has reached the center!");
        }
        else centerReached = false;

        if (startSlideOut)
        {
            SlideOut();
        }

        if(transform.position == offsetPosition)
        {
            endReached = true;
        }
    }

    private void SlideOut()
    {
        centerReached = false;
        targetPosition = offsetPosition;
    }

    private void SlideIn()
    {
        if(audioSource != null)
        {
            audioSource.Play();
        }
        
        targetPosition = center;
    }
}