using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private GameObject key;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(key.GetComponent<PickupKey>().getPickedUp() == true) {
            animator.enabled = true;
        }
    }

}
