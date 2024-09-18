using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Factory enemyFactory;
    [SerializeField] private GameObject enemySpawnPoint;
    private int enemiesKilled = 0;
    private int enemiesAlive;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(enemiesKilled +1);
    }

    private void SpawnEnemies(int amount)
    {
        enemiesAlive = amount;
        for (int i = 0; i < amount; i++)
        {
            int num = Random.Range(0, enemyFactory.Prefabs.Count);
            GameObject enemy;
            switch (num)
            {
                case 0:
                    enemy = enemyFactory.CreateGameObject("Zombie");
                    enemy.transform.position = enemySpawnPoint.transform.position;
                    enemy.GetComponent<LifeController>().OnDeath.AddListener(EnemyKilled);
                    break;

                case 1:
                    enemy = enemyFactory.CreateGameObject("Wizard");
                    enemy.transform.position = enemySpawnPoint.transform.position;
                    enemy.GetComponent<LifeController>().OnDeath.AddListener(EnemyKilled);
                    break;
            }
        }
    }

    private void EnemyKilled()
    {
        enemiesKilled++;
        enemiesAlive--;
        if(enemiesAlive == 0)
        {
            SpawnEnemies(enemiesKilled+1);
        }

    }
}
