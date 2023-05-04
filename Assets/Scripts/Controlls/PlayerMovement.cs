using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Some variables
    public Rigidbody2D rb;
    Vector2 movement, movementOrder;
    bool moveW = false, moveA = false, moveS = false, moveD = false;
    float fSpeed = 3f, fMaxSpeed = 5.0f, fFriction = 0.5f;
    //Getting controls from the player and updating the order

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveW = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveA = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveS = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveD = true;
        }

    }
    //Executing the physics calculations
    private void FixedUpdate ()
    {
        if (moveW && !moveS)
        {
            movementOrder.y = fMaxSpeed;
        }
        else if (moveS && !moveW)
        {
            movementOrder.y = -fMaxSpeed;
        }
        else if (moveS && !moveW)
        {
            movementOrder.y = 0;
        }
        if (moveD && !moveA)
        {
            movementOrder.x = -fMaxSpeed;
        }
        else if (moveA && moveD)
        {
            movementOrder.x = 0;
        }
        //Executing order 66;
        if(moveW && movement.y < movementOrder.y)
        {
            movement.y += fSpeed * Time.fixedDeltaTime;
        }
        if (moveS && movement.y > movementOrder.y)
        {
            movement.y -= fSpeed * Time.fixedDeltaTime;
        }
        if (moveA && movement.x > movementOrder.x)
        {
            movement.x -= fSpeed * Time.fixedDeltaTime;
        }
        if (moveD && movement.x < movementOrder.x)
        {
            movement.x += fSpeed * Time.fixedDeltaTime;
        }
        //Friction
        if(!moveW && !moveS && movement.y > 0)
        {
            movement.y -= fSpeed * fFriction * Time.fixedDeltaTime;
        }
        else if(!moveW && !moveS && movement.y < 0)
        {
            movement.y += fSpeed * fFriction * Time.fixedDeltaTime;
        }
        if(!moveD && !moveA && movement.x > 0)
        {
            movement.x -= fSpeed * fFriction * Time.fixedDeltaTime;
        }
        else if(!moveD && !moveA && movement.x < 0)
        {
            movement.x += fSpeed * fFriction * Time.fixedDeltaTime;
        }
        //Updating the position
        gameObject.transform.position = gameObject.transform.position + (Vector3)movement * fSpeed * Time.fixedDeltaTime;
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + (Vector3)movement);
    }
}
