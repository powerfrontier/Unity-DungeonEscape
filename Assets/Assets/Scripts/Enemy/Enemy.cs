using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{

    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    public Transform pointA, pointB;


    protected Vector3 destination = new Vector3();
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Player player;
    protected float attackRange;
    protected float maxAttackRange;

    public int Health {get; set;}

    public abstract void Damage();


    public virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Hit")  ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Death") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") )
        {
            return;
        }
        Movement();
        Attack();
    }

    public virtual void Attack()
    {
        
    }

    public virtual void Movement()
    {
        // Primero animación de Idle y después flip, por eso el flip va aquí y no justo después del trigger de la animación, así el flip se hace después (mirar que es el _destination y no la position)
        if (destination == pointA.position)
        {
            spriteRenderer.flipX = true;
        }
        else{
            spriteRenderer.flipX = false;
        }

        if (transform.position.x == pointA.position.x)
        {
            destination = pointB.position;
            animator.SetTrigger("Idle");
        }
        else if (transform.position.x == pointB.position.x)
        {
            destination = pointA.position;
            animator.SetTrigger("Idle");
            
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
    }

}
