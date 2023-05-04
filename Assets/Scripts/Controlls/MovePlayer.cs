using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public MovementJoystick movementJoystick;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementJoystick != null && rb != null && movementJoystick.joystickVec.y != 0)
        {
            Vector2 targetVelocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * slipperyFactor);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * slipperyFactor);
        }
    }
}
