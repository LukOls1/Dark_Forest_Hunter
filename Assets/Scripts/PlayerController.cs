using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGameActive = true;
    // Move vars
    [SerializeField] private float playerSpeed = 7.0f;
    private Vector2 xMove;
    private bool groundedPlayer = true;
    private float horizontalInput;
    private Animator animator;
    [SerializeField] private float jumpForce = 8.0f;
    private bool isFacingRight = true;
    private Rigidbody2D playerRb;

    //Attack vars 
    [SerializeField]
    private Animator bloodFX;
    [SerializeField] 
    private float attackRange = 0.5f;
    private int hitDamage = 1;
    public Transform attackPoint;
    private float timeToNextAttack = 0;
    public LayerMask enemyLayers;
    private bool isDead = false;
    [SerializeField] private PlayerStatsSO playerStats;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && groundedPlayer && Time.time >= timeToNextAttack && !isDead)
        {
            Attack();
            timeToNextAttack = Time.time + playerStats.AtkSpeed;
        }
    }
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        xMove = new Vector2(horizontalInput * playerSpeed, 0);

        if (horizontalInput > 0 && !isFacingRight && !isDead)
        {
            Flip();
        }
        if (horizontalInput < 0 && isFacingRight && !isDead)
        {
            Flip();
        }
        if (!isDead)
        {
            transform.Translate(Vector2.right * xMove * Time.deltaTime);
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        } 

        if (Input.GetButton("Jump") && groundedPlayer == true && !isDead)
        {
            Jump();
        }
        if (playerStats.Life <= 0)
        {
            isDead = true;
            animator.SetBool("isDead", true);
            horizontalInput = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundedPlayer = true;
            animator.SetBool("isJumping", false);

        }
    }



    void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }
    void Jump()
    {
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        groundedPlayer = false;
        animator.SetBool("isJumping", true);
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(hitDamage);
        }
    }
    public void PlayerHurt(int takeHit)
    {
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
        playerStats.Life -= takeHit;
        Debug.Log(playerStats.Life.ToString());
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
