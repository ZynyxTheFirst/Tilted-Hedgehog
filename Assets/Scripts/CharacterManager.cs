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
        if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 0.2) animator.SetBool("isMoving", true);
        else animator.SetBool("isMoving", false);
    }
}