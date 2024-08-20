using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour , IExternalForceReciever
{
    [SerializeField] private float movementSpeed;
    private float speedX, speedY;
    private Vector2 direction;
    public Vector2 Direction => direction;

    private Vector2 forceToApply;
    [SerializeField] private Vector2 forceDampening;
    private Vector2 moveForce;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject instrument;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Guarda la ref del Rigidbody por codigo
        spriteRenderer = GetComponent<SpriteRenderer>();//Guarda la ref del SpriteRenderer por codigo
        
    }

    // Update is called once per frame
    void Update()
    {
        DirectionUpdate();//Input y managment del movimiento
    }

   
    private void DirectionUpdate()
    {
        //Settea la direccion normalizada
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        
        if(direction.magnitude > 1 )
        {
            direction.Normalize();
        }

        if (direction.x < 0) //va para la izq
        {
            spriteRenderer.flipX = true;
            instrument.GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (direction.x > 0) //va para la derecha
        {
            spriteRenderer.flipX = false;
            instrument.GetComponent<SpriteRenderer>().flipY = false;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        instrument.transform.eulerAngles = (new Vector3(0,0, angle));

        if(direction.magnitude == 0 && spriteRenderer.flipX) //Si esta quieto mirando para la izquierda
        {
            instrument.transform.eulerAngles = (new Vector3(0, 0, 180));
        }
    }

    private void FixedUpdate()
    {
        //Setea la velocidad en la direccion
        moveForce = direction * movementSpeed;

        //Agrega Fuerzas externas
        moveForce += forceToApply;

        //Baja esa Fuerza externa
        forceToApply /= forceDampening;

        //Si ya se fue casi toda la fuerza extra, la pone en 0
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }

        //Setea la velocidad del RB
        rb.velocity = moveForce;
    }

    public void AddExternalForce(Vector2 force)
    {
        forceToApply += force;
    }
}
