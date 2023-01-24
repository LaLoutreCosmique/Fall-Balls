using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Used for targets IDs comparison

public class CameraFollow : MonoBehaviour
{
    public SceneManagement scene;

    public static List<Ball> targets;
    public int targetNumber;

    private Vector3 offset = new Vector3(0f, 10f, 0f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 defaultPosition;
    private bool freezeAtDefault;

    private void Start()
    {
        // Set default camera position
        defaultPosition = transform.position;

        // Find the balls to target
        targets = new List<Ball>(FindObjectsOfType<Ball>());
        // Sort them in order by IDs
        targets = targets.OrderBy(b => b.ballID).ToList();

        FreezeAtDefaultPosition(true);
    }

    void Update()
    {
        if (freezeAtDefault)
        {
            // Move camera to default position
            transform.position = Vector3.SmoothDamp(transform.position, defaultPosition, ref velocity, smoothTime);
        }
        else
        {
            // Verify if ball exists
            if (!targets[targetNumber].cantBeTracked)
            {
                // Smoothly follow selected target
                Vector3 targetPosition = targets[targetNumber].transform.position + offset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
            else
            {
                ChangeTarget(-1);
            }
        }
    }

    public void ChangeTarget(int targetRequest)
    {
        if (targetRequest == -1)
        {
            // Set the camera at default position
            if (targets[targetNumber].GetComponent<MeshRenderer>())
            {
                targets[targetNumber].ResetColor();
            }
            targetNumber = 0;

            FreezeAtDefaultPosition(true);
        }
        else if (targetRequest < targets.Count && !SceneManagement.levelFinished)
        {
            // Change the target followed by the 
            if (targets[targetNumber].GetComponent<MeshRenderer>())
            {
                targets[targetNumber].ResetColor();
            }

            if (targets[targetRequest].GetComponent<MeshRenderer>())
            {
                targets[targetRequest].ChangeColor();
            }

            targetNumber = targetRequest;

            FreezeAtDefaultPosition(false);
        }
        else
        {
            ChangeTarget(-1);
            Debug.Log($"Not valid : {targets.Count} balls left");
        }
    }

    public void FreezeAtDefaultPosition(bool value)
    {
        if (value)
            freezeAtDefault = true;
        else
            freezeAtDefault = false;
    }
}
