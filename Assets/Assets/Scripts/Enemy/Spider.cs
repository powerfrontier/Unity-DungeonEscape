using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField]
    private GameObject _acidBall;
    [SerializeField]
    private GameObject _acidBallsContainer;

    public override void Start()
    {
        base.Start();
        speed = 2;
        health = 1; // Es 1 solo porque no hay animacion de Hit y se pasa directamente a Death
        Health = health;
        maxAttackRange = 4f;
        attackRange = Random.Range(1.0f, maxAttackRange);
        
    }

    public override void Damage()
    {
        Debug.Log("Hit:" + this.GetType());
        if (Health > 0)
        {
            Health--;
            if (Health < 1)
            {
                animator.SetTrigger("Death");
                StartCoroutine(Diamonds());
                Destroy(this.gameObject, 5f);
            }
        }

    }

    public void CreateAcidBall()
    {
        GameObject ball = Instantiate(_acidBall, transform.position, Quaternion.identity,_acidBallsContainer.transform);
        Destroy(ball, 5f);
    }

   



}
