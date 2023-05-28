using UnityEngine;

public class Boid : MonoBehaviour
{
    private float maxSpeed = 2.0f;         // Maximum speed of the boid
    private float maxForce = 0.5f;         // Maximum steering force applied to the boid
    private float neighborRadius = 1.5f;   // Radius to consider neighboring boids
    private float separationRadius = 0.5f; // Radius for separation behavior
    private LayerMask boidLayerMask;       // Layer mask for filtering neighboring boids
    private Vector2 boundingBoxSize;       // Size of the bounding box

    private Vector2 velocity;             // Current velocity of the boid

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        BoidConfig config = gameObject.GetComponentInParent<BoidConfig>();
        maxSpeed = config.maxSpeed;
        maxForce = config.maxForce;
        neighborRadius = config.neighborRadius;
        separationRadius = config.separationRadius;
        boidLayerMask = config.boidLayerMask;
        boundingBoxSize = config.boundingBoxSize;
    }

    void Update()
    {
        // Get the combined steering force from alignment, cohesion, and separation
        Vector2 alignment = Alignment();
        Vector2 cohesion = Cohesion();
        Vector2 separation = Separation();

        // Apply the steering force to the boid's velocity
        velocity += alignment + cohesion + separation;
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);

        // Add a random steering force
        Vector2 randomForce = Random.insideUnitCircle * maxForce;
        velocity += randomForce;

        // Move the boid
        Vector3 newPosition = transform.position + (Vector3)velocity * Time.deltaTime;
        newPosition = ClampPositionToBounds(newPosition);
        transform.position = newPosition;

        // Rotate the boid to face the direction of movement
        if (velocity.magnitude > 0)
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }



    // Align the boid with its neighboring boids
    private Vector2 Alignment()
    {
        Vector2 steering = Vector2.zero;
        int count = 0;

        Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, neighborRadius, boidLayerMask);
        foreach (Collider2D neighbor in neighbors)
        {
            if (neighbor != GetComponent<Collider2D>())
            {
                Boid neighborBoid = neighbor.GetComponent<Boid>();
                steering += neighborBoid.velocity;
                count++;
            }
        }

        if (count > 0)
        {
            steering /= count;
            steering = Vector2.ClampMagnitude(steering, maxForce);
        }

        return steering;
    }

    // Move the boid towards the center of its neighboring boids
    private Vector2 Cohesion()
    {
        Vector2 steering = Vector2.zero;
        int count = 0;

        Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, neighborRadius, boidLayerMask);
        foreach (Collider2D neighbor in neighbors)
        {
            if (neighbor != GetComponent<Collider2D>())
            {
                Boid neighborBoid = neighbor.GetComponent<Boid>();
                steering += (Vector2)neighborBoid.transform.position;
                count++;
            }
        }

        if (count > 0)
        {
            steering /= count;
            steering -= (Vector2)transform.position;
            steering = Vector2.ClampMagnitude(steering, maxForce);
        }

        return steering;
    }

    // Keep the boid separated from its neighboring boids
    private Vector2 Separation()
    {
        Vector2 steering = Vector2.zero;
        int count = 0;

        Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, separationRadius, boidLayerMask);
        foreach (Collider2D neighbor in neighbors)
        {
            if (neighbor != GetComponent<Collider2D>())
            {
                Vector2 offset = (Vector2)transform.position - (Vector2)neighbor.transform.position;
                float distance = offset.magnitude;
                steering += offset.normalized / distance;
                count++;
            }
        }

        if (count > 0)
        {
            steering /= count;
            steering = Vector2.ClampMagnitude(steering, maxForce);
        }

        return steering;
    }

    // Clamp the position of the boid to stay within the bounding box and return the new position
    private Vector3 ClampPositionToBounds(Vector3 position)
    {
        Vector3 clampedPosition = position;
        float halfWidth = boundingBoxSize.x / 2;
        float halfHeight = boundingBoxSize.y / 2;

        // Check if the boid is nearing the bounds
        if (clampedPosition.x < -halfWidth || clampedPosition.x > halfWidth)
        {
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -halfWidth, halfWidth);
            velocity.x *= -1; // Reverse the horizontal velocity to move away from the bounds
        }

        if (clampedPosition.y < -halfHeight || clampedPosition.y > halfHeight)
        {
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -halfHeight, halfHeight);
            velocity.y *= -1; // Reverse the vertical velocity to move away from the bounds
        }

        return clampedPosition;
    }
}
