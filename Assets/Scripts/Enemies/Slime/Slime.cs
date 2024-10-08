using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy, IFactoryzable
{
    [SerializeField] SlimeFlyweight slimeData;

    private float jumpCDTimer = 0;
    private Vector2 direction;
    private float playerDistance = 100;
    public float PlayerDistance => playerDistance;
    public float ChaseDistance => slimeData.chaseDistance;
    public float JumpForce => slimeData.jumpForce;
    public float JumpCD
    {
        get { return slimeData.jumpCD; }
    }

    public float JumpCDTimer
    {
        get { return jumpCDTimer; }
        set { jumpCDTimer = value; }
    }

    public Vector2 Direction => direction;

    public string PrefabID => slimeData.prefabId;

    private StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        StartAbstract();
        lifeController.OnDeath.AddListener(Die);
        stateMachine = GetComponent<StateMachine>();

    }

    // Update is called once per frame
    void Update()
    {
        DirectionToPlayer();
        stateMachine.UpdateState();
        CheckTimers();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                collision.gameObject.GetComponent<IDamageable>().GetDamage(slimeData.basicAttackDamage);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * slimeData.pushBackForce, ForceMode2D.Impulse);
            }
        }
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
        //COOLDOWN DEL CASTEO, lo pone en 0
        if (jumpCDTimer > 0)
        {

            jumpCDTimer -= Time.deltaTime;
            if (jumpCDTimer <= 0)
            {
                jumpCDTimer = 0;
            }
        }
    }
  
    private void Die()
    {
        Destroy(gameObject);
    }
}
