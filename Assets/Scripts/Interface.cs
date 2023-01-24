using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Interface : MonoBehaviour
{
    public PlayerController player;
    private GameObject menu;
    private GameObject menuBg;
    private TextMeshProUGUI movesText;
    private TextMeshProUGUI timeText;

    private string baseMovesText;
    private string baseTimeText;
    public static float time;
    public static bool saveTime;
    public bool menuOpened;
    public bool hasPopup;

    private void Start()
    {
        menu = GameObject.Find("MainMenu");
        menuBg = GameObject.Find("BgMenu");
        movesText = GameObject.Find("Moves").GetComponent<TextMeshProUGUI>();
        timeText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();

        EnableMenu(false);

        menuOpened = false;
        saveTime = false;
        baseMovesText = movesText.text;
        baseTimeText = timeText.text;
    }

    private void Update()
    {
        if (hasPopup)
        {
            PlayerController.freezeInput = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameObject.Find("Start Popup").SetActive(false);
                hasPopup = false;

                player.FreezeInputs(false);
            }
        }

        // Write moves count
        movesText.text = baseMovesText + PlayerController.moves;

        // Write time
        if (!saveTime) { time += Time.deltaTime; }
        timeText.text = baseTimeText + Math.Round(time, 1) + "s";
    }

    public void EnableMenu(bool value)
    {
        if (value)
        {
            // Game paused here
            Time.timeScale = 0f;

            menu.SetActive(true);
            menuBg.SetActive(true);

            PlayerController.freezeInput = true;

            menuOpened = true;
        }
        else
        {
            menu.GetComponent<MainMenu>().CloseMenu();
        }
    }

    // Invert display (enable/disable) the menu
    public void InvertDisplayMenu()
    {
        if (menuOpened)
            EnableMenu(false);
        else
            EnableMenu(true);
    }

    public void SaveTime()
    {
        saveTime = true;
    }
}
