using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector2 offset;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(offset.x, offset.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}
