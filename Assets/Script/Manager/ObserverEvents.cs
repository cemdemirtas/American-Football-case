using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverEvents : MonoBehaviour
{
    public static event Action MovementEvent;
    private void Start()
    {
        MovementEvent?.Invoke();
    }
}
