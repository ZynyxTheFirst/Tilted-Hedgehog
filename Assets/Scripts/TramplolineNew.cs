using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramplolineNew : MonoBehaviour
{
    public float launchForce = 1f;
    public Rigidbody2D rb;
    private Animator trampolineAnimator;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Hämtar animatorn hos trampolinen som spelaren krockar med.
        trampolineAnimator = collision.GetComponent<Animator>();
        //trampolineAnimator.SetBool("isTriggered", true);
        trampolineAnimator.Play("anim_trampolineGreen");

        var opposite = -rb.velocity;
        if (collision.gameObject.CompareTag("GreenSurface"))
        {
            rb.velocity = opposite * launchForce * 1f * Time.deltaTime;
            rb.AddForce(opposite * launchForce * 1f * Time.deltaTime);

        }
        if (collision.gameObject.CompareTag("OrangeSurface"))
        {
            rb.velocity = opposite * launchForce * 1.5f * Time.deltaTime;
            rb.AddForce(opposite * launchForce * 1.5f * Time.deltaTime);

        }
        if (collision.gameObject.CompareTag("RedSurface"))
        {
            rb.velocity = opposite * launchForce * 2f * Time.deltaTime;
            rb.AddForce(opposite * launchForce * 2f * Time.deltaTime);
            Debug.Log("Studs " + opposite);

        }
    }
}
