using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    private bool stopTime = false;
    public double pauseDuration = 100f;
    private bool stopTimeCooldown = false;
    public float cooldownDuration = 60f;
    public float slowMotionStrength = 0.3f;

    // Update is called once per frame
    void Update()
    {
        if (stopTime == true)
        {
            pauseDuration -= 0.2f;
            if (pauseDuration <= 0)
            {
                ResumeTime();

            }
        }
        if (stopTimeCooldown == true)
        {
            Cooldown();
        }
    }
    public void ResumeTime()
    {
        Time.timeScale = 1;
        stopTime = false;
        pauseDuration = 100f;
    }
    public void Cooldown()
    {
        cooldownDuration -= 0.2f;
        if (cooldownDuration <= 0)
        {
            cooldownDuration = 300f;
            stopTimeCooldown = false;

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && stopTimeCooldown == false)
        {
            Time.timeScale = 0.2f;
            stopTime = true;
            stopTimeCooldown = true;
        }
    }
}
