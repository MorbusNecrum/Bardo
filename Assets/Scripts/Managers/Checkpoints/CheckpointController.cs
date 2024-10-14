using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private GameObject player;
    private RespawnController respawnController;

    private void Start()
    {
        player = GameObject.Find("Player");
        respawnController = GetComponent<RespawnController>();
    }
    public CheckpointSO CreateCheckpoint()
    {
        CheckpointSO temp = ScriptableObject.CreateInstance<CheckpointSO>();
        temp.position = player.transform.position;
        temp.CurrentHealth = player.GetComponent<LifeController>().CurrentHealth;
        return temp;
    }
    public void RestoreFromCheckpoint(CheckpointSO checkpoint)
    {
        player.transform.position = checkpoint.position;
        player.GetComponent<LifeController>().Revive(checkpoint.CurrentHealth);
    }
}
