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
    private Vector2 lastDirection = new Vector2(1, 0);
    private Vector2 targetSpeed;

    private List<IInteractable> closeInteractables = new List<IInteractable>();
    public List<IInteractable> CloseInteractables => closeInteractables;

    Rigidbody2D rb;
    SpriteRenderer instrumentSpriteRenderer;
    Animator animator;
    [SerializeField] GameObject instrument;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Guarda la ref del Rigidbody por codigo
        instrumentSpriteRenderer = instrument.GetComponent<SpriteRenderer>();//Guarda la ref del SpriteRenderer por codigo
        animator = GetComponent<Animator>();
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
        if(direction != Vector2.zero)//Si no se movio
        {
            lastDirection = direction;
        }

        //SET DE PARAMETROS DE ANIMACION
        if (direction == Vector2.zero)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
        animator.SetFloat("LastMoveX", lastDirection.x);
        animator.SetFloat("LastMoveY", lastDirection.y);

        //Direcciona la trompeta
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        instrument.transform.eulerAngles = (new Vector3(0, 0, angle));

        if (direction.magnitude == 0) //Si esta quieto pone la trompe en dir a la lastDir
        {
            angle = Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg;
            instrument.transform.eulerAngles = (new Vector3(0, 0, angle));
        }
        if(angle > 90 ||  angle < -90)//Flippea para que no quede dada vuelta si esta en el 2ndo o 3er cuadrante
        {
            instrumentSpriteRenderer.flipY = true;  
        }
        else
        {
            instrumentSpriteRenderer.flipY = false;
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
    public void EnterInteractableZone(IInteractable interactable)
    {
        closeInteractables.Add(interactable);
    }

    public void LeftInteractableZone(IInteractable interactable)
    {
        closeInteractables.Remove(interactable);
    }

}
