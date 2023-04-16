using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
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
        ///Actual koden för mobiler
        /*if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.position.x > Screen.width / 2) desiredRot -= rotSpeed * Time.deltaTime;
            else desiredRot += rotSpeed * Time.deltaTime;
        }
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
        */
        ///Kod för att testa på datorn **Ska tas bort**
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2) desiredRotation -= rotationSpeed * Time.deltaTime;
            else desiredRotation += rotationSpeed * Time.deltaTime;
        }

        var desiredRotationQuaternion = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotationQuaternion, Time.deltaTime * damping);
    }
}
