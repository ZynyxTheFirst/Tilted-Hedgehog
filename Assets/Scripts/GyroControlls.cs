using UnityEngine;

public class GyroControlls : MonoBehaviour
{
    public float playerSpeed;
    public float slipperyFactor; // controls the slippery movement
    private Rigidbody2D rb;
    private bool gyroEnabled;
    private Gyroscope gyro;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found in the object.");
        }

        gyroEnabled = SystemInfo.supportsGyroscope;
        if (gyroEnabled)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        else
        {
            Debug.LogError("Gyro input is not supported on this device.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.gyro.attitude.x * -playerSpeed, Input.gyro.attitude.y * -playerSpeed);
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * slipperyFactor);
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
