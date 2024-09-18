using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy , IFactoryzable
{
    private string prefabId = "Wizard";

    [SerializeField] private float speed;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float castingDistance;
    [SerializeField] private float castCD;
    private float castCDTimer = 0;

    private float speedChangeTimer;
    private Vector2 direction;
    private float playerDistance = 100;
    public float PlayerDistance => playerDistance;
    public float ChaseDistance => chaseDistance;
    public float CastingDistance => castingDistance;
    public float CastCD
    {
        get { return castCD; }
        set { castCD = value; }
    }

    public float CastCDTimer
    {
        get { return castCDTimer; }
        set { castCDTimer = value; }
    }

    public Vector2 Direction => direction;
    public float Speed => speed;

    public string PrefabID => prefabId;

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
        CheckTimers();
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

    private void CheckTimers()
    {
        //DURACION DEL CAMMBIO DE VELOCIDAD, lo devuelve a la vel normal
        if (speedChangeTimer > 0)
        {
            speedChangeTimer -= Time.deltaTime;
            if (speedChangeTimer <= 0)
            {
                speedChangeTimer = 0;
                ChangeSpeed(1f);
            }
        }

        //COOLDOWN DEL CASTEO, lo pone en 0
        if(castCDTimer > 0)
        {
            
            castCDTimer -= Time.deltaTime;
            if(castCDTimer <= 0)
            {
                castCDTimer = 0;
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
