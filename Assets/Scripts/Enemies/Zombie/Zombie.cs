using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy, IChangeableSpeed , IFactoryzable
{
    [SerializeField] ZombieFlyweight zombieData;
    private float currentSpeed;
    private float speedChangeTimer;
    private Vector2 direction;
    private float playerDistance = 100;


    public float PlayerDistance => playerDistance;
    public float ChaseDistance => zombieData.chaseDistance;

    public Vector2 Direction => direction;
    public float CurrentSpeed => currentSpeed;
    public string PrefabID => zombieData.prefabId;

    public int SlamDamage => zombieData.basicAttackDamage;
    public float SlamPushBackForce => zombieData.slamPushBackForce;

    private StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        StartAbstract();
        lifeController.OnDeath.AddListener(Die);
        stateMachine = GetComponent<StateMachine>();
        currentSpeed = zombieData.speed;
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
        }
        else
        {
            direction = Vector2.zero;
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
        currentSpeed = zombieData.speed * multiplier;
    }
    public void ChangeSpeed(float multiplier, float duration)
    {
        currentSpeed = zombieData.speed * multiplier;
        speedChangeTimer = duration;
    }
}
