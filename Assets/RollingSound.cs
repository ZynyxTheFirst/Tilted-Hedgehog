using UnityEngine;

public class RollingSound : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioSource audioSource;
    public float startingPitch = 2f;
    public float volumeSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource.time = volumeSpeed;
        audioSource.pitch = startingPitch;
    }

    void FixedUpdate()
    {
        audioSource.volume = Mathf.Clamp01(rb.velocity.magnitude / volumeSpeed);
        audioSource.pitch = Mathf.Clamp(rb.velocity.magnitude / startingPitch, 1f, 2f);

        if (rb.angularVelocity >= 1f)
            audioSource.Play();
        else
            audioSource.Stop();
    }
}