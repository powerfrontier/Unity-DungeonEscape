using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spider : Enemy
{
    int spiderVar;
    public override void Start()
    {
        base.Start();
        speed = 2;
        spiderVar = 2;
    }

    public override void Damage()
    {
        
    }

}
