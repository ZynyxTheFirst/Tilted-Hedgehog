using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    public ParticleSystem particles;

    public float windSpeed = 2.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            particles.Play();
            Vector3 directionOfWind = new Vector3(0f, 1.0f, 0f);
            particles.GetComponent<Rigidbody2D>().AddForce(directionOfWind * windSpeed);
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            particles.Stop();
        }
    }
}
