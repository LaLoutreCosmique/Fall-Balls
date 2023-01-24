using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<int> DisableWallEvent;

    public static void StartWallEvent(int id)
    {
        DisableWallEvent?.Invoke(id);
    }
}
