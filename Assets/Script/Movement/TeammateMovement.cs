using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateMovement : MonoBehaviour
{
    float speed = 2.5f;
    Rigidbody rb;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Vector3 BeginPoint;


    private void Awake()
    {
        BeginPoint = new Vector3(transform.position.x, -0.72f, transform.position.z);

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("FinishPointTeammate"))
        {
            Debug.Log("finishhh");
            gameObject.SetActive(false);
            //PoolingManager.instance.SpawnFromPool("Teammate", spawnPoint.position, Quaternion.Euler(0, 0, 0));
            PoolingManager.instance.SpawnFromPool("Teammate", new Vector3(spawnPoint.position.x, -0.72f, spawnPoint.position.z), Quaternion.Euler(0, 0, 0));

        }
    }
    private void Update()
    {
        //transform.position = new Vector3(transform.position.x, BeginPoint.y, transform.position.z);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

}
