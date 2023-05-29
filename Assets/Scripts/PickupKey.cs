using System;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    private bool isPickedUp;
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        isPickedUp = false;
    }

    //Om spelaren går in i nyckeln plockas den upp och objektet blir inaktivt.
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {
            audioSource.Play();
            isPickedUp = true;
            //this.gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    public Boolean getPickedUp() {
        return isPickedUp;
    }

}
