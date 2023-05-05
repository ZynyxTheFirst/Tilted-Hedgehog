using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public float transitionTime = 1.0f;
    public Vector3 gameBoardOffset = new Vector3(10.0f, 0.0f, 0.0f);

    private bool transitioning = false;
    private Vector3 originalGameBoardPosition;
    private Vector3 newGameBoardPosition;
    private float transitionTimer = 0.0f;

    void Start()
    {
        originalGameBoardPosition = transform.position;
        newGameBoardPosition = originalGameBoardPosition + gameBoardOffset;
    }

    void Update()
    {
        if (transitioning)
        {
            transitionTimer += Time.deltaTime;
            float t = Mathf.Clamp01(transitionTimer / transitionTime);
            transform.position = Vector3.Lerp(originalGameBoardPosition, newGameBoardPosition, t);

            if (t >= 1.0f)
            {
                transitioning = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void StartTransition()
    {
        transitioning = true;
    }
}
