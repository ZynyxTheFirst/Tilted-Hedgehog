using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject key;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    //Kollar om nyckeln är upplockad och sätter då igång animatorn.
    void Update() {
        if (key.GetComponent<PickupKey>().getPickedUp() == true) {
            animator.enabled = true;
        }
    }
}
