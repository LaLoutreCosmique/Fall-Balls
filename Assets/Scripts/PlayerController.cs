using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SceneManagement sceneManager;
    public CameraFollow cameraFollow;
    private Interface canvas;

    private float directionalGravity = 15f; // Earth = 9.8
    private float verticalGravity = 23f; // Earth = 9.8
    public static bool freezeInput;
    private KeyCode[] alphaKeyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
    };

    public static int moves;
    private string previousMove;

    private void Start()
    {
        Physics.gravity = new Vector3(0, 0, 0);
        canvas = GameObject.Find("Canvas").GetComponent<Interface>();
        moves = 0;
    }
    
    void Update()
    {
        if (moves == 0)
        {
            Time.timeScale = 0f; // Freeze time for Interface timer
            Interface.time = 0f; // Reinitialize time
        }

        // Can use inputs if freezeInput = false
        if (!freezeInput)
        {
            // CHANGE GRAVITY
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Unfreeze time for Interface timer at first key pressed
                if (moves == 0) { Time.timeScale = 1f; }

                Physics.gravity = new Vector3(directionalGravity, -verticalGravity, 0); // UP
                if (previousMove != "up")
                {
                    moves++;
                    if (moves > 666) { moves = 666; }
                }
                previousMove = "up";
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Unfreeze time for Interface timer at first key pressed
                if (moves == 0) { Time.timeScale = 1f; }

                Physics.gravity = new Vector3(-directionalGravity, -verticalGravity, 0); // DOWN
                if (previousMove != "down")
                {
                    moves++;
                    if (moves > 666) { moves = 666; }
                }
                previousMove = "down";
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Unfreeze time for Interface timer at first key pressed
                if (moves == 0) { Time.timeScale = 1f; }

                Physics.gravity = new Vector3(0, -verticalGravity, directionalGravity); // LEFT
                if (previousMove != "left")
                {
                    moves++;
                    if (moves > 666) { moves = 666; }
                }
                previousMove = "left";
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Unfreeze time for Interface timer at first key pressed
                if (moves == 0) { Time.timeScale = 1f; }

                Physics.gravity = new Vector3(0, -verticalGravity, -directionalGravity); // RIGHT
                if (previousMove != "right")
                {
                    moves++;
                    if (moves > 666) { moves = 666; }
                }
                previousMove = "right";
            }
            // RESTART LEVEL
            else if (Input.GetKeyDown(KeyCode.R))
            {
                sceneManager.ReloadScene();
            }
            // CHANGE DEFAULT CAM POSITION
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                cameraFollow.ChangeTarget(-1);
            }

            // CHANGE FOLLOW TARGET
            for (int i = 0; i < alphaKeyCodes.Length; i++)
            {
                if (Input.GetKeyDown(alphaKeyCodes[i]))
                {
                    cameraFollow.ChangeTarget(i);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !canvas.hasPopup)
        {
            canvas.InvertDisplayMenu();
        }
    }    

    // Freeze/unfreeze inputs
    public void FreezeInputs(bool value)
    {
        if (value)
            freezeInput = true;
        else
            freezeInput = false;
    }
}
