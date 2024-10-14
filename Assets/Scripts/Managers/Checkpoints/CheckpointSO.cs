using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Checkpoint", menuName = "Scriptable Objects/Checkpoint", order = 1)]

public class CheckpointSO : ScriptableObject
{
    public int CurrentHealth;
    public Vector3 position;

}
