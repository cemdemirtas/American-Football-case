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
        BeginPoint = new Vector3(transform.position.x, -0.53f, transform.position.z);

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


 


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("FinishPointEnemy"))
        {
            Debug.Log("finishhh");
            gameObject.SetActive(false);
            //PoolingManager.instance.SpawnFromPool("Opponent", spawnPoint.position, Quaternion.Euler(0, -180, 0));
            PoolingManager.instance.SpawnFromPool("Opponent", new Vector3(spawnPoint.position.x, -0.53f, spawnPoint.position.z), Quaternion.Euler(0, -180, 0));
        }
    }
    private void Update()
    {
        //transform.position = new Vector3(transform.position.x, -0.53f, transform.position.z);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }



}
