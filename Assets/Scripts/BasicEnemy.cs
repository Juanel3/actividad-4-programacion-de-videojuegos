using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveRange = 5f;
    private bool movingRight = true;
    private Rigidbody2D rb;
    private float initialX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialX = transform.position.x;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveDirection = movingRight ? 1f : -1f;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        
        if (Mathf.Abs(transform.position.x - initialX) >= moveRange)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        initialX = transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (collision.relativeVelocity.y < 0) 
            {
                
                Destroy(gameObject);
            }
            else
            {
                // Mover al jugador al punto de inicio
                collision.gameObject.GetComponent<PlayerController>().Respawn();
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            
            Flip();
        }
    }
}


