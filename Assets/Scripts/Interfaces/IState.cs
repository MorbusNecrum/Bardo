using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    string Id { get; }
    void UpdateState();
    void Enter();
    void Exit();
}
