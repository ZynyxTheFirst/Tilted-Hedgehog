using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private float originalGravity;
    private Rigidbody2D player;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")){
            originalGravity = collision.attachedRigidbody.gravityScale;
            player = collision.attachedRigidbody;
            transform.position = collision.transform.position;
            transform.parent = collision.transform;
            collision.attachedRigidbody.gravityScale = -0.1f;
        }
    }

    public void DestroyOnClick()
    {
        player.gravityScale = originalGravity;
        Destroy(this.gameObject);
        //Destroy(this.gameObject.transform.parent.gameObject.transform.parent.gameObject);
    }
}