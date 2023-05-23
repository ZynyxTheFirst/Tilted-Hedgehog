using UnityEngine;

public class TrailController : MonoBehaviour
{
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.emitting = false;
    }

    private void Update()
    {
        if (SceneTransition.centerReached)
        {
            trailRenderer.enabled = true;
            trailRenderer.emitting = true;
        }
        else
        {
            trailRenderer.enabled = false;
            trailRenderer.emitting = false;
        }
    }
}
