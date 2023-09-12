using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidBody;
    [SerializeField]
    private float _jumpForce = 3;
    [SerializeField]
    private float _speed = 2.5f;

    private PlayerAnimation _animScript;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _animScript = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        Attack();

    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && checkOnGround())
        {
            _animScript.Attack();
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.Space) && checkOnGround())
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            _animScript.Jump(true);
            StartCoroutine(WaitForJump());
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rigidBody.velocity = new Vector2(horizontalInput * _speed, _rigidBody.velocity.y);

        
        if (horizontalInput >= 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }

        _animScript.Move(horizontalInput);
    }

     IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(.75f);
        _animScript.Jump(false);
    }

    private bool checkOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 5f, 1 << 8); // 8 es la posición de la layer del ground. Se aplica con una máscara. 5f es un valor muy grande que nunca alcanzaremos con un salto
        //Debug.DrawRay(transform.position, Vector2.down * 0.57f, Color.green);
        if (hit.collider != null)
        {
            if (hit.distance-0.72f < 0.1f) // 0.57 es la mitad de la altura del sprite y desde la altura que se inicia el raycast
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

   
}
