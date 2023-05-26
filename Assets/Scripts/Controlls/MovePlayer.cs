using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    public float slipperyFactor; // controls the slippery movement
    public bool resetAllPlayerPref;
    private Rigidbody2D rb;
    [SerializeField] private AudioClip audioClip;

    [SerializeField] private AudioSource audioSource;

    private bool isAudioClipBeingPlayed;

    private float speedThresholdForAudio = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip;
        if (resetAllPlayerPref)
        {
            PlayerPrefs.DeleteAll();
        }

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found in the object.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneTransition.centerReached)
        {
            if (movementJoystick != null && rb != null && movementJoystick.joystickVec.y != 0)
            {
                Vector2 targetVelocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
                rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * slipperyFactor);
            }
            else
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * slipperyFactor);
            }
        }
        CheckCharacterMovment();
    }

    void CheckCharacterMovment()
    {
        if (isCharacterMoving() && !isAudioClipBeingPlayed)
        {
            PlayAudio();
        }
        else if (!isCharacterMoving() && isAudioClipBeingPlayed)
            StopAudio();
    }

    void PlayAudio()
    {
        audioSource.Play();
        isAudioClipBeingPlayed = true;
    }

    void StopAudio()
    {
        audioSource.Stop();
        isAudioClipBeingPlayed = false;
    }

    bool isCharacterMoving(){
        if(rb.velocity.magnitude > speedThresholdForAudio){
           return true;
        }
        else
        return false;
    }
}
