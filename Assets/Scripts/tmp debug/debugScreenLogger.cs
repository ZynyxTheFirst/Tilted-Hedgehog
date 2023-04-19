using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugScreenLogger : MonoBehaviour
{
    public Text rollText;

    private void Update()
    {
        rollText.text = "Z: " + DebugLogGyroscopicEulerAngleRollZ().ToString();
    }

    private float DebugLogGyroscopicEulerAngleRollZ()
    {
        Quaternion referenceRotation = Quaternion.identity;
        Quaternion deviceRotation = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
        Quaternion eliminationOfXY = Quaternion.Inverse(Quaternion.FromToRotation(referenceRotation * Vector3.forward, deviceRotation * Vector3.forward));
        Quaternion rotationZ = eliminationOfXY * deviceRotation;
        float roll = rotationZ.eulerAngles.z;

        return roll;
    }
}
