using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStar : MonoBehaviour
{
    public Scorehandler SCR;

    public LayerMask PlayerMask;
    public float CollectRadius = 0.5f;
    private int starsCollected;

    private void Start()
    {
        starsCollected = PlayerPrefs.GetInt("StarsCollected");
        SCR = FindObjectOfType<Scorehandler>();
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(this.transform.position, CollectRadius, PlayerMask))
        {
            PlayerPrefs.SetInt("StarsCollected", starsCollected +1);
            SCR.FoundStar();
            Destroy(this.gameObject);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        // Set the color of the Gizmos to red
        Gizmos.color = Color.red;

        // Draw a wire sphere with the same radius as the circle collider
        Gizmos.DrawWireSphere(transform.position, CollectRadius);
    }

}
