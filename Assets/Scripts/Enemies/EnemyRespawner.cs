using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour, IRespawneable
{
    private Vector3 initialPos;
    private void Start()
    {
        initialPos = transform.position;
    }
    public void Respawn()
    {
        transform.position = initialPos;
        GetComponent<LifeController>().ReviveAtMaxHealth();
    }
}
