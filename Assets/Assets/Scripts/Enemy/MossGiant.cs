using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MossGiant : Enemy
{
    int mossGiantVar;
    public override void Start()
    {
        base.Start();
        speed = 3;
        mossGiantVar= 3;        
    }

    public override void Damage()
    {
        
    }



}
