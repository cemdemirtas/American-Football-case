using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    float distance, restOfDistance;
    [SerializeField] Image Progressbar;
    [SerializeField] Image ProgressbarBack;
    [SerializeField] Transform finishPoint;
    Vector3 beginPoint;
    bool isNext=false;

    private void Awake()
    {
        beginPoint = new Vector3(0, 0, -84.406f);
        Progressbar.gameObject.SetActive(false);
        ProgressbarBack.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (PlayerMovement.instance!=null)
        {
            distance = Vector3.Distance(finishPoint.position, beginPoint);
            restOfDistance = Vector3.Distance(PlayerMovement.instance.transform.position, beginPoint);
            Progressbar.fillAmount = 1 - (restOfDistance / distance);
        }
        if (Progressbar.fillAmount>0.1f)
        {
            Progressbar.gameObject.SetActive(true); // when we start game show the progressBar.
            ProgressbarBack.gameObject.SetActive(true);

        }
    }
    
}
