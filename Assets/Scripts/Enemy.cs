using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D enemyRb;
    private Collider2D enemyCol;
    private float enemySpeed = 3;
    private int curentHealth;
    private int maxHealth = 3;
    private Animator animator;
    private bool onGround;
    private Vector3 startPosition;
    private Vector3 firstOnGroundPosition;
    private Vector3 fallowPlayer;
    private float randomPositionX;
    private enum State
    {
        EnterMap,
        Roam,
    }
    private State state = State.EnterMap;
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
                    Debug.Log(randomPositionX.ToString());
                    state = State.Roam;
                }
                break;
            case State.Roam:
                if(randomPositionX != transform.position.x)
                {
                    //transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
                    transform.Translate(new Vector3((randomPositionX - transform.position.x), 0, 0).normalized * Time.deltaTime * enemySpeed);      
                    if(randomPositionX == transform.position.x )
                    {
                        Debug.Log("hit");
                       // randomPositionX = GetRoamingPosition();
                       // transform.Translate(new Vector3((randomPositionX - transform.position.x), 0, 0).normalized * Time.deltaTime * enemySpeed);
                    }
                }
                break;
            default:
                break;
        }

    }
    public void TakeDamage(int hitDamage)
    {
        curentHealth -= hitDamage;
        animator.SetTrigger("Hurt");
        Debug.Log(curentHealth.ToString());
        if (curentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("isDead", true);
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
    Vector3 GetRandomDir()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, 0).normalized;
    }
    float GetRoamingPosition()
    {
        return Random.Range(-9f, 18f);
    }
}
