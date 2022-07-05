﻿using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    Touch touch;
    Quaternion BeginRotation;
    Vector3 BeginPosition;
    [SerializeField] Transform ChunkSpawnerPoint;
    [SerializeField] Transform FinishPoint;
    float forwardSpeed = 5;
    public Animator animator;
    int RandomAnim;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        BeginRotation = Quaternion.identity;
        BeginPosition = transform.position;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.20f, 2.05f), transform.position.y, transform.position.z);
    }
    private void Update()
    {
        ObserverEvents.CallMovement();
        RandomAnim = UnityEngine.Random.Range(1, 2);

    }


    public void Movement()
    {
        AnimationManager.instance.runAnim();
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Stationary)
            {
                transform.DOMoveX(-1.5f, 0.5f); //left lane
                transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.5f); // Bending by z axis
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                transform.DOMoveX(BeginPosition.x, 0.5f); //right lane
                transform.DORotateQuaternion(BeginRotation, 1f); // return begin rotation while break touch
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ChunkSpawner"))
        {
            PoolingManager.instance.SpawnFromPool("Chunk", ChunkSpawnerPoint.position, Quaternion.Euler(0, 0, 0));
            ChunkSpawnerPoint.transform.Translate(new Vector3(0, 0, 20f));
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("FinishSpawner"))
        {
            PoolingManager.instance.SpawnFromPool("EndPlatform", FinishPoint.position, Quaternion.Euler(0, 0, 0));
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Ragdoll.instance.SetRagdoll(false, true);
            animator.enabled = false;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("FinishPointPlayer"))
        {
            ObserverEvents.StopMovement();


        }
    }


}

