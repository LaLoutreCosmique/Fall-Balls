using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public int triggerID;

    private void OnTriggerEnter(Collider other)
    {
        EventManager.StartWallEvent(triggerID);
    }
}
