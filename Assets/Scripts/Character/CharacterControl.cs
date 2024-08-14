using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private float speedX, speedY;
    private Vector2 dir;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Guarda la ref del Rigidbody por codigo
        spriteRenderer = GetComponent<SpriteRenderer>();//Guarda la ref del SpriteRenderer por codigo
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();//Input y managment del movimiento


    }

    private void MovementUpdate()
    {
        //Settea la direccion normalizada
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        dir.Normalize();

        if (dir.x < 0) //va para la izq
        {
            spriteRenderer.flipX = true;
        }
        else if (dir.x > 0) //va para la derecha
        {
            spriteRenderer.flipX = false;
        }

        //settea la velocidad en la direccion

        speedX = dir.x * movementSpeed;
        speedY = dir.y * movementSpeed;

        rb.velocity = new Vector2(speedX, speedY); //Le pone la velocidad deseada normalizada
    }

}
