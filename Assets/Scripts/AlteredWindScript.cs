using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlteredWindScript : MonoBehaviour
{
    public ParticleSystem particles;

    [SerializeField] private AudioSource audioSource;
    public Rigidbody2D rb;
    public GameObject player;
    public bool angleDownwards, angleUpwards, angleLeft, angleRight = false;
    public float pushForce = 1f;
    Vector2 pushUpwards = new Vector2(0, 20);
    Vector2 pushDownwards = new Vector2(0, -20);
    Vector2 pushLeft = new Vector2(-20, 0);
    Vector2 pushRight = new Vector2(20, 0);
    //Vector2 normalState = new Vector2(0, 0);
    private bool playerInZone = false;
    private Vector2 direction = new Vector2(0, 0);

    void Start()
    {
        particles.Stop();
    }
    private void Update()
    {
        if(playerInZone == true && angleUpwards == true)
        {
            direction = pushUpwards;
        }
        if (playerInZone == true && angleDownwards == true)
        {
            direction = pushDownwards;
        }
        if (playerInZone == true && angleLeft == true)
        {
            direction = pushLeft;
        }
        if (playerInZone == true && angleRight == true)
        {
            direction = pushRight;
        }
        if (playerInZone == false)
        {
            RestoreStatesOfPlayerAndBag();
        }
    }
    private void PumpAir()
    {
        rb.AddForce(direction * pushForce);
        audioSource.Play();
        particles.Play();
        Invoke("RestoreStatesOfPlayerAndBag", 0.40f);
    }

    private void RestoreStatesOfPlayerAndBag()
    {
        //rb.AddForce(normalState);
        //rb.velocity = normalState;
        particles.Stop();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            InvokeRepeating("PumpAir", 0.2f, 0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            CancelInvoke("PumpAir");
            
        }
    }
}
