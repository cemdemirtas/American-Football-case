using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class EnemyMovement : MonoBehaviour
{
    float speed = 2.5f;
    Rigidbody rb;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Vector3 BeginPoint;

    private void Awake()
    {
        BeginPoint = new Vector3(transform.position.x, -0.9f, transform.position.z);
        BeginPoint = transform.position;

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("FinishPointEnemy"))
        {
            Debug.Log("finishhh");
            gameObject.SetActive(false);
            PoolingManager.instance.SpawnFromPool("Opponent", spawnPoint.position, Quaternion.Euler(0, -180, 0));
        }

    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, BeginPoint.y, transform.position.z);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }



}
