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
    }

    private void calculateSpeed()
    {
        float temp = 0f;

        if (rb.velocity.x > speedCeiling || rb.velocity.y > speedCeiling)
        {
            temp = 0f;

        }
        else
        {
            temp = moveSpeed;
        }

        rb.AddForce(movement * temp, ForceMode2D.Force);
    }
}
