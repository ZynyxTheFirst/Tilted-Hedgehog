using UnityEngine;

public class GyroControlls : MonoBehaviour
{
    public float playerSpeed;
    public float slipperyFactor; // controls the slippery movement
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found in the object.");
        }

        Input.gyro.enabled = true; // Enable gyro input
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.gyro.attitude.x * -playerSpeed, Input.gyro.attitude.y * -playerSpeed);
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * slipperyFactor);
    }
}
