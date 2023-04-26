using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    public ParticleSystem particles;

    public GameObject player;

    public float windSpeed = 2.0f;

        void Start()
    {
        particles.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -1.0f;
            particles.Play();
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           /*  InvokeRepeating("RestoreGravityScale", 0.1f, 0.1f); */
            player.GetComponent<Rigidbody2D>().gravityScale = 3.3f;
            particles.Stop();
        }
    }

    private void RestoreGravityScale(){
        player.GetComponent<Rigidbody2D>().gravityScale =+ 0.1f;
    }
}
