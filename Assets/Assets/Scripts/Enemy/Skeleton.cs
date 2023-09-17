using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy
{

    public override void Start()
    {
        base.Start();
        health = 3;
        Health = health;
    }
    public override void Damage()
    {
        Health--;
        animator.SetTrigger("Hit");
        
        if (Health < 1)
        {
            animator.SetBool("Death", true);
        }
    }


}
