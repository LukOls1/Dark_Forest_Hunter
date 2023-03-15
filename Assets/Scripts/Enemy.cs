using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private Collider2D enemyCol;
    private int curentHealth;
    private int maxHealth = 3;
    private Animator animator;
    private bool animationCompleated = false;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyCol = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        curentHealth = maxHealth;
    }

    void Update()
    {
        
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
        //gameObject.GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
    }
    void FinishAnimation()
    {
        enemyCol.enabled = false;
        enemyRb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
}
