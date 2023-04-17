using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_MouseInput : MonoBehaviour
{
    private float desiredRotation;
    public float rotationSpeed = 250;
    public float damping = 10;

    private void OnEnable()
    {
        desiredRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2) desiredRotation -= rotationSpeed * Time.deltaTime;
            else desiredRotation += rotationSpeed * Time.deltaTime;
        }

        var desiredRotationQuaternion = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotationQuaternion, Time.deltaTime * damping);
    }
}
