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
    private Wizard wizard;
    private bool move = false;
    private Rigidbody2D rb;
    public void Enter()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (wizard == null)
        {
            wizard = GetComponent<Wizard>();
        }

        Debug.Log("Entered Wizard Chase State");
        move = true;

    }

    public void Exit()
    {
        move = false;
    }

    public void UpdateState()
    {
        if (wizard.PlayerDistance > wizard.ChaseDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Idle");
        }

        if (wizard.PlayerDistance <= wizard.CastingDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Cast");
        }
    }
    private void FixedUpdate()
    {
        if (move)
        {
            rb.AddForce(wizard.Direction.normalized * wizard.Speed);
        }
    }
}
