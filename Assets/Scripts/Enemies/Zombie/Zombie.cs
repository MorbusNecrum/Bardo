using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy, IChangeableSpeed , IFactoryzable
{
    private string prefabId = "Zombie";

    [SerializeField] private int slamDamage;
    [SerializeField] private float slamPushBackForce;
    [SerializeField] private float speed;
    [SerializeField] private float chaseDistance;
    private float speedChangeTimer;
    private Vector2 direction;
    private float playerDistance = 100;

    private SpriteRenderer spriteRenderer;

    public float PlayerDistance => playerDistance;
    public float ChaseDistance => chaseDistance;

    public Vector2 Direction => direction;
    public float Speed => speed;

    public string PrefabID => prefabId;

    private StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        StartAbstract();
        lifeController.OnDeath.AddListener(Die);
        spriteRenderer = GetComponent<SpriteRenderer>();
        stateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        DirectionToPlayer();
        stateMachine.UpdateState();
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
            playerDistance = direction.magnitude;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.tag == ("Player"))
            {
                collision.gameObject.GetComponent<IDamageable>().GetDamage(slamDamage);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * slamPushBackForce, ForceMode2D.Impulse);
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
