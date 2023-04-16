using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private float desiredRot;
    public float rotSpeed = 250;
    public float damping = 10;

    private void OnEnable()
    {
        desiredRot = transform.eulerAngles.z;
    }

    void Update()
    {
        /*if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.position.x > Screen.width / 2) desiredRot -= rotSpeed * Time.deltaTime;
            else desiredRot += rotSpeed * Time.deltaTime;
        }
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
        */
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2) desiredRot -= rotSpeed * Time.deltaTime;
            else desiredRot += rotSpeed * Time.deltaTime;
        }

        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }
}
