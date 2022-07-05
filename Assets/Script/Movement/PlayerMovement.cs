using DG.Tweening;
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
    [SerializeField] float forwardSpeed = 5;
    public Animator animator;
    int RandomAnim;
    bool isGameOver;

   [SerializeField] ParticleSystem RunDust;
   [SerializeField] ParticleSystem SpeedWind;
    


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
        forwardSpeed = 0; // began velocity

    }
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.20f, 2.05f), transform.position.y, transform.position.z);
    }
    private void Update()
    {
        forwardSpeedControl();
        ObserverEvents.CallMovement(); // Movement Event 
        IncreaseSpeed(); //when we slide left lane, show speedWind & dust
    }

    void forwardSpeedControl()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    public void Movement()
    {
        AnimationManager.instance.runAnim();
        
        
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
        if (other.gameObject.layer == LayerMask.NameToLayer("ChunkSpawner")) // Chunk pooler
        {
            PoolingManager.instance.SpawnFromPool("Chunk", ChunkSpawnerPoint.position, Quaternion.Euler(0, 0, 0));
            ChunkSpawnerPoint.transform.Translate(new Vector3(0, 0, 20f));
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("FinishSpawner")) //Finish Chunk pooler
        {
            PoolingManager.instance.SpawnFromPool("EndPlatform", FinishPoint.position, Quaternion.Euler(0, 0, 0));
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) //game over states
        {
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Ragdoll.instance.SetRagdoll(false, true);
            animator.enabled = false;
            if (isGameOver == false)
            {
                GameOverState();
            }
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("FinishPointPlayer"))  //win state
        {
            ObserverEvents.StopMovement();
            GameManager.Instance.gamestate = GameManager.GameState.Next; //When we complete level, show next level panel.

        }
    }
    void GameOverState()
    {
        isGameOver = true; //Control bool parameter
        GameManager.Instance.gamestate = GameManager.GameState.GameOver; //When we Hit the Enemy, show game over panel.
    }
    void IncreaseSpeed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RunDust.Play();
            SpeedWind.Play();
            forwardSpeed+=forwardSpeed*100/100; //Boost %100 speed
        }  
        if (Input.GetMouseButtonUp(0))
        {
            RunDust.Stop();
            SpeedWind.Stop();
            forwardSpeed = 5f;// return normal speed
        }

}

}

