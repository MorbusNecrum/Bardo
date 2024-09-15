using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WizardIdleState : MonoBehaviour, IState
{
    private string id = "Idle";
    public string Id => id;

    private UnityEvent<string> onChangeStateTo = new UnityEvent<string>();
    public UnityEvent<string> OnChangeStateTo => onChangeStateTo;


    //EXTRAS
    private Wizard wizard;

    public void Enter()
    {
        Debug.Log("Entered Wizard Idle State");
        if (wizard == null )
        {
            wizard = GetComponent<Wizard>();
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Wizard Idle State");
    }

    public void UpdateState()
    {
        if (wizard.PlayerDistance < wizard.ChaseDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Chase");
        }
    }

}
