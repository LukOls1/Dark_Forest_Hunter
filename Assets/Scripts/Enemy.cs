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
    private Vector3 newPosition;
    private Vector3 fallowPlayer;
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
                    state = State.Roam;
                }
                break;
            case State.Roam:
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
        if(startPosition.x != transform.position.x)
        {
            animator.SetFloat("Speed", Mathf.Abs(transform.position.x));
            startPosition = transform.position;
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
}
