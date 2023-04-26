using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    public ParticleSystem particles;

    public GameObject player;

        void Start()
    {
        particles.Stop();
    }

    private void pumpAir(){
        player.GetComponent<Rigidbody2D>().gravityScale = -1.25f;
            particles.Play();
            Invoke("RestorStatesOfPlayerAndBag", 0.40f);
    }

    private void RestorStatesOfPlayerAndBag(){
        player.GetComponent<Rigidbody2D>().gravityScale = 3.3f;
        particles.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InvokeRepeating("pumpAir", 0.2f, 0.5f);
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CancelInvoke("pumpAir");
        }
    }
}
