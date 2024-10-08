using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeIdleState : MonoBehaviour, IState
{
    private string id = "Idle";
    public string Id => id;

    private UnityEvent<string> onChangeStateTo = new UnityEvent<string>();
    public UnityEvent<string> OnChangeStateTo => onChangeStateTo;


    //EXTRAS
    private Slime self;

    public void Enter()
    {
        Debug.Log("Entered Slime Idle State");
        if (self == null)
        {
            self = GetComponent<Slime>();
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Slime Idle State");
    }

    public void UpdateState()
    {
        if (self.PlayerDistance < self.ChaseDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Chase");
        }
    }

}
