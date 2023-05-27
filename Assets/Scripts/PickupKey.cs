using System;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    private bool isPickedUp;

    void Start() {
        isPickedUp = false;
    }

    //Om spelaren går in i nyckeln plockas den upp och objektet blir inaktivt.
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {
            isPickedUp = true;
            this.gameObject.SetActive(false);
        }
    }

    public Boolean getPickedUp() {
        return isPickedUp;
    }

}
