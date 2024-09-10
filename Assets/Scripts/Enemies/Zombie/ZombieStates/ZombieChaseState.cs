using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChaseState : MonoBehaviour , IState
{
    private string id = "Chase";
    public string Id => id;

    public void Enter()
    {
        Debug.Log("Entered Zombie Chase State");
    }

    public void Exit()
    {

    }

    public void UpdateState()
    {

    }

   
}
