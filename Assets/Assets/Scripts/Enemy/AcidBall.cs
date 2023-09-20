using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBall : MonoBehaviour
{
    [SerializeField]
    private int _speed;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 1;
        _spriteRenderer = GameObject.FindGameObjectWithTag("Spider").transform.GetChild(0).GetComponent<SpriteRenderer>();
        
        if (_spriteRenderer.flipX == false) //Se hace aquí una vez para optimizar ya que la bola no cambia de dirección después
        {
            _direction = Vector3.right;
        }
        else
        {
            _direction = Vector3.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null && other.tag == "Player") //Para que no haya "fuego amigo" entre enemigos
        {
            hit.Damage();
        }

    }
}
