using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    float distance, restOfDistance;
    [SerializeField] Image Progressbar;
    [SerializeField] Transform finishPoint;
    Vector3 beginPoint;

    private void Awake()
    {
        beginPoint = new Vector3(0, 0, -84.406f);

    }
    private void Update()
    {

        distance = Vector3.Distance(finishPoint.position, beginPoint);
        restOfDistance = Vector3.Distance(PlayerMovement.instance.transform.position, beginPoint);
        Progressbar.fillAmount = 1 - (restOfDistance / distance)  ;
    }
}
