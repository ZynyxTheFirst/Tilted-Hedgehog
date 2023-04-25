using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] int launchForce = 100;

    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = collision.contacts[0].point; Vector3 v = transform.position;
            direction -= v;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(gameObject.transform.localToWorldMatrix.rotation.eulerAngles.z + 90, 0) * launchForce);

            Vector2 force = new Vector2(0f, Mathf.Sqrt(2f * launchForce * Mathf.Abs(Physics2D.gravity.y)));
            float angle = transform.rotation.eulerAngles.z;
            force = Quaternion.Euler(0, 0, angle) * force;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
            
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 force = new Vector2(0f, launchForce);
            float angle = transform.localToWorldMatrix.rotation.eulerAngles.z + 90;
            force = Quaternion.Euler(0, 0, angle) * force;
            collision.GetComponent<Rigidbody2D>().AddForce(force);

        }
    }
}