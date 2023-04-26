using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimateMovement();
    }

    private void AnimateMovement()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 0.125) animator.SetBool("isMoving", true);
        else animator.SetBool("isMoving", false);
    }

    void OnCollisionEnter(Collision other) {
    if (other.gameObject.CompareTag("Wind")) {
        print("Hej");
        Vector3 windDirection = other.gameObject.transform.up;
        float windSpeed = 10.0f;
        GetComponent<Rigidbody>().AddForce(windDirection * windSpeed, ForceMode.Impulse);
    }
}
}