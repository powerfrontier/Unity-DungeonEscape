using UnityEngine;

public class MossGiant : Enemy
{

    public override void Start()
    {
        base.Start();
        speed = 3;
        health = 5;
        Health = health;
        maxAttackRange = 2.5f;
        attackRange = Random.Range(0.3f, maxAttackRange);        
    }

}
