using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GyroscopeInput : MonoBehaviour
{
    ///Fungerar inte just nu

    /* Start is called before the first frame update
    void Start()
    {
        
    }

    private TextMeshProUGUI debugText;
    private float paddleZRot;

    void Update()
    {
        Vector3 gyroEuler = Input.gyro.attitude.eulerAngles;
        phoneDummy.transform.eulerAngles = new Vector3(-1.0f * gyroEuler.x, -1.0f * gyroEuler.y, gyroEuler.z);
        debugText.text = "gyroEuler (" + gyroEuler.x + ",\n" + gyroEuler.y + ",\n" + gyroEuler.z + ")";
        Vector3 upVec = phoneDummy.transform.InverseTransformDirection(-1f * Vector3.forward);
        paddleZRot = Mathf.Clamp((Map(upVec.x, -0.46f, 0.46f, -70, 70) * sensitivity), -70, 70);
    }*/
}
