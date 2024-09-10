using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float velPower;// que tan empinada es la curva de la asintoica.
    [SerializeField] private float friction;
    [SerializeField] private float forceLimit; //Lo maximo de fuerza que se puede aplicar en un frame.
    private Vector2 direction;
    private Vector2 targetSpeed;
    

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
        InputUpdate();//Input y managment del movimiento
    }

    private void FixedUpdate()
    {
        Move();
        ApplyFriction();
    }

    private void ApplyFriction()
    {
        if (direction == Vector2.zero)//Si el player no quiere moverse
        {
            float frictionAmount = Mathf.Min(rb.velocity.magnitude, friction); //Aplica lo que sea menor
            Vector2 frictionToApply = rb.velocity.normalized * frictionAmount; //setea la friccion en direccion de la vel

            rb.AddForce(-frictionToApply, ForceMode2D.Impulse);// aplica la friccion en contra de la vel del PJ
        }
    }

    private void InputUpdate()
    {
        //Settea la direccion normalizada
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        direction.Normalize();

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
        instrument.transform.eulerAngles = (new Vector3(0, 0, angle));

        if (direction.magnitude == 0 && spriteRenderer.flipX) //Si esta quieto mirando para la izquierda
        {
            instrument.transform.eulerAngles = (new Vector3(0, 0, 180));
        }

    }
    private void Move()
    {
        //Calcula la velocidad deseada del player
        targetSpeed = direction * movementSpeed;

        //Calcula la diferencia entre su vel actual y a la q quiere llegar
        Vector2 speedDif = targetSpeed - rb.velocity;

        // Controla la empinacion de la curva de velocidad
        Vector2 movement = speedDif * velPower;

        //Limita la fuerza que se puede aplicar en un frame para que la Aceleracion sea constante
        //Si esa magnitud es menor, se comporta de forma asintotica, para que no vibre
        if(movement.magnitude > forceLimit)
        {
            movement = movement.normalized * forceLimit;
        }

        //Agrega la fuerza al RigidBody
        rb.AddForce(movement);
    }
}