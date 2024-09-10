using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieIdleState : MonoBehaviour , IState
{
    private string id = "Idle";
    public string Id => id;

    private UnityEvent<string> onChangeStateTo = new UnityEvent<string>();
    public UnityEvent<string> OnChangeStateTo => onChangeStateTo;


    //EXTRAS
    private Zombie zombie;
    
    public void Enter()
    {
        if (zombie == null)
        {
            zombie = GetComponent<Zombie>();
        }
        Debug.Log("Entered Zombie Idle State");
    }

    public void Exit()
    {
        Debug.Log("Exiting Zombie Idle State");
    }

    public void UpdateState()
    {
        if (zombie.PlayerDistance < zombie.ChaseDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Chase");
        }
    }

    
}
