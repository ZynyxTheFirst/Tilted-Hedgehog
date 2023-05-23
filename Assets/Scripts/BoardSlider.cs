using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardSlider : MonoBehaviour
{
    public float transitionTime = 1.0f;
    public Vector3 gameBoardOffset = new Vector3(10.0f, 0.0f, 0.0f);

    private bool slidingIn = false;
    private bool slidingOut = false;
    private Vector3 originalGameBoardPosition;
    private Vector3 newGameBoardPosition;
    private float transitionTimer = 0.0f;

    void Start()
    {
        originalGameBoardPosition = transform.position;
        newGameBoardPosition = originalGameBoardPosition + gameBoardOffset;
        SlideIn();
    }

    void Update()
    {
        if (slidingIn)
            SlideIn();

        if (slidingOut)
            SlideOut();
    }

    private void SlideIn()
    {
        transitionTimer += Time.deltaTime;
        float t = Mathf.Clamp01(transitionTimer / transitionTime);
        transform.position = Vector3.Lerp(newGameBoardPosition, originalGameBoardPosition, t);

        if (t >= 1.0f)
        {
            slidingIn = false;
        }
    }

    private void SlideOut()
    {
        transitionTimer += Time.deltaTime;
        float t = Mathf.Clamp01(transitionTimer / transitionTime);
        transform.position = Vector3.Lerp(originalGameBoardPosition, newGameBoardPosition, t);

        if (t >= 1.0f)
        {
            slidingOut = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void StartSlideInTransition()
    {
        slidingIn = true;
        transitionTimer = 0.0f;
    }

    public void StartSlideOutTransition()
    {
        slidingOut = true;
        transitionTimer = 0.0f;
    }
}
