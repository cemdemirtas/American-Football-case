using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public abstract class EnemyMovement:MonoBehaviour
{
    float speed = 2.5f;
    Rigidbody rb;
    [SerializeField] Transform spawnPoint;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("enemy hit the wall");
            gameObject.SetActive(false);
            PoolingManager.instance.SpawnFromPool("Opponent", spawnPoint.position, Quaternion.Euler(0,180,0));

        }
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }



}
