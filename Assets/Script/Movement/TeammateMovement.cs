using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateMovement : MonoBehaviour
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
            PoolingManager.instance.SpawnFromPool("Teammate", spawnPoint.position, Quaternion.Euler(0, 0, 0));

        }
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
