using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static bool levelFinished;
    public static int ballsLeft;

    private void Start()
    {
        ballsLeft = FindObjectsOfType<Ball>().Length;
        levelFinished = false;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CompleteLevel()
    {
        levelFinished = true;
        GoToNextLevel();
    }

    public void GoToNextLevel()
    {
        if ((SceneManager.sceneCountInBuildSettings - 1) != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void DecreaseBallsLeft()
    {
        ballsLeft--;

        if (ballsLeft == 0)
        {
            Interface.saveTime = true;
            PlayerController.freezeInput = true;
            Invoke("CompleteLevel", 2f);
        }
    }
}
