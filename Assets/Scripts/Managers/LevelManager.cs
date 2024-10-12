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
    private AbstractFactory notesAbstractFactory;

    // Start is called before the first frame update
    void Start()
    {
        //Le pasa su referencia al singleton del GameManager
        GameManager.Instance.ReferenceLevelManager(this);
        //Hace que el dialogueManager retome sus referencias
        DialogueManager.Instance.GetReferences();

        notesAbstractFactory = GameObject.Find("NotesAbstractFACTORY").GetComponent<AbstractFactory>();
        

        //SETTEA QUE ABSTRACT FACTORY DE NOTAS USAR SEGUN EL CONTROL EN USO DEL GAMEMANAGER
        switch(GameManager.Instance.ControllerInUse)
        {
            case ControllerType.PS4:
                    notesAbstractFactory.ChangeFactoryToUse(GameObject.Find("PS4NotesFACTORY").GetComponent<Factory>());
                break;
            case ControllerType.Xbox:
                    notesAbstractFactory.ChangeFactoryToUse(GameObject.Find("XboxNotesFACTORY").GetComponent<Factory>());
                break;
        }

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
