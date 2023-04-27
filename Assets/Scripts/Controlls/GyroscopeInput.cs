using UnityEngine;

public class GyroscopeInput : MonoBehaviour
{
    ///Fungerar inte just nu
    private float desiredRotation;
    public float rotationSpeed = 250;
    public float damping = 10;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void OnEnable()
    {
        desiredRotation = transform.eulerAngles.z;
    }
    float GetZRotation()
    {
        Quaternion referenceRotation = Quaternion.identity;
        Quaternion deviceRotation = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
        Quaternion eliminationOfXY = Quaternion.Inverse(Quaternion.FromToRotation(referenceRotation * Vector3.forward,deviceRotation * Vector3.forward));
        Quaternion rotationZ = eliminationOfXY * deviceRotation;
        float roll = rotationZ.eulerAngles.z;

        return roll;
    }

    void Update()
    {
        Debug.Log(GetZRotation());

        if (GetZRotation() < 70 && GetZRotation() > 0)
            desiredRotation += rotationSpeed * Time.deltaTime;
        if(GetZRotation() > 110 && GetZRotation() < 180)
            desiredRotation -= rotationSpeed * Time.deltaTime;
        
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }
}
