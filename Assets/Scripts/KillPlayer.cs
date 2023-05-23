using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    public float time = 2f;
    public float moveSpeed = 2f;
    public float minSpeed = 2f;
    private Transform deathzoneTransform;
    private Animator playerAnimator;
    [SerializeField] private AudioSource deathSoundEffect;


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

    }


    //Restarts the scene
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("CallGameOver", time);
            StartCoroutine(MovePlayerToDeathZone());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //player.GetComponent<Transform>().position = deathzoneTransform.position * Time.deltaTime;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<MovePlayer>().enabled = false;
            

        }
    }

    private void CallGameOver()
    {
        GameManager.GameOver();
    }

    private IEnumerator MovePlayerToDeathZone2()
    {
        Vector2 startPosition = player.transform.position;
        Vector2 targetPosition = deathzoneTransform.position;
        float distance = Vector2.Distance(startPosition, targetPosition);
        float speed = distance / moveSpeed;

        while (Vector2.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector2.Distance(player.transform.position, targetPosition) > 0.5f)
            {
                playerAnimator.SetBool("isDead", true);
            }
            yield return null;
        }

        
        player.transform.position = targetPosition;
        
    }

    private IEnumerator MovePlayerToDeathZone()
    {
        
        Vector2 startPosition = player.transform.position;
        Vector2 targetPosition = deathzoneTransform.position;
        float distance = Vector2.Distance(startPosition, targetPosition);

        // Calculate move speed based on player's speed when it touches the death zone
        float moveSpeed = player.GetComponent<Rigidbody2D>().velocity.magnitude;
        Debug.Log(moveSpeed);
        
        if(moveSpeed < minSpeed)
        {
            moveSpeed = minSpeed;
        }
        Debug.Log(moveSpeed);

        while (Vector2.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(player.transform.position, targetPosition) > 0.5f)
            {
                playerAnimator.SetBool("isDead", true);
            }
            yield return null;
        }

        player.transform.position = targetPosition;
        deathSoundEffect.Play();
    }


}
