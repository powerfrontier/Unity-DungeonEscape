using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _destination = new Vector3();
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        speed = 3;
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {   
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
 
    }

    private void Movement()
    {
        // Primero animación de Idle y después flip, por eso el flip va aquí y no justo después del trigger de la animación, así el flip se hace después (mirar que es el _destination y no la position)
        if (_destination == pointA.position)
        {
            _spriteRenderer.flipX = true;
        }
        else{
            _spriteRenderer.flipX = false;
        }

        if (transform.position.x == pointA.position.x)
        {
            _destination = pointB.position;
            _animator.SetTrigger("Idle");
            _spriteRenderer.flipX = false;
        }
        else if (transform.position.x == pointB.position.x)
        {
            _destination = pointA.position;
            _animator.SetTrigger("Idle");
            
        }

        transform.position = Vector3.MoveTowards(transform.position, _destination, speed*Time.deltaTime);
    }
}
