using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieChaseState : MonoBehaviour , IState
{
    private string id = "Chase";
    public string Id => id;

    private UnityEvent<string> onChangeStateTo = new UnityEvent<string>();
    public UnityEvent<string> OnChangeStateTo => onChangeStateTo;

    //EXTRAS
    private Zombie self;
    private bool move = false;
    private Rigidbody2D rb;
    private Animator animator;
    public void Enter()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (self == null)
        {
            self = GetComponent<Zombie>();
        }
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        Debug.Log("Entered Zombie Chase State");
        move = true;
        animator.SetBool("IsWalking", true);
    }

    public void Exit()
    {
        move = false;
        animator.SetBool("IsWalking", false);
    }

    public void UpdateState()
    {
        if (self.PlayerDistance > self.ChaseDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Idle");
        }
    }
    private void FixedUpdate()
    {
        if(move)
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

            rb.AddForce(self.Direction.normalized * self.Speed);
        }
    }

}
