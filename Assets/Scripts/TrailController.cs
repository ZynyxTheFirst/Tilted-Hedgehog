using UnityEngine;

public class TrailController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform targetTransform;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        targetTransform = transform.parent;
    }

    private void Update()
    {
        if (SceneTransition.centerReached)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, targetTransform.position);
        }
    }
}
