using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullSound : MonoBehaviour
{
    private AudioSource audioSource;
    public float delayInSeconds = 2f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundWithDelay());
    }


    IEnumerator PlaySoundWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayInSeconds);
                    audioSource.Play();
        }
        

    }
}
