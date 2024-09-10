using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class StateMachine : MonoBehaviour
{
    private IState currentState;

    public IState CurrentState => currentState;

    //[SerializeField] private List<GameObject> statesPrefabs = new List<GameObject>();// Cargar desde el Editor Empty Prefabs solo con el Script del State como componente
    
    private List<IState> states = new List<IState>(); //Agregar cada script de state como componente del GO
    
    private Dictionary<string, IState> stateDictonary = new Dictionary<string, IState>(); // Id >> IState

    [SerializeField] string startingState;


    //private void Awake()
    //{
    //    //Carga el dictionary
    //    foreach(var prefab in statesPrefabs)
    //    {
    //        if (prefab != null)
    //        {
    //            stateDictonary.Add(prefab.GetComponent<IState>().Id, prefab.GetComponent<IState>()); // Id >> IState
    //        }
    //    }


    //}
    private void Awake()
    {
        //Carga el dictionary
        states.AddRange(GetComponents<IState>());

        foreach (IState state in states)
        {
            stateDictonary.Add(state.Id, state); // Id >> IState
            state.OnChangeStateTo.AddListener(TransitionTo);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        //Settea el primer state
        stateDictonary.TryGetValue(startingState, out  IState stateToChange);
        currentState = stateToChange;
        currentState.Enter();
    }

    public void UpdateState()
    {
        currentState.UpdateState();
    }

    public void TransitionTo(string id)
    {
        stateDictonary.TryGetValue(id, out IState stateToChange);
        currentState = stateToChange;
        currentState.Enter();
    }
}
