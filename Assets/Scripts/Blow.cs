using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    public GameObject wind;

    public Vector3 blowObjectPosition;

      void Start()
    {
       blowObjectPosition = new Vector3(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y, gameObject.transform.parent.position.z);
    }
        private void OnTriggerEnter2D(Collider2D other) 
    {
        while (other.CompareTag("Player"))
        {
            Instantiate(wind, gameObject.transform.parent.position, gameObject.transform.parent.rotation);
        }
    }
}
