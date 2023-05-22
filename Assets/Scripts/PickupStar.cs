using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupStar : MonoBehaviour
{
    public Scorehandler SCR;

    public LayerMask PlayerMask;
    public float CollectRadius = 0.5f;
    private int starsCollected;
    private bool isCollected = false;
    private string saveKey;

    private void Start()
    {
        // Skapar ett unikt saveKey för varje stjärnobjekt.
        saveKey = gameObject.name + SceneManager.GetActiveScene().ToString();

        if (PlayerPrefs.HasKey(saveKey))
        {
            isCollected = PlayerPrefs.GetInt(saveKey) == 1;

            if (isCollected)
                gameObject.SetActive(false);
                //Destroy(this.gameObject);
        }

        SCR = FindObjectOfType<Scorehandler>();
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(this.transform.position, CollectRadius, PlayerMask))
        {
            PlayerPrefs.SetInt("StarsCollected", starsCollected +1);

            isCollected = true;
            SCR.FoundStar();
            // Spara om stjärnarn har blivit upplockad eller inte.
            PlayerPrefs.SetInt(saveKey, 1);
            PlayerPrefs.Save();
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
        
    }
    public bool IsCollected(){
        return isCollected;
    }
    private void OnDrawGizmosSelected()
    {
        // Set the color of the Gizmos to red
        Gizmos.color = Color.red;

        // Draw a wire sphere with the same radius as the circle collider
        Gizmos.DrawWireSphere(transform.position, CollectRadius);
    }

}
