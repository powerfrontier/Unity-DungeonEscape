using UnityEngine;

public class Skeleton : Enemy
{

    public override void Start()
    {
        base.Start();
        speed = 1;
        health = 3;
        Health = health;
        maxAttackRange = 2f;
        attackRange = Random.Range(0.3f, maxAttackRange);
    }

}
