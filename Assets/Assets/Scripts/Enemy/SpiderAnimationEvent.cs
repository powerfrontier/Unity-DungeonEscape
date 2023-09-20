using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider _spider;

    public void Start()
    {
        _spider = GameObject.FindGameObjectWithTag("Spider").GetComponent<Spider>();
    }

    public void CreateAcidBall()
    {
        //Debug.Log("SpiderAnimationEvent::Creating acid ball");
        _spider.CreateAcidBall();
         
    }
}
