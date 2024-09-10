using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IState 
{
    string Id { get; }
    void UpdateState();
    void Enter();
    void Exit();

    UnityEvent<string> OnChangeStateTo { get; }
}
