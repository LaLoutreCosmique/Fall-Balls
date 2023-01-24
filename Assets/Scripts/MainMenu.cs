using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public PlayerController player;
    public Interface canvas;
    public GameObject bg;

    public void CloseMenu()
    {
        // Resume game
        if (PlayerController.moves != 0) { Time.timeScale = 1f; }

        gameObject.SetActive(false);
        bg.SetActive(false);

        PlayerController.freezeInput = false;

        canvas.menuOpened = false;
    }

    public void OpenLevelSelection()
    {
        //SceneManager.LoadScene("LevelSelection");
    }

    public void QuitGame()
    {
        Debug.Log("Quit !");
        Application.Quit();
    }
}
