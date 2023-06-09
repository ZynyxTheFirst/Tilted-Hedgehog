using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWASD : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float speedCeiling = 10f;

    private Rigidbody2D rb;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Debug.Log("Velocity x: " + rb.velocity.x);
        Debug.Log("Velocity y: " + rb.velocity.y);

        calculateSpeed();
        //calculateFriction();
    }

    private void calculateSpeed()
    {
        float temp = 0f;

        // Max speed
        if (rb.velocity.x > speedCeiling || rb.velocity.x < speedCeiling*-1 || rb.velocity.y > speedCeiling || rb.velocity.y < speedCeiling*-1)
        {
            temp = 0f;

        }
        else
        {
            temp = moveSpeed;
        }

        rb.AddForce(movement * temp, ForceMode2D.Force);
    }

    private void calculateFriction()
    {
        float temp = 0f;

        rb.AddForce(movement * temp, ForceMode2D.Force);
    }
}
