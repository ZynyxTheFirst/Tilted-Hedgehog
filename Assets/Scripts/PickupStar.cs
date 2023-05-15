using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStar : MonoBehaviour
{
    public Scorehandler SCR;

    public LayerMask PlayerMask;
    public float CollectRadius = 0.5f;

    private void Start()
    {
        SCR = FindObjectOfType<Scorehandler>();
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(this.transform.position, CollectRadius, PlayerMask))
        {
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
