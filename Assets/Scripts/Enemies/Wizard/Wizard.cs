using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float castingDistance;
    private float speedChangeTimer;
    private Vector2 direction;
    private float playerDistance = 100;
    public float PlayerDistance => playerDistance;
    public float ChaseDistance => chaseDistance;
    public float CastingDistance => castingDistance;

    public Vector2 Direction => direction;
    public float Speed => speed;

    private SpriteRenderer spriteRenderer;
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

    private void CheckEffects()
    {
        if (speedChangeTimer > 0)
        {
            speedChangeTimer -= Time.deltaTime;
            if (speedChangeTimer <= 0)
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
    private void Die()
    {
        Destroy(gameObject);
    }
}
