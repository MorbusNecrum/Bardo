using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class SlimeChaseState : MonoBehaviour, IState
{
    private string id = "Chase";
    public string Id => id;

    private UnityEvent<string> onChangeStateTo = new UnityEvent<string>();
    public UnityEvent<string> OnChangeStateTo => onChangeStateTo;

    //EXTRAS
    private Slime self;
    private Rigidbody2D rb;
    private Animator animator;
    private bool move;
    public void Enter()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (self == null)
        {
            self = GetComponent<Slime>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        move = true;


        Debug.Log("Entered Slime Chase State");


    }

    public void Exit()
    {
        move = false;
    }

    public void UpdateState()
    {
        if (self.PlayerDistance > self.ChaseDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Idle");
        }
        //Si ya puede saltar
        if (self.JumpCDTimer == 0)
        {
            //Triggerea la Anim
            animator.SetTrigger("Jump");// salta por un evento de la animacion que llama a Jump()
            self.JumpCDTimer = self.JumpCD;//le pone el CoolDown, el slime script se encarga del timer.
        }
    }
    private void Jump()
    {
        AudioManager.Instance.PlayAudioClip("SlimeJump");
        rb.AddForce(self.Direction * self.JumpForce, ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        if (move)
        {
            //CAMBIO DE ORIENTACION
            if (self.Direction.x < 0) //va para la izq
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);

            }
            else if (self.Direction.x > 0) //va para la derecha
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
        }
    }
}
