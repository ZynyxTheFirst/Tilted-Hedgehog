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

    private void FixedUpdate()
    {
        if (playerAnimator.GetBool("isDead"))
        {
            StartCoroutine(MovePlayerToDeathZone());
            playerAnimator.SetBool("isDead", false);
        }

    }


    //Restarts the scene
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("CallGameOver", time);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //player.GetComponent<Transform>().position = deathzoneTransform.position * Time.deltaTime;
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

    private IEnumerator MovePlayerToDeathZone()
    {
        Vector2 startPosition = player.transform.position;
        Vector2 targetPosition = deathzoneTransform.position;
        float distance = Vector2.Distance(startPosition, targetPosition);
        float speed = distance / time;

        while (Vector2.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        player.transform.position = targetPosition;
    }

}
