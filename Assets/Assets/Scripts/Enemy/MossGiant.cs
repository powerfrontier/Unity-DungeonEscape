using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MossGiant : Enemy
{
    int speed = 3;
    private bool _switch = false;
    public override void Update()
    {
   
        if (!_switch)
        {
            //transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, speed*Time.deltaTime);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, speed*Time.deltaTime);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // if (transform.position == pointA.position || transform.position == pointB.position)
        if (transform.position.x <= pointA.position.x || transform.position.x >= pointB.position.x)
        {
            _switch = !_switch;
            
        }
       
    }
}
