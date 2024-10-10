using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string levelID;
    private int enemiesAlive;
    public string LevelID => levelID;
    public UnityEvent OnKilledAllEnemies = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        //Le pasa su referencia al singleton del GameManager
        GameManager.Instance.ReferenceLevelManager(this);
        //Hace que el dialogueManager retome sus referencias
        DialogueManager.Instance.GetReferences();

        List<GameObject> levelEnemies = new List<GameObject>();
        //Busca a todos los enemigos y los guarda en una lista temporal
        levelEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

        foreach (GameObject enemy in levelEnemies) 
        {
            //Se suscribe a su OnDeath y lo suma a enemigos vivos
            enemy.GetComponent<LifeController>().OnDeath.AddListener(EnemyDied);
            enemiesAlive++;
        }

    }
    private void EnemyDied()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            OnKilledAllEnemies.Invoke();
        }
    }
}
