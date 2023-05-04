using System.Collections.Generic;
using UnityEngine;

public class secondGyro : MonoBehaviour
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

        Input.gyro.enabled = true; // Enable gyro input
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

        float roll = GetZRotation();

        if (roll < 70 && roll > 0)
            transform.Rotate(0, 0, -playerSpeed * Time.deltaTime);
        if (roll > 110 && roll < 180)
            transform.Rotate(0, 0, playerSpeed * Time.deltaTime);
    }

    float GetZRotation()
    {
        Quaternion referenceRotation = Quaternion.identity;
        Quaternion deviceRotation = Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
        Quaternion eliminationOfXY = Quaternion.Inverse(Quaternion.FromToRotation(referenceRotation * Vector3.forward, deviceRotation * Vector3.forward));
        Quaternion rotationZ = eliminationOfXY * deviceRotation;
        float roll = rotationZ.eulerAngles.z;

        // Invert the roll angle to reverse the direction of rotation
        roll = 360f - roll;

        return roll;
    }
}
