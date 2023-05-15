using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    public float time = 2f;
    private Transform deathzoneTransform;
    private Animator playerAnimator;


    //Sends you to checkpoint 

    //private void OnTriggerEnter2D(Collider2D other) 
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        player.transform.position = respawnPoint.position;
    //    }
    //}
    private void Start()
    {
        deathzoneTransform = GetComponent<Transform>();
        playerAnimator = player.GetComponent<Animator>();
    }
    //Restarts the scene
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("CallGameOver", time);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            player.GetComponent<Transform>().position = deathzoneTransform.position;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<MovePlayer>().enabled = false;
            playerAnimator.SetBool("isDead", true);
            Debug.Log(playerAnimator.GetBool("isDead"));
        }
    }

    private void CallGameOver()
    {
        GameManager.GameOver();
    }

}
