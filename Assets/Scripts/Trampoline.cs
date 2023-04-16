using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float launchForce = 1f;
    public Rigidbody2D rb;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GreenSurface"))
        {
            rb.velocity = Vector2.up * launchForce;

        }
        if (collision.gameObject.CompareTag("OrangeSurface"))
        {
            rb.velocity = Vector2.up * launchForce * 1.5f;

        }
        if (collision.gameObject.CompareTag("RedSurface"))
        {
            rb.velocity = Vector2.up * launchForce * 2f;

        }
    }
}