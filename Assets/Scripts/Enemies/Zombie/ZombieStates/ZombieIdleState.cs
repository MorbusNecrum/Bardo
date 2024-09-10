using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : MonoBehaviour , IState
{
    private string id = "Idle";
    public string Id => id;

    public void Enter()
    {
        Debug.Log("Entered Zombie Idle State");
    }

    public void Exit()
    {

    }

    public void UpdateState()
    {

    }

}
