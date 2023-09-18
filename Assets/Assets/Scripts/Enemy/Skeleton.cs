using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy
{


    private bool _cooldown = true;
    
    public override void Start()
    {
        base.Start();
        health = 3;
        Health = health;
        maxAttackRange = 2f;
        attackRange = Random.Range(0.3f, maxAttackRange);
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

    public override void Attack()
    {
        base.Attack();
        float distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);
        //Debug.Log(distance);
     
        if (distance < attackRange & _cooldown)
        {
            Vector3 direction = player.transform.localPosition - transform.localPosition;
            if (direction.x > 0 )
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
            animator.SetTrigger("Attack");
            _cooldown = false;
            StartCoroutine(CoolDown());
        }
     
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1.5f);
        attackRange = Random.Range(0.3f, maxAttackRange);
        //Debug.Log("Range: " + _attackRange);
        _cooldown = true;
    }


}
