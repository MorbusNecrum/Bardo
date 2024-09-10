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
    private Zombie zombie;
    private bool move = false;
    private Rigidbody2D rb;
    public void Enter()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (zombie == null)
        {
            zombie = GetComponent<Zombie>();
        }

        Debug.Log("Entered Zombie Chase State");
        move = true;

    }

    public void Exit()
    {
        move = false;
    }

    public void UpdateState()
    {
        if (zombie.PlayerDistance > zombie.ChaseDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Idle");
        }
    }
    private void FixedUpdate()
    {
        if(move)
        {
            rb.AddForce(zombie.Direction.normalized * zombie.Speed);
        }
    }

}
