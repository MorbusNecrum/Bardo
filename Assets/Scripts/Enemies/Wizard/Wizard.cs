using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy , IChangeableSpeed, IFactoryzable
{
    [SerializeField] WizardFlyweight wizardData;

    private float currentSpeed;

    private float castCDTimer = 0;
    private float speedChangeTimer;
    private Vector2 direction;
    private float playerDistance = 100;
    public float PlayerDistance => playerDistance;
    public float ChaseDistance => wizardData.chaseDistance;
    public float CastingDistance => wizardData.castingDistance;
    public float CastCD
    {
        get { return wizardData.castCD; }
    }

    public float CastCDTimer
    {
        get { return castCDTimer; }
        set { castCDTimer = value; }
    }

    public Vector2 Direction => direction;
    public float CurrentSpeed => currentSpeed;

    public string PrefabID => wizardData.prefabId;

    private StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        StartAbstract();
        lifeController.OnDeath.AddListener(Die);
        stateMachine = GetComponent<StateMachine>();
        currentSpeed = wizardData.speed;
        
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
        currentSpeed = wizardData.speed * multiplier;
    }
    public void ChangeSpeed(float multiplier, float duration)
    {
        currentSpeed = wizardData.speed * multiplier;
        speedChangeTimer = duration;
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
