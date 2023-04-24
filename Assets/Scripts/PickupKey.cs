using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    private bool isPickedUp;
    [SerializeField] private GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag("Player")) {
            isPickedUp = true;
            gameObject.SetActive(false);

        }
    }

    public Boolean getPickedUp() {
        return isPickedUp;
    }
}
