using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;
    Animator animator;
    int randGnr;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
       randGnr= UnityEngine.Random.Range(1, 3);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    public void runAnim()
    {
        animator.SetBool("Run", true);

    }
    public void winAnim()
    {
        animator.SetBool("Run", false);
        animator.SetInteger("RandomWin", randGnr);

    }

}
