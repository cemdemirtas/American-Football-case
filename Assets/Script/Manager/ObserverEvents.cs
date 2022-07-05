using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverEvents : MonoBehaviour
{
    public static event Action MovementEvent;


    private void Start()
    {
        MovementEvent += CallMovement;
        MovementEvent += StopMovement;
    }
    public static void CallMovement()
    {
        PlayerMovement.instance.Movement();
        MovementEvent?.Invoke();
    }  
    public static void StopMovement()
    {
        AnimationManager.instance.winAnim();
        PlayerMovement.instance.enabled = false;
        MovementEvent?.Invoke();
    }
}
