using System.Collections;
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
    private bool _cooldown = true;
    [SerializeField]
    private GameObject _diamond;
    [SerializeField]
    private float _diamondDistance = 0.5f;

  

    public virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

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
        if (player != null)
            Attack();
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

    public virtual void Attack()
    {
        float distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);
     
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
        _cooldown = true;
    }

    public int Health {get; set;}

    public virtual void Damage()
    {
        Debug.Log("Hit:" + this.GetType());
        if(Health > 0) //Para que no entre multiples veces cuando esté ya en Death (health==0)
        {
            Health--;
            animator.SetTrigger("Hit");
            
            if (Health < 1)
            {
                animator.SetBool("Death", true);
                StartCoroutine(Diamonds());
                Destroy(this.gameObject, 5f);
            }
        }
    }

    protected IEnumerator Diamonds()
    {
        yield return new WaitForSeconds(3);
        DropDiamonds();
    }

    protected void DropDiamonds()
    {
        if (gems%2 == 0)
        {
            Vector3 position = new Vector3(transform.position.x - _diamondDistance/2, transform.position.y, transform.position.z);
            Instantiate(_diamond, position, Quaternion.identity);
            for (int i=1; i<gems/2; i++)
            {
                position = new Vector3(transform.position.x - _diamondDistance/2 - _diamondDistance*i, transform.position.y, transform.position.z);
                Instantiate(_diamond, position, Quaternion.identity);
            }
            position = new Vector3(transform.position.x + _diamondDistance/2, transform.position.y, transform.position.z);
            Instantiate(_diamond, position, Quaternion.identity);
            for (int i=1; i<gems/2; i++)
            {
                position = new Vector3(transform.position.x + _diamondDistance/2 + _diamondDistance*i, transform.position.y, transform.position.z);
                Instantiate(_diamond, position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(_diamond, transform.position, Quaternion.identity);
            for (int i=1; i<=gems/2; i++)
            {
                Vector3 position = new Vector3(transform.position.x - _diamondDistance*i, transform.position.y, transform.position.z);
                Instantiate(_diamond, position, Quaternion.identity);
            }
            for (int i=1; i<=gems/2; i++)
            {
                Vector3 position = new Vector3(transform.position.x + _diamondDistance*i, transform.position.y, transform.position.z);
                Instantiate(_diamond, position, Quaternion.identity);
            }

        }
    }



    //TODO: error: de estado death se puede ir a hit otra vez -> retocar mapa de estados de animaciones

}
