using UnityEngine;

public class RollingSound : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioSource audioSource;
    //public float startingPitch = 2f;
    public float maxVolume;
    public float maxVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource.time = maxVolume;
        //audioSource.pitch = startingPitch;
    }

    void FixedUpdate()
    {
        float velocityMagnitude = rb.velocity.magnitude;
        float volume = Mathf.Clamp01(velocityMagnitude / maxVelocity) * maxVolume;
        audioSource.volume = volume;
        //audioSource.pitch = Mathf.Clamp(rb.velocity.magnitude / startingPitch, 1f, 2f);

        /*
        if (rb.angularVelocity >= 1f)
            audioSource.Play();
        else
            audioSource.Stop();
        */
    }
}