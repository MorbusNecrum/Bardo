using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private LevelManager levelManager;
    private void Start()
    {
        levelManager = GameObject.Find("LevelMANAGER").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelManager.ReachedCheckpoint();
            Destroy(gameObject);
        }
    }
}
