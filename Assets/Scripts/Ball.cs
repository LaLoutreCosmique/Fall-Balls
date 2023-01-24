using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    public SceneManagement scene;
    public CameraFollow cameraFollow;

    public int ballID;
    public bool cantBeTracked;

    [SerializeField] private Color selectedColor;
    private Color baseColor;

    private void Start()
    {
        baseColor = GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            DeleteBall();
        }
    }

    public void ChangeColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", selectedColor);
    }
    
    public void ResetColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", baseColor);
    }

    public void DeleteBall()
    {
        cantBeTracked = true;
        scene.DecreaseBallsLeft();
        Invoke("DeBa", 1f);
    }

    private void DeBa()
    {
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<Rigidbody>());
    }
}
