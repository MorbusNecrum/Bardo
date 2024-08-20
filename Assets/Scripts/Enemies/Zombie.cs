using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy, IChangeableSpeed
{
    [SerializeField] private int slamDamage;
    [SerializeField] private float slamPushBackSpeed;
    [SerializeField] private float speed;
    private float speedChangeTimer;
    private Vector2 direction;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        StartAbstract();
        lifeController.OnDeath.AddListener(Die);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DirectionToPlayer();
        Move();
        CheckEffects();
    }
    private void Die()
    {
        Destroy(gameObject);
    }

    private void DirectionToPlayer()
    {
        if (player != null)
        {
            direction = player.transform.position - transform.position;
            direction.Normalize();
            if (direction.x < 0) //va para la izq
            {
                spriteRenderer.flipX = false;

            }
            else if (direction.x > 0) //va para la derecha
            {
                spriteRenderer.flipX = true;

            }
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void Move()
    {
        rb.velocity = direction * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.tag == ("Player"))
            {
                collision.gameObject.GetComponent<IDamageable>().GetDamage(slamDamage);
                collision.gameObject.GetComponent<IExternalForceReciever>().AddExternalForce(direction * slamPushBackSpeed);
            }
        }
    }

    private void CheckEffects()
    {
        if(speedChangeTimer > 0)
        {
            speedChangeTimer -= Time.deltaTime;
            if(speedChangeTimer <= 0)
            {
                speedChangeTimer = 0;
                ChangeSpeed(1f);
            }
        }
    }

    public void ChangeSpeed(float multiplier)
    {
        speed = speed * multiplier;
    }
    public void ChangeSpeed(float multiplier, float duration)
    {
        speed = speed * multiplier;
        speedChangeTimer = duration;
    }
}
