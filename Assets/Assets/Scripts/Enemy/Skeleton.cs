using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy
{


    private bool _cooldown = true;
    private float _attackRange;
    public override void Start()
    {
        base.Start();
        health = 3;
        Health = health;
        _attackRange = Random.Range(0.3f, 2f);
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
     
        if (distance < _attackRange & _cooldown)
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
        _attackRange = Random.Range(0.3f, 2f);
        //Debug.Log("Range: " + _attackRange);
        _cooldown = true;
    }


}
