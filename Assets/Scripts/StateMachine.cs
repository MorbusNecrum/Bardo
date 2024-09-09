using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currentState;

    public IState CurrentState => currentState;

    [SerializeField] private List<GameObject> statesPrefabs = new List<GameObject>();// Prefabs con el script del state
    private Dictionary<string, IState> stateDictonary = new Dictionary<string, IState>(); // Id >> IState
    private List<IState> InstancedStates = new List<IState>();

    [SerializeField] string startingState;

    private void Awake()
    {
        //Carga el dictionary
        foreach(var prefab in statesPrefabs)
        {
            if (prefab != null)
            {
                stateDictonary.Add(prefab.GetComponent<IState>().Id, prefab.GetComponent<IState>()); // Id >> IState
            }
        }
    }

  

    // Start is called before the first frame update
    void Start()
    {
        //Settea el primer state
        stateDictonary.TryGetValue(startingState, out  IState stateToChange);
        currentState = stateToChange;
    }

    public void UpdateState()
    {
        currentState.UpdateState();
    }

    public void TransitionTo(IState state)
    {
        currentState = state;
        currentState.Enter();
    }
}
