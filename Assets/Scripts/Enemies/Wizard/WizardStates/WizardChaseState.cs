using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WizardChaseState : MonoBehaviour, IState
{
    private string id = "Chase";
    public string Id => id;

    private UnityEvent<string> onChangeStateTo = new UnityEvent<string>();
    public UnityEvent<string> OnChangeStateTo => onChangeStateTo;

    //EXTRAS
    private Wizard self;
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
            self = GetComponent<Wizard>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.SetBool("IsWalking", true);

        Debug.Log("Entered Wizard Chase State");
        move = true;

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

        if (self.PlayerDistance <= self.CastingDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Cast");
        }
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

            rb.AddForce(self.Direction.normalized * self.Speed);
        }
    }
}
