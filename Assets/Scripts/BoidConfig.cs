using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidConfig : MonoBehaviour
{
    public float maxSpeed = 2.0f;         // Maximum speed of the boid
    public float maxForce = 0.5f;         // Maximum steering force applied to the boid
    public float neighborRadius = 1.5f;   // Radius to consider neighboring boids
    public float separationRadius = 0.5f; // Radius for separation behavior
    public LayerMask boidLayerMask;                                 // Layer mask for filtering neighboring boids
    public Vector2 boundingBoxSize = new Vector2(25f, 15f);       // Size of the bounding box

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        // Get the corners of the bounding box
        Vector2 topLeft = new Vector2(-boundingBoxSize.x / 2, boundingBoxSize.y / 2);
        Vector2 topRight = new Vector2(boundingBoxSize.x / 2, boundingBoxSize.y / 2);
        Vector2 bottomLeft = new Vector2(-boundingBoxSize.x / 2, -boundingBoxSize.y / 2);
        Vector2 bottomRight = new Vector2(boundingBoxSize.x / 2, -boundingBoxSize.y / 2);

        // Draw the lines of the bounding box
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
