using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;


    //Sends you to checkpoint 

    //private void OnTriggerEnter2D(Collider2D other) 
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        player.transform.position = respawnPoint.position;
    //    }
    //}

    //Restarts the scene
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.GameOver();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
