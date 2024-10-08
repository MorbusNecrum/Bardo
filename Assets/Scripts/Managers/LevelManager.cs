using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Factory enemyFactory;
    [SerializeField] private GameObject enemySpawnPoint;
    private int enemiesKilled = 0;
    private int enemiesAlive;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(enemiesKilled + 1);
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
                    enemy = enemyFactory.CreateGameObject("Zombie1");
                    enemy.transform.position = enemySpawnPoint.transform.position;
                    enemy.GetComponent<LifeController>().OnDeath.AddListener(EnemyKilled);
                    break;

                case 1:
                    enemy = enemyFactory.CreateGameObject("Wizard1");
                    enemy.transform.position = enemySpawnPoint.transform.position;
                    enemy.GetComponent<LifeController>().OnDeath.AddListener(EnemyKilled);
                    break;
                case 2:
                    enemy = enemyFactory.CreateGameObject("Slime1");
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
        if (enemiesAlive == 0)
        {
            SpawnEnemies(enemiesKilled + 1);
        }

    }
}
