using System;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    private bool isPickedUp;

    void Start()
    {
        isPickedUp = false;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag("Player")) {
            isPickedUp = true;
            this.gameObject.SetActive(false);
        }
    }

    public Boolean getPickedUp() {
        return isPickedUp;
    }
}
