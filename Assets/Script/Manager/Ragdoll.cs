using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public static Ragdoll instance;


    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        reachPhysics(false);
        ReachCollision(true);
    }

    void reachPhysics(bool state)
    {
        Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody item in rb)
        {
            item.isKinematic = state; //reach whole rigidbodies parent
        }
    } 
    
    void ReachCollision(bool state)
    {
        Collider[] cd = GetComponentsInChildren<Collider>();
        foreach (Collider item in cd)
        {
            item.enabled = state; //reach whole Colliders parent
        }
    }
    public void SetRagdoll(bool RbOn, bool CollisionOn)
    {
        reachPhysics(RbOn);
        ReachCollision(CollisionOn);
    }


}
