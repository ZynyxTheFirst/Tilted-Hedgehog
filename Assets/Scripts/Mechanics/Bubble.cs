using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float forceMagnitude = 20f;
    public float maxRiseVelocity = 5f;
    public float maxRiseTime = 2f;

    private Rigidbody2D rb;
    private Rigidbody2D playerRb;

    private Transform parentTransform;
    private bool isRising = false;
    private float riseTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            isRising = true;
        }
    }

    void FixedUpdate() {
        if (isRising) {
            if (riseTime < maxRiseTime) {
                float riseVelocity = Mathf.Lerp(0f, maxRiseVelocity, riseTime / maxRiseTime);
                rb.AddForce(Vector2.up * riseVelocity, ForceMode2D.Impulse);
                riseTime += Time.fixedDeltaTime;
            }
            else {
                isRising = false;
            }
        }
        else {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            parentTransform = collision.transform.parent;
            rb.isKinematic = false;
            rb.gravityScale = 0f;
            playerRb.isKinematic = true;
            collision.transform.SetParent(transform);
            rb.bodyType = RigidbodyType2D.Kinematic;
            playerRb.bodyType = RigidbodyType2D.Kinematic;
            collision.transform.position = transform.position;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;

            Vector2 upwardForce = Vector2.up * forceMagnitude;
            rb.AddForce(upwardForce, ForceMode2D.Force);
            playerRb.AddForce(upwardForce, ForceMode2D.Force);
        }
        else if (collision.gameObject.CompareTag("Ground")) {
            transform.DetachChildren();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.isKinematic = false;
            collision.gameObject.transform.SetParent(null);
        }
    }
}