using UnityEngine;

public class Spike : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game over!");
            GameManager.GameOver();
        }
    }
}
