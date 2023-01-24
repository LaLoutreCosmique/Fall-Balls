using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Material material;
    private BoxCollider col;
    private bool disable = false;
    public int wallID;

    private void Start()
    {
        EventManager.DisableWallEvent += DisableWall;
        material = GetComponent<Renderer>().sharedMaterial;
        col = GetComponent<BoxCollider>();

        material.SetFloat("_Metallic", 0.8f);
    }

    private void Update()
    {
        if (disable)
        {
            material.SetFloat("_Metallic", 0f);
            col.enabled = false;
        }
    }

    private void DisableWall(int triggerID)
    {
        if (triggerID == wallID)
            disable = true;
    }

    private void OnDisable()
    {
        EventManager.DisableWallEvent -= DisableWall;
    }
}
