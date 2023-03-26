using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D enemyRb;
    private Collider2D enemyCol;
    private float enemySpeed = 2f;
    private float distanceToAttack = 5f;
    private float disengageDistance = 10f;
    private int curentHealth;
    private int maxHealth = 3;
    private Animator animator;
    private bool onGround;
    private Vector3 startPosition;
    private Vector3 firstOnGroundPosition;
    private Vector3 fallowPlayer;
    private Vector2 randomPositionX;
    private enum State
    {
        EnterMap,
        Roam,
        Attack,
        Dead,
    }
    private State state = State.EnterMap;

    public Transform attackPointE;
    public float attackRange = 0.5f;
    public LayerMask playerLay;
    private int hitDamage;
    private float attackDistance = 2.5f;
    private int enemyDamage = 1;
    // private bool attacked = false;
    public bool isAttacking = false;
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody2D>();
        enemyCol = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        curentHealth = maxHealth;
        
    }

    void Update()
    {
        IsMoving();
        fallowPlayer = new Vector3((player.transform.position.x - transform.position.x), 0, 0).normalized;
        switch (state)
        {
            case State.EnterMap:
                transform.Translate(fallowPlayer * Time.deltaTime * enemySpeed);
                if(onGround)
                {
                    firstOnGroundPosition = transform.position;
                    randomPositionX = GetRoamingPosition();
                    state = State.Roam;
                }
                break;
            case State.Roam:

                    if (randomPositionX.x >= transform.position.x)
                    {
                        transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
                    }
                    else if (randomPositionX.x <= transform.position.x)
                    {
                        transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
                    }
                    if (Vector2.Distance(transform.position, randomPositionX) < 0.5f)
                    {
                        randomPositionX = GetRoamingPosition();
                    }
                    if (Vector2.Distance(transform.position, player.transform.position) < distanceToAttack)
                    {
                    state = State.Attack;
                    }
                break;
            case State.Attack:
                transform.Translate(fallowPlayer * Time.deltaTime * enemySpeed);
                    
                if(Vector2.Distance(transform.position, player.transform.position) < attackDistance)
                {
                    animator.SetTrigger("Attack");
                    isAttacking = true;
                    if (isAttacking == true)
                    {
                        enemyRb.velocity = new Vector2(0, 0);
                    }
                }
                
                if(Vector2.Distance(transform.position, player.transform.position) > disengageDistance)
                    {
                        state = State.Roam;
                    }
                break;
            case State.Dead:
                
                    Die();               
                break;
            default:
                break;
        }

    }
    public void TakeDamage(int hitDamage)
    {
        curentHealth -= hitDamage;
        animator.SetTrigger("Hurt");
        if (curentHealth <= 0)
        {
            state = State.Dead;
        }
    }
    void Die()
    {
        animator.SetBool("isDead", true);
        gameObject.GetComponent<Enemy>().enabled = false;
    }
    void FinishAnimation()
    {
        enemyCol.enabled = false;
        enemyRb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
    void IsMoving()
    {
        Vector3 curentScale = gameObject.transform.localScale;
        if (startPosition.x < transform.position.x)
        {
            animator.SetFloat("Speed", 1);
            startPosition = transform.position;
            if(curentScale.x < 0)
            {
                curentScale.x *= -1;
                gameObject.transform.localScale = curentScale;
            }
        }
        else if (startPosition.x > transform.position.x)
        {
            animator.SetFloat("Speed", 1);
            startPosition = transform.position;
            if (curentScale.x > 0)
            {
                curentScale.x *= -1;
                gameObject.transform.localScale = curentScale;

            }
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    Vector2 GetRoamingPosition()
    {
        return new Vector2 (Random.Range(-9f, 18f), transform.position.y);
    }
    void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPointE.position, attackRange, playerLay);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerController>().PlayerHurt(enemyDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPointE.position, attackRange);
    }
}
