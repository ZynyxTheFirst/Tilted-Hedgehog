using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupStar : MonoBehaviour
{
    public Scorehandler SCR;

    public LayerMask PlayerMask;
    public float CollectRadius = 0.5f;
    private ParticleSystem particleSys;
    private SpriteRenderer spriteRenderer;
    private int starsCollected;
    private bool isCollected = false;
    private bool animatorOff = true;
    private string saveKey;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        particleSys = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Skapar ett unikt saveKey för varje stjärnobjekt.
        saveKey = transform.parent.name + SceneManager.GetActiveScene().name;

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
        if(SceneTransition.centerReached && animatorOff){
            GetComponent<Animator>().enabled = true;
            animatorOff = false;
        }
        
        if (Physics2D.OverlapCircle(this.transform.position, CollectRadius, PlayerMask) && isCollected == false)
        {
            
            PlayerPrefs.SetInt("StarsCollected", starsCollected +1);

            isCollected = true;
            SCR.FoundStar();
            // Spara om stjärnarn har blivit upplockad eller inte.
            PlayerPrefs.SetInt(saveKey, 1);
            PlayerPrefs.Save();
            particleSys.Play();
            collectionSoundEffect.Play();
            spriteRenderer.enabled = false;
            //gameObject.SetActive(false);
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
