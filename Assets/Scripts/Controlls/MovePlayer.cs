using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    public float slipperyFactor; // controls the slippery movement
    private Rigidbody2D rb;
    public AudioSource audioSource;
    private Animator animator;
    public float rotationSpeed = 5f;
    public float spinningSpeed = 1f;
    public Vector2 minimumSpeed = new Vector2(0.1f, 0.1f);


    // Start is called before the first frame update
    void Start()
    {
        //animator.SetBool("isMoving", false);
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found in the object.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneTransition.centerReached)
        {
            if (movementJoystick != null && rb != null && movementJoystick.joystickVec.y != 0)
            {
                Vector2 targetVelocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
                rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * slipperyFactor);
                
                
            }
            else
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * slipperyFactor);
            }

            if (rb.velocity.x > minimumSpeed.x || rb.velocity.y > minimumSpeed.y || rb.velocity.x < -minimumSpeed.x || rb.velocity.y < -minimumSpeed.y)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            // Om velocity inte är 0 så roterar karaktären.
            if (rb.velocity != Vector2.zero)
            {

                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            animator.speed = rb.velocity.magnitude * spinningSpeed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            if (collision.relativeVelocity.magnitude > 0)
                audioSource.Play();
        Debug.Log(collision.collider.name);
    }

}
